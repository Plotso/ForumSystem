namespace ForumSystem.Data.Models
{
    using System.Collections.Generic;

    using ForumSystem.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Votes = new HashSet<Vote>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        //ToDo: Required
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
