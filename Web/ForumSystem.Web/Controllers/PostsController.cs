namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class PostsController : Controller
    {
        private readonly IPostsService _postsService;
        private readonly ICategoriesService _categoriesService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            _postsService = postsService;
            _categoriesService = categoriesService;
            _userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var viewModel = _postsService.GetById<PostViewModel>(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = _categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new PostCreateInputModel
            {
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            var user = await _userManager.GetUserAsync(User);
            var postId = await _postsService.CreateAsync(input.Title, input.Content, input.CategoryId, user.Id);

            return RedirectToAction(nameof(ById), new { id = postId });
        }
    }
}
