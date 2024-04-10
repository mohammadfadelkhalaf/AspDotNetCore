using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entites
{
    public class UserEntity:IdentityUser
    {
      //  [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;
     //s   [ProtectedPersonalData]
        public string LastName { get; set; } = null!;
       public string? ProfileImage { get; set; } ="profile2.jpg";
        //public string Password { get; set; } = null!;
        //public string SecurityKey { get; set; } = null!;
        //public string? Phone { get; set; }
        public string? Bio { get; set; }
     

        public int? AddressId { get; set; }
        public AddressEntity? Address { get; set; }

    }
}
