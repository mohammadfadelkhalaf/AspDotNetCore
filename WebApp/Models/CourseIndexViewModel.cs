using WebApp.Models.ViewModels;

namespace WebApp.Models
{
    public class CourseIndexViewModel
    {
        public IEnumerable<CourseViewModel> Courses { get; set; } = [];
    }
}
