namespace ForumSystem.Web.ViewModels.Categories
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        private const int MaxCharacters = 300;

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(Content, @"<[^>]+>", string.Empty));
                return content.Length > MaxCharacters
                        ? content.Substring(0, MaxCharacters) + "..."
                        : content;
            }
        }

        // Automapper can map it this way since username is property of the User property in Post
        public string UserUserName { get; set; }

        public int CommentsCount { get; set; } // automatically mapped

        public DateTime CreatedOn { get; set; }
    }
}
