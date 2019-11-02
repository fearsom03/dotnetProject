using System;
namespace Milestone_1.models
{
    public class UserDataGroup
    {

        public int UserDataId { get; set; }
        public UserData UserData { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

      
    }
}
