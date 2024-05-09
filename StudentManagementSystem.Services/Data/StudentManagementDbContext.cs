using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services.Data
{
    public class StudentManagementDbContext:DbContext
    {
        public StudentManagementDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Software Engineering"
                },new Department
                {
                    Id = 2,
                    Name = "Computer Science"
                },new Department
                {
                    Id = 3,
                    Name = "Nursing Science"
                },new Department
                {
                    Id = 4,
                    Name = "Microbiology"
                },new Department
                {
                    Id = 5,
                    Name = "Cyber Security"
                }

                );
        }
    }
}
