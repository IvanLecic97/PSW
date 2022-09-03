using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Model.Users
{
    public class RegUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime Birthday { get; set; }

        public RegUser()
        {

        }

        public RegUser(string email, string password, string name, string surname, string phone, string address, string city, DateTime birthday)
        {
            this.Email = email;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.Phone = phone;
            this.Address = address;
            this.City = city;
            this.Birthday = birthday;
        }
    }
}
