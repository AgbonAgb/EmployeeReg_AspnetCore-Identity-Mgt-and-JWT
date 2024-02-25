using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Accounts
{
    public class UserReg:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }


    }
}
