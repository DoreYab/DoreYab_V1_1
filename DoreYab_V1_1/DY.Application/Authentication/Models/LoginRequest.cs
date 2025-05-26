using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Authentication.Models
{
    public class LoginRequest
    {
        public string Email{ get; set; }
        public string Password{ get; set; }
    }
}
