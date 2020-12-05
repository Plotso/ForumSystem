namespace ForumSystem.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        /// <param name="postId">The post to which the vote would be applied. </param>
        /// <param name="userId">The user who's voting. </param>
        /// <param name="isUpVote">Defines if the vote is UpVote or DownVote. </param>
        Task VoteAsync(int postId, string userId, bool isUpVote);

        int GetVotes(int postId);
    }
}
