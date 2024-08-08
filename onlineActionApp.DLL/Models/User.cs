using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // Admin or Normal

        public bool IsBaned { get; set; } = false;
        public string? Token { get; set; }
    }

}
