using Microsoft.EntityFrameworkCore;
using STLapp.Models;

namespace STLapp.Data
{
    public class STLContext : DbContext
    {
        public STLContext(DbContextOptions<STLContext> options) : base(options) { } 

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<LessonProgram> LessonPrograms { get; set; }
    }
}
