using Infrastructure.Context;
using Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AddressManger
    {
        private readonly DataContext _context;

        public AddressManger(DataContext context)
        {
            _context = context;
        }

        public  async Task<bool> CreateAddressAsync(AddressEntity address)
        {
            _context.Addresses.AddAsync(address);
             await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AddressEntity> GetAddressAsync(string UserId)
        {
            var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x =>x.UserId == UserId);

            return addressEntity!;

        }

        public async Task<bool> UpdateAddressAsync(AddressEntity address)
        {
            var exists = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId==address.UserId);
            if (exists != null)
            {
                _context.Entry(exists).CurrentValues.SetValues(address);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
