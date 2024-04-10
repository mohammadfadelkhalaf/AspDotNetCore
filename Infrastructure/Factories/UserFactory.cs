using Infrastructure.Entites;
using Infrastructure.Helpers;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories
{
    public class UserFactory
    {
        public static UserEntity Create()
        {
            try
            {
                return new UserEntity() { 
                    //Id = Guid.NewGuid().ToString(),
                    //Created=DateTime.Now,
                    //Modified=DateTime.Now
                };
            }
                
            
            catch { }
            return null;
        }
        public static UserEntity Create(SignUpModel model)
        {
            try
            {
                var (password, securitykey) = PasswordHasher.GenerateSecurePassowrd(model.Password);
                return new UserEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Eamil,
                    //Password = password,
                    //SecurityKey=securitykey,
                    //Created = DateTime.Now,
                    //Modified = DateTime.Now
                };

            }
            catch { }
            return null;
        }
    }
}
