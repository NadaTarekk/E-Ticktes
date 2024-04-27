using eTickets.Data;
using eTickets.Models;
using eTickets.Repository;

namespace eTickets.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorService(AppDbContext context) : base(context)
        {
        }
    }
}
