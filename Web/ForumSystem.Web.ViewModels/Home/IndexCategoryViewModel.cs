namespace ForumSystem.Web.ViewModels.Home
{
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        // will be mapped by AutoMapper since in the Category class there is ICollection<Post> Posts
        public int PostsCount { get; set; }

        public string Url => $"/f/{Name.Replace(' ', '-')}";
    }
}