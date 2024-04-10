using Infrastructure.Context;
using Infrastructure.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly DataContext _context;

        public AccountService(UserManager<UserEntity> userManager,DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<bool> UpdateUserAsync(UserEntity user)
        {
            _context.Users.FirstOrDefault(x => x.Id == user.Id);
            _userManager.Users.FirstOrDefault(x => x.Email == user.Email);
            _context.SaveChanges();
            return true;
        }
    }
}
