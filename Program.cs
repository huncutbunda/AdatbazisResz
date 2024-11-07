using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

public class DrawingDbContext : DbContext
{
    public DbSet<Drawing> Drawings { get; set; }
    public DbSet<Point> Points { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AdatbazisResz;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Drawing>()
            .HasMany(d => d.Points)
            .WithOne(p => p.Drawing)
            .HasForeignKey(p => p.DrawingId);
            
    }
}
public class Drawing
{
    [Key]
    public int DrawingId { get; set; }  

    [Required]
    public string Name { get; set; }  

    public DateTime CreatedDate { get; set; } = DateTime.Now;  

    public ICollection<Point> Points { get; set; } = new List<Point>();
}


public class Point
{
    [Key]
    public int PointId { get; set; }  

    public int X { get; set; }  

    public int Y { get; set; }  

    public int DrawingId { get; set; }

    public char Character { get; set; }

    [MaxLength(20)]  
    public string Color { get; set; }  

    [ForeignKey("DrawingId")]
    public Drawing Drawing { get; set; }  
}
