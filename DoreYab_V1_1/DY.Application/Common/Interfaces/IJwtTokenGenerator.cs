using DY.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Common.Interfaces
{
    public class IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}
