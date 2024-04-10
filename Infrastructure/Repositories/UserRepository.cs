using Infrastructure.Context;
using Infrastructure.Entites;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository:GenericRepository<UserEntity>
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context):base(context) { _context = context; }

        public override async Task<ResponseResult> GetAllAsync()
        {
            try
            {
                IEnumerable<UserEntity> result = await _context.Users.Include(a=>a.Address).ToListAsync();

                return ResponseFactory.Ok(result);

            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public override async Task<ResponseResult> GetOneAsync(Expression<Func<UserEntity, bool>> predict)
        {
            try
            {
                var result = _context.Set<UserEntity>().Include(a => a.Address).FirstOrDefaultAsync(predict);
                if (result == null)
                    return ResponseFactory.NotFound();
                return ResponseFactory.Ok(result);

            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
    }
}
