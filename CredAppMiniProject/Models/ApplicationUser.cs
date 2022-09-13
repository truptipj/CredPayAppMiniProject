using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        //public string UserName { get; set; }
    }
}
