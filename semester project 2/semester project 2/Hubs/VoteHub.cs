using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace semester_project_2.Hubs
{
    public class VoteHub : Hub
    {
        public async Task UpdateVotes(int candidateId, int newVoteCount)
        {
            await Clients.All.SendAsync("ReceiveVoteUpdate", candidateId, newVoteCount);
        }
    }
}
