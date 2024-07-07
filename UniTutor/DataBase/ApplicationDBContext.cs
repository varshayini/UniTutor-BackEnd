using Microsoft.EntityFrameworkCore;
using UniTutor.Model;
namespace UniTutor.DataBase;


public class ApplicationDBContext:DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }
    public DbSet<Admin> Admin { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Subject> Subjects { get; set; }
   // public DbSet<Review> Reviews { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Comment> Comments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.stuId);

        modelBuilder.Entity<Tutor>()
            .HasMany(t => t.Comments)
            .WithOne(c => c.Tutor)
            .HasForeignKey(c => c.tutId);

        modelBuilder.Entity<Tutor>()
               .Property(t => t.CreatedAt)
               .HasColumnType("datetime2"); // Ensure the type matches your MSSQL column type

        modelBuilder.Entity<Student>()
               .Property(t => t.CreatedAt)
               .HasColumnType("datetime2");

        base.OnModelCreating(modelBuilder);
    }


}
