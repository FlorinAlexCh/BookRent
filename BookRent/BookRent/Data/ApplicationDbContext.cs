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
            builder.Entity<Library_Books>().HasKey(lb => new { lb.LibraryId, lb.BooksId });

            builder.Entity<Library_Books>().HasOne(b => b.Books).WithMany(lb => lb.Library_Books).HasForeignKey(b => b.BooksId);
            builder.Entity<Library_Books>().HasOne(b => b.Library).WithMany(lb => lb.Library_Books).HasForeignKey(b => b.LibraryId);


            base.OnModelCreating(builder);
        }
        public DbSet<Library_Books> Library_Bookss { get; set; }
        public DbSet<Books> Bookss { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Library> Libraries{ get; set; }
        public DbSet<BookRentals> BookRentals { get; set; }


    }
}
