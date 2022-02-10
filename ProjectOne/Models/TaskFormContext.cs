using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class TaskFormContext : DbContext
    {
        // Constructor
        public TaskFormContext(DbContextOptions<TaskFormContext> options) : base(options)
        {
            // Leave blank for now
        }

        public DbSet<TaskForm> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            mb.Entity<TaskForm>().HasData(

                new TaskForm
                {
                    TaskId = 1,
                    TaskName = "Take out trash",
                    DueDate = "2022-02-09",
                    Quadrant = 2,
                    CategoryId = 1,
                    Completed = false
                },
                new TaskForm
                {
                    TaskId = 2,
                    TaskName = "Watch Book of Boba Fett",
                    DueDate = "2022-02-12",
                    Quadrant = 1,
                    CategoryId = 1,
                    Completed = false
                },
                new TaskForm
                {
                    TaskId = 3,
                    TaskName = "Answer phone: Your extended warranty...",
                    DueDate = "2022-02-09",
                    Quadrant = 3,
                    CategoryId = 3,
                    Completed = false
                },
                new TaskForm
                {
                    TaskId = 4,
                    TaskName = "Look at memes",
                    DueDate = "2022-02-09",
                    Quadrant = 4,
                    CategoryId = 2,
                    Completed = false
                }
            );
        }
    }
}
