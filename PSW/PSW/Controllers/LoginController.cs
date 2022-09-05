using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PSW.DTO;
using PSW.Model.Users;
using PSW.Service.UserService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PSW.Controllers
{

    [Route("login")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
		private readonly IConfiguration _config;
		private readonly IPatientService patientService;
		private readonly IDoctorService doctorService;
		private readonly IAdminService adminService;

		public LoginController(IConfiguration config, IPatientService patient, IDoctorService doctorService, IAdminService adminService)
		{
			this._config = config;
			this.patientService = patient;
			this.doctorService = doctorService;
			this.adminService = adminService;
		}



		[HttpPost]
		[AllowAnonymous]
		public IActionResult Login([FromBody] LoginDTO loginData)
		{
			string role;
			//string isFirstAppointment = "false";
			IActionResult response = Unauthorized();
			RegUser user = AuthenticateUser(loginData);


			try
				{
			Patient authUser = (Patient)user;
			Patient patient = patientService.FindByEmail(authUser.Email);
			//isFirstAppointment = patient.IsFirstAppointment.ToString();
			role = "Patient";
			}
			catch
			{
				try
				{
					user = (Doctor)user;
					Doctor doctor = doctorService.FindById(user.Id);
					role = "Doctor";
				} catch
                {
					user = (Admin)user;
					role = "Admin";
                }
			}


			if (user != null)
			{
				var tokenString = GenerateJWTToken(user, role);
				response = Ok(new
				{
					token = tokenString,
					email = user.Email,
					role = role,
					//isFirstAppointment = isFirstAppointment,
				});
			}
			return response;
		}




		private RegUser AuthenticateUser(LoginDTO loginData)
		{

			Doctor Doctor = doctorService.LoginDoctor(loginData.Email, loginData.Password);

			if (Doctor == null)
			{

				Patient patient = patientService.PatientLogin(loginData.Email, loginData.Password);
				if (patient == null || patient.IsBlocked)
				{
					Admin Admin = adminService.LoginAdmin(loginData.Email, loginData.Password);
					if(Admin == null)
                    {
						return null;
					}
					return Admin;
				}
				return patient;
			}
			return Doctor;
		}


		private string GenerateJWTToken(RegUser user, string role)
		{
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new[]{
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim("fullName", user.Name + " " + user.Surname),
				new Claim("roles", role),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};
			var token = new JwtSecurityToken(
				/*                issuer: _config["Jwt: Issuer"],
								audience: _config["Jwt: Audience"],*/
				claims: claims,
				expires: DateTime.Now.AddMinutes(180),
				signingCredentials: credentials
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
