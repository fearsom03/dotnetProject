using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Milestone_1.models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }

        public int TweetForeignKey { get; set; }
        [ForeignKey("TweetForeignKey")]
        public Tweets Tweets { get; set; }

        public int UserDataId { get; set; }
        [ForeignKey("UserDataId")]
        public UserData UserData { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Min Lenth 2")]
        public string commentText { get; set;}

    }
}