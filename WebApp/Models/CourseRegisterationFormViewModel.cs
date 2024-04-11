using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CourseRegisterationFormViewModel
    {
        [Required]
        [Display(Name ="Title")]
        public string Title { get; set; } = null!;
      
        [Display(Name = "Price")]
        public string? Price { get; set; }
        [Display(Name = "Discount Price")]
        public string? DisCountPrice { get; set; }
        [Display(Name = "Hours")]
        public string? Hours { get; set; }
        [Display(Name = "Likes In Numbers")]
        public string? LikesInNumbers { get; set; }
        [Display(Name = "Likes In Precent")]
        public string? LikesInProcent { get; set; }
        [Display(Name = "Author")]
        public string? Author { get; set; }
        [Display(Name = "Is a best Seller")]
        public bool IsBestSeller { get; set; }
    }
}
