using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class CourseDto
    {
        [Required]
        public string Title { get; set; } = null!;
        public string? ImageName { get; set; }
        public string? Price { get; set; }
        public string? DisCountPrice { get; set; }
        public string? Hours { get; set; }
        public string? LikesInNumbers { get; set; }
        public string? LikesInProcent { get; set; }
        public string? Author { get; set; }
        public bool IsBestSeller { get; set; }
    }
}
