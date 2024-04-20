using Infrastructure.Context;
using Infrastructure.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly DataContext _context;

        public SubscribersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscriberEntity entity)
        {
            if (ModelState.IsValid)
            {
                
                    var subscriber = await _context.Subscribers.AnyAsync(x => x.Email == entity.Email);
                if (subscriber)
                    return Conflict();


                _context.Add(entity);
                await _context.SaveChangesAsync();
                return Ok();
                
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> UnSubscribe(SubscriberEntity entity)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == entity.Email);
            if (subscriber != null)
            {

                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
                return Ok(subscriber);
            }
            return NotFound();
        }

    



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string  email)
        {
            var subscriber =await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if(subscriber!=null)
            return Ok(subscriber);
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscribers = await _context.Subscribers.ToListAsync();
            if(subscribers.Count!=0)
                return Ok(subscribers);
            return NotFound();
        }

        //[HttpPost]
 
        //public async Task<IActionResult> Create(string email)
        //{
        //    if (!string.IsNullOrEmpty(email))
        //    {
        //        var subscriber =await _context.Subscribers.AnyAsync(x => x.Email == email);
        //        if (!subscriber)
        //        {
        //            try
        //            {
        //                var subscriberEntity = new SubscriberEntity() { Email = email };
        //                _context.Subscribers.Add(subscriberEntity);
        //                await _context.SaveChangesAsync();
        //                return Created("", null);
        //            }
        //            catch
        //            {
        //                return Problem("unable to subsrcibe");
        //            }
        //        }
        //        return Conflict("your email is already subsrcied");
        //    }
        //    return BadRequest();
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string email)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriber != null)
            {
                subscriber.Email = email;
                _context.Subscribers.Update(subscriber);
               await _context.SaveChangesAsync();
                return Ok(subscriber);
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string email)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriber != null)
            {
              
                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
                return Ok(subscriber);
            }
            return NotFound();
        }

    }
}
