using Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories
{
    public class AddressFactory
    {

        public static AddressEntity CreateAddress()
        {
            try
            {
                return new AddressEntity();
                
            }
            catch { }
            return null;
        }
        public static AddressEntity CreateAddress(string streetName, string postalCode, string city)
        {
            try
            {
                return new AddressEntity()
                {
                    //StreetName = streetName,
                    PostalCode = postalCode,
                    City = city
                };
            }
            catch { }
            return null;
        }
        public static AddressEntity CreateAddress(AddressEntity entity)
        {
            try
            {
                return new AddressEntity()
                {
                    Id=entity.Id,
                  //  StreetName = entity.StreetName,
                    PostalCode = entity.PostalCode,
                    City = entity.City
                };
            }
            catch { }
            return null;
        }
    }
}
