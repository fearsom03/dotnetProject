using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Milestone_1.models
{
    public class UserData
    {
        [Key]
        public int UserDataId { get; set; }

        public int UserForeignKey { get; set;}
        [ForeignKey("UserForeignKey")]
        public User User { get; set; }

        public string name{get;set;}
        public string surname { get; set; }
        public string gender { get; set; }
        public string country { get; set; }
        public string city { get; set; }

        public ICollection<Tweets> Tweets { get; set; }

        public ICollection<Followers> Followers { get; set; }

        public List<UserDataGroup> UserDataGroups { get; set; }


       

        
    }
}