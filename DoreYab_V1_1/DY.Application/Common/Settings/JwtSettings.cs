using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Common.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int DurationInMinutes { get; set; }
    }
}
