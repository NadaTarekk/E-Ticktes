using eTickets.Data;
using eTickets.Models;
using eTickets.Repository;

namespace eTickets.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context)
        {
        }
    }
}
