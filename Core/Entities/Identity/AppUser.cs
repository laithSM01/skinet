using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        //Email comes from IdentityUser
        public string Display { get; set; }
        public Adress Adress { get; set; }
    }
}
