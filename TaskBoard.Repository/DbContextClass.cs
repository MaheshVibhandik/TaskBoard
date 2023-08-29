using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Models;

namespace TaskBoard.Repository
{
    public class DbContextClass : IdentityDbContext
    {
        private bool seedDb = true;

        public DbContextClass(DbContextOptions<DbContextClass> contextOptions, bool seedDb = true) : base(contextOptions)
        {
            this.seedDb = seedDb;
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (seedDb)
            {
                //modelBuilder
                //    .Entity<TaskJob>()
                //    .HasMany(t => t.Attachments);

                modelBuilder.Entity<TaskJob>()
                    .HasData(new TaskJob()
                    {
                        Id = 100,
                        Subject = "TestDefault",
                        Deadline = DateTime.Now.ToString(),
                        Description = "Test purpose Only",
                        Assignee = 1,
                        Priority = Priority.Low,
                        State = IssueState.ToDo,
                        Reporter = 999,
                    });
            }
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TaskJob> TaskJob { get; set; }
    }
}
