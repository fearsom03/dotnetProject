namespace Milestone_1.models
{
    public class Comment
    {
       public int id { get; set; }

        public Tweets Tweets { get; set; }

        public UserData UserData { get; set; }

        public string commentText { get; set;}
    }
}