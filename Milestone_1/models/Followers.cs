using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Milestone_1.models
{
    public class Followers
    {
        [Key]
        public int id { get; set; }

        public UserData UserData { get; set; }

        public int UserToFollowForeignKey { get; set; }
        [ForeignKey("UserToFollowForeignKey")]
        public User UserToFollow { get; set; }

      

     
    }
}
