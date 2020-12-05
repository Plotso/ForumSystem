namespace ForumSystem.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> _votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            _votesRepository = votesRepository;
        }

        public int GetVotes(int postId)
        {
            var votes = _votesRepository
                .All()
                .Where(v => v.PostId == postId)
                .Sum(x => (int)x.Type);
            return votes;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = _votesRepository.All()
                .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = postId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote
                };

                await _votesRepository.AddAsync(vote);
            }

            await _votesRepository.SaveChangesAsync();
        }
    }
}
