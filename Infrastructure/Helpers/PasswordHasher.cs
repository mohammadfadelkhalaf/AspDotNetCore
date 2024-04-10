using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public class PasswordHasher
    {
        public static (string,string) GenerateSecurePassowrd(string password)
        {
            using var Hmac = new HMACSHA512();
            var securityKey = Hmac.Key;
            var hash = Hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return (Convert.ToBase64String(securityKey),Convert.ToBase64String(hash));
        }
        public static bool validateSecurePassword(string password,string hash,string securityKey)
        {
            var security = Convert.FromBase64String(securityKey);
            var pwd = Convert.FromBase64String(hash);
            using var hmac= new HMACSHA512(security);
            var hashedpassword =hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
          
            var userpassword= Convert.FromBase64String(hash);
            for(int i = 0; i < hashedpassword.Length; i++)
            {
                if (hashedpassword[i] != hash[i])
                    return false;
            }
            return true;

        }
    }
}
