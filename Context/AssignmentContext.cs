using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TasksProject.Models;

namespace TasksProject.Context
{
    public class AssignmentContext: DbContext
    {
        public DbSet<Assignment> Assignment { get; set;}
        public DbSet<User> User { get; set;}
        public DbSet<UserStory> UserStory{ get; set;}
        public DbSet<Sprint> Sprint{ get; set;}

        public AssignmentContext(DbContextOptions<AssignmentContext> options): base(options) { }

    }
}
