using eTickets.Repository;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; } 
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }
        
    }
}
