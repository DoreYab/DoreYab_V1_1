using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Authentication.Models
{
    public class RegisterRequest
    {
        public string FullName { get; set; } = null;
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;

    }
}
