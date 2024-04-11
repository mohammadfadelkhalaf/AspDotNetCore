using Infrastructure.Context;
using Infrastructure.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly DataContext _context;

        public CoursesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Courses = await _context.Courses.ToListAsync();
            if (Courses.Count != 0)
                return Ok(Courses);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (Course != null)
                return Ok(Course);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult>CreateOneCourse(CourseDto entity)
        {
            if (ModelState.IsValid)
            {
                var courseentity = new CourseEntity
                {
                    Title = entity.Title,
                    Price=entity.Price,
                    DisCountPrice=entity.DisCountPrice,
                    Hours=entity.Hours,
                  //  ImageName=entity.ImageName,
                    ImageName="01.jpg",
                    IsBestSeller=entity.IsBestSeller,
                    LikesInNumbers=entity.LikesInNumbers,
                    LikesInProcent=entity.LikesInProcent,
                    Author=entity.Author
                };
                  _context.Courses.Add(courseentity);
                await _context.SaveChangesAsync();

                Course course = courseentity;
                return Created("", course);
            }
            return BadRequest();
        }
    }
}
