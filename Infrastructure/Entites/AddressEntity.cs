using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entites
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        public string AddressLine_1 { get; set; } = null!;
        public string? AddressLine_2 { get; set; } 
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string UserId { get; set; } = null!;
       // public UserEntity User { get; set; }
        //   public ICollection<UserEntity> Users { get; set; } = [];

    }
}
