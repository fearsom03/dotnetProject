using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Milestone_1.models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set;}
        [Required]
        public string name { get; set;}
        [Required]
        public string discription { get; set; }

        public List<UserDataGroup> UserDataGroups { get; set; }

        public ICollection<Tweets> Tweets { get; set; }

    }
}
