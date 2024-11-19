using System;
using Domain.Courses;
using Domain.Lessons;
using Domain.Questions;
using Domain.Students;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Lesson>   Lessons { get; set; } = null!;
        public DbSet<Course>   Courses { get; set; } = null!;
        public DbSet<Student>  Students { get; set; } = null!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;
        public DbSet<StudentLesson> StudentLessons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<StudentCourse>()
		        .HasKey(sc => new { sc.StudentId, sc.CourseId });
	        
	        modelBuilder.Entity<StudentLesson>()
		        .HasKey(sc => new { sc.StudentId, sc.LessonId });
	        
	        modelBuilder.Entity<Lesson>()
		        .Ignore(l => l.Questions);

        }
	}
}

