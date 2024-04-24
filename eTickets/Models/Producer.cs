using eTickets.Repository;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    { 
        public int Id { get; set; } 
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        List<Movie> Movies { get; set; }

  }
}
