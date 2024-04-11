namespace WebApp.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageName { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string? DisCountPrice { get; set; }
        public string Hours { get; set; } = null!;
        public string LikesInNumbers { get; set; } = null!;
        public string LikesInProcent { get; set; } = null!;
        public string Author { get; set; } = null!;
        public bool IsBestSeller { get; set; }
    }
}
