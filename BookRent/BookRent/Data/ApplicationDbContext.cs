using BookRent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRent.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Books>().HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherID).HasConstraintName("FK_Bookss_Publishers_PublisherID");
            builder.Entity<Books>().HasOne(b => b.Library).WithMany(l => l.Books).HasForeignKey(l => l.LibraryID).HasConstraintName("FK_Bookss_Libraries_LibraryID");


            base.OnModelCreating(builder);
        }
        public DbSet<Books> Bookss { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Library> Libraries{ get; set; }
        public DbSet<BookRentals> BookRentals { get; set; }


    }
}
