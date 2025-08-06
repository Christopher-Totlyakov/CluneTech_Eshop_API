using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Accounts
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
