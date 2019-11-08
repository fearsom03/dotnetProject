using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Milestone_1.models
{
    public class UserDataGroup
    {

        public int UserDataForeignKey { get; set; }
        [ForeignKey("UserForeignKey")]
        public UserData UserData { get; set; }

        public int GroupForeignKey { get; set; }
        [ForeignKey("UserForeignKey")]
        public Group Group { get; set; }

      
    }
}
