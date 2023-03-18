using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TasksProject.Models;

namespace TasksProject.Context
{
    public class AssignmentContext: DbContext
    {
        public DbSet<Assignment> Assignments { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<UserStory> UserStories { get; set;}
        public DbSet<Sprint> Spints{ get; set;}

        public AssignmentContext(DbContextOptions<AssignmentContext> options): base(options) { }

    }
}
