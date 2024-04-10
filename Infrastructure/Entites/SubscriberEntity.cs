
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entites
{
    public class SubscriberEntity
    {
        //  public int Id { get; set; }
        [Key]
        public String Email { get; set; } = null!;
        public bool dailynewsletter { get; set; }
        public bool advertisingupdates { get; set; }
        public bool weekinreview { get; set; }
        public bool eventupdates { get; set; }
        public bool startupweekly { get; set; }
        public bool podcasts { get; set; }
    }

}