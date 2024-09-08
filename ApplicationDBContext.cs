﻿using Educational_Medical_platform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Shoghlana.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shoghlana.EF
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Objective> Objectives { get; set; } 
        public DbSet<Question> Questions { get; set; }
        public DbSet<Requirement> Requirements { get; set; } 
        public DbSet<StandardTest> StandardTests { get; set; } 
        public DbSet<Student> Students { get; set; } 
        public DbSet<SubCategory> SubCategories { get; set; } 
        public DbSet<Supervisor> Supervisors { get; set; } 
        public DbSet<Video> Videos { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }




        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

        ///<summary>
        ///Enforce Validation on RunTime Before Sending Changes to DB 
        ///  This method will enforce validation on all entities, 
        ///  regardless of how they are added or modified, 
        ///  including those configured via Fluent API.
        /// </summary>
        public override int SaveChanges()
        {

            var Entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Modified ||
                           e.State == EntityState.Added //&&( e.Entity is Employee)  => can use certain conditions also if needed
                           select e.Entity;

            bool IsValid = true;
            foreach (var Entity in Entities)
            {
                ValidationContext validationContext = new ValidationContext(Entity);
               IsValid =  Validator.TryValidateObject(Entity, validationContext , new List<ValidationResult>()); 
                //true: This parameter specifies whether to validate all properties (when true) or only required properties (when false). >> in case of using validate object()
            }
            if(IsValid)
            {
                return base.SaveChanges();
            }
            return 0;  // indication for 0 entries added or updated >> saving didnot happen due to validation errors >> when call savechanges() check return != 0

        }

    }
}
