using eTickets.Repository;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get; set; } 
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        List<Movie> Movies { get; set; }
    }
}
