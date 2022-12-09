using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.EntityConfigurations;
using Microsoft.EntityFrameworkCore;


namespace ApplicationCore.Domain
{

    public class MyClassDbContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassTeacher> ClassesTeachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Improvement> Improvements { get; set; }


        public MyClassDbContext()
        {

        }

        public MyClassDbContext(DbContextOptions<MyClassDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=.;Database=MyClass;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.ApplyConfiguration(new StudentConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());

        }

    }
}
