using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SubscribeViewModel
    {
        [Required]
        [Display(Name = "Subscribe", Prompt = "Please Enteryour Email Address")]
        public string Email { get; set; } = null!;
        public bool IsSbuscribed { get; set; }
        public bool DailyNewsLetter { get; set; }
        public bool AdvertisingUpdates { get; set; }
        public bool WeekInReview { get; set; } 
        public bool EventUpdates { get; set; }
        public bool StartupWeekly { get; set; } 
        public bool Podcasts { get; set; } 
    }
}
