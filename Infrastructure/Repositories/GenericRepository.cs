using Infrastructure.Context;
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
    public class GenericRepository<T> where T:class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<ResponseResult> CreateAsync(T entity)
        {
            try
            {
                _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok(entity);

            }
            catch(Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
        public virtual async Task<ResponseResult> GetAllAsync()
        {
            try
            {
             IEnumerable<T> result= await _context.Set<T>().ToListAsync();
                
                return ResponseFactory.Ok(result);

            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<T,bool>>predict)
        {
            try
            {
                var result = _context.Set<T>().FirstOrDefaultAsync(predict);
                if (result == null)
                    return ResponseFactory.NotFound();
                return ResponseFactory.Ok(result);

            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public virtual async Task<ResponseResult> UPdateOneAsync(Expression<Func<T, bool>> predict,T entity)
        {
            try
            {
                var result = _context.Set<T>().FirstOrDefaultAsync(predict);
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                    return ResponseFactory.Ok(result);
                }
                    return ResponseFactory.NotFound();
              

            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
        public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<T, bool>> predict)
        {
            try
            {
                var result = await _context.Set<T>().FirstOrDefaultAsync(predict);
                if (result != null)
                {
                    _context.Set<T>().Remove(result);
                    await _context.SaveChangesAsync();
                    return ResponseFactory.Ok("Removed successfuly");
                }
                return ResponseFactory.NotFound();


            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
        public virtual async Task<ResponseResult> ExistesAsync(Expression<Func<T, bool>> predict)
        {
            try
            {
                var result = await _context.Set<T>().AnyAsync(predict);
                if (result)
                {

                    return ResponseFactory.Exists();
                }
                return ResponseFactory.NotFound();


            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
    }
}
