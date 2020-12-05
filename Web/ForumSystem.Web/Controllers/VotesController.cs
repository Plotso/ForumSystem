namespace ForumSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService _votesService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VotesController(IVotesService votesService, UserManager<ApplicationUser> userManager)
        {
            _votesService = votesService;
            _userManager = userManager;
        }

        // POST /api/votes
        // Request body: {"postId":1,"isUpVote":true}
        // Response body: {"votesCount":16}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = _userManager.GetUserId(User);
            await _votesService.VoteAsync(input.PostId, userId, input.IsUpVote);

            var votesScore = _votesService.GetVotes(input.PostId);

            return new VoteResponseModel { VotesCount = votesScore };
        }
    }
}
