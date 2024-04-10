using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entites
{
    public class CourseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageName { get; set; } = "01.jpg";
        public string Price { get; set; } = null!;
        public string? DisCountPrice { get; set; }
        public string Hours { get; set; } = null!;
        public string? LikesInNumbers { get; set; }
        public string LikesInProcent { get; set; } = null!;
        public string Author { get; set; } = null!;
        public bool IsBestSeller { get; set; }

    }
}
