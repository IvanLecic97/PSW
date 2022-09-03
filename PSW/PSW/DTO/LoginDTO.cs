using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.DTO
{
    public class LoginDTO
    {
        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("password")]
        public String Password { get; set; }
    }
}
