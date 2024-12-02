using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
          
            protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Kullanıcı silindiğinde yorum silinmesin
    modelBuilder.Entity<Comment>()
        .HasOne(c => c.User)
        .WithMany()
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.NoAction);  // Kullanıcı silindiğinde yorum silinmesin

    // BlogPost silindiğinde yorumlar silinsin
    modelBuilder.Entity<Comment>()
        .HasOne(c => c.BlogPost)
        .WithMany()
        .HasForeignKey(c => c.BlogPostId)
        .OnDelete(DeleteBehavior.Cascade);  // BlogPost silindiğinde yorumlar silinsin
}



        
        
        
    }
    
}