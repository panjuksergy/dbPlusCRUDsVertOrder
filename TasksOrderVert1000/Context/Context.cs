using Microsoft.EntityFrameworkCore;
using TasksOrderVert1000.Model;
namespace TasksOrderVert1000.Context;

public class Context : DbContext
{
    public DbSet<Duty> Tasks { get; set; }

    public Context()
    {
        Database.EnsureCreated();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source=DutiesDB.db");//.LogTo(Console.WriteLine);
        SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Duty>()
            .HasKey(t => t.DutyId) // configure DutyId as primary key
            .HasName("PK_TaskId");

        modelBuilder.Entity<Duty>()
            .Property(t => t.DutyId)
            .HasColumnName("Id"); // configure DutyId to be named Id

        modelBuilder.Entity<Duty>()
            .Property(t => t.DutyName)
            .HasMaxLength(30); // configure max length of DutyName to be 30
        
        modelBuilder.Entity<Duty>()
            .Property(t => t.Description)
            .HasMaxLength(300); // configure max length of Description to be 300
        
        modelBuilder.Entity<Duty>()
            .Property(t => t.Priority)
            .IsRequired()
            .HasDefaultValue(1);
        
        modelBuilder.Entity<Duty>()
            .Property(ti => ti.IsCompleted)
            .HasDefaultValue(false);
            

        base.OnModelCreating(modelBuilder);
    }
}