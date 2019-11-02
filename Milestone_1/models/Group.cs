using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Milestone_1.models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set;}

        public string name { get; set;}
        public string discription { get; set; }

        public List<UserDataGroup> UserDataGroups { get; set; }

        public ICollection<Tweets> Tweets { get; set; }

    }
}
