using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using UniTutor.Model;
namespace UniTutor.DataBase;


public class ApplicationDBContext : DbContext
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
        // Configure the Student entity
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Comments)
            .WithOne(c => c.Student)
            .HasForeignKey(c => c.stuId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the Tutor entity
        modelBuilder.Entity<Tutor>()
            .HasMany(t => t.Comments)
            .WithOne(c => c.Tutor)
            .HasForeignKey(c => c.tutId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the Comment entity
        modelBuilder.Entity<Comment>()
            .Property(c => c.userType)
            .IsRequired();

        modelBuilder.Entity<Comment>()
            .Property(c => c.commentText)
            .IsRequired();

        modelBuilder.Entity<Comment>()
            .Property(c => c.Date)
            .IsRequired();


        modelBuilder.Entity<Request>()
                       .HasOne(sr => sr.Student)
                       .WithMany(s => s.Requests)
                       .HasForeignKey(sr => sr.studentId)
 .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Tutor>()
               .Property(t => t.CreatedAt)
               .HasColumnType("datetime2"); // Ensure the type matches your MSSQL column type

        modelBuilder.Entity<Student>()
               .Property(t => t.CreatedAt)
 .HasColumnType("datetime2");

        modelBuilder.Entity<Request>()
            .HasOne(sr => sr.Subject)
            .WithMany(s => s.Requests)
            .HasForeignKey(sr => sr.subjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Request>()
            .HasOne(sr => sr.Tutor)
            .WithMany(t => t.Requests)
            .HasForeignKey(sr => sr.tutorId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    } 
}




