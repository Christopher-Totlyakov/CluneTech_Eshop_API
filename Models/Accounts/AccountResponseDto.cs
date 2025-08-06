using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Accounts
{
    public class AccountResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; }

        public ClientDto Client { get; set; }
    }
}
