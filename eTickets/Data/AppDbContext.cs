using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
       public DbSet<Actor> Actors { get; set; }
       public DbSet<Movie> Movies { get; set; }
       public DbSet<Cinema> Cinemas { get; set; }
       public DbSet<Producer> Producers { get; set; }
       public DbSet<Actor_Movie> Actors_Movies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new {
                am.MovieId,
                am.ActorId
            });

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.Actors_Movies)
                .HasForeignKey(am => am.MovieId);

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.Actors_Movies)
                .HasForeignKey(am => am.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
