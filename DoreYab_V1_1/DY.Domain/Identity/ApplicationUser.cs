using _0_Framework.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public bool Activate { get; set; } = true;
    }
}
