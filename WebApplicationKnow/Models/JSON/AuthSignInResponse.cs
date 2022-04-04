using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationKnow.Models.JSON
{
    public class AuthSignInResponse
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Group { get; set; }
    }
}