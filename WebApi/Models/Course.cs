using Infrastructure.Entites;
using WebApi.Entities;

namespace WebApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ImageName { get; set; }
        public string? Price { get; set; }
        public string? DisCountPrice { get; set; }
        public string? Hours { get; set; }
        public string? LikesInNumbers { get; set; }
        public string? LikesInProcent { get; set; }
        public string? Author { get; set; }
        public bool IsBestSeller { get; set; }
        //adding course data

        public static implicit operator Course(Infrastructure.Entites.CourseEntity courseentity)
        {

            return new Course
            {
                Id = courseentity.Id,
                Title = courseentity.Title,
                Price = courseentity.Price,
                DisCountPrice = courseentity.DisCountPrice,
                Hours = courseentity.Hours,
                IsBestSeller = courseentity.IsBestSeller,
                LikesInNumbers = courseentity.LikesInNumbers,
                LikesInProcent = courseentity.LikesInProcent,
                Author = courseentity.Author
            };
        }
    }
}
