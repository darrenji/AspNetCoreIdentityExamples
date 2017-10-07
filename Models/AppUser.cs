using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentityExamples.Models
{
    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
        public QualificationLevels Qualifications { get; set; }
    }
}
