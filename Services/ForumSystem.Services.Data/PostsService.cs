namespace ForumSystem.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> _postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public async Task<int> CreateAsync(string title, string content, int categoryId, string userId)
        {
            var post = new Post
            {
                CategoryId = categoryId,
                Title = title,
                Content = content,
                UserId = userId
            };

            await _postsRepository.AddAsync(post);
            await _postsRepository.SaveChangesAsync();

            return post.Id;
        }

        public T GetById<T>(int id)
        {
            var post = _postsRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
            return post;
        }
    }
}
