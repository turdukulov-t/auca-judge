using AUCA.Domain.Entity;
using BusinessBanking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusinessBanking.DAL.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasAlternateKey(u => u.Login);

            modelBuilder.Entity<User>().HasData(new User[] {
                new User
                {
                    ID = 1,
                    UniversityID = 1,
                    Login = "user",
                    Password = "ee11cbb19052e40b07aac0ca060c23ee",
                    CreatedDate = DateTime.Now,
                    IsEnabled = true,
                    Email = "admin@auca.kg"
                },
            });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
