using System;
using System.Collections.Generic;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Books;
using LibraryHouse.Infrastructure.Entities.Companies;
using LibraryHouse.Infrastructure.Entities.Roles;
using LibraryHouse.Infrastructure.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace LibraryHouse.Infrastructure.ContextDb
{
    public class LibraryHouseDbContext : DbContext
    {
        public LibraryHouseDbContext(DbContextOptions<LibraryHouseDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<UserBook> UserBooks { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<BookCompany> BookCompanies { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UnusedIndexes
            //User
            //modelBuilder.Entity<User>(b =>
            //{
            //    b.HasIndex(e => new {e.Email});
            //    b.HasIndex(e => new {e.PassportData });
            //    b.HasIndex(e => new {e.PassportData, e.Email});
            //});

            //Role
            //modelBuilder.Entity<Role>(b =>
            //{
            //    b.HasIndex(e => new { e.Name });
            //});

            //Book
            //modelBuilder.Entity<Book>(b =>
            //{
            //    b.HasIndex(e => new {e.DateOfDelivery});
            //});

            //Company
            //modelBuilder.Entity<Company>(b =>
            //{
            //    b.HasIndex(e => new {e.Name});
            //});

            //Author
            //modelBuilder.Entity<Author>(b =>
            //{
            //    b.HasIndex(e => new {e.LastName});
            //    b.HasIndex(e => new {e.FirstName, e.LastName});
            //});

            #endregion

            #region Indexes
            //User
            modelBuilder.Entity<UserRole>(b =>
            {
                b.HasIndex(e => new {e.UserId, e.RoleId});
            });

            modelBuilder.Entity<UserBook>(b =>
            {
                b.HasIndex(e => new { e.UserId, e.BookId });
            });

            //Book
            modelBuilder.Entity<BookCompany>(b =>
            {
                b.HasIndex(e => new {e.BookId, e.CompanyId});
            });

            #endregion

            #region Relations

            //Book-Author
            modelBuilder.Entity<Author>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books);

            //User-Role
            modelBuilder.Entity<UserRole>()
                .HasKey(x => new {x.UserId, x.RoleId});

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);

            //User-Book
            modelBuilder.Entity<UserBook>()
                .HasKey(x => new {x.UserId, x.BookId});

            modelBuilder.Entity<UserBook>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserBooks)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserBook>()
                .HasOne(x => x.Book)
                .WithMany(x => x.UserBooks)
                .HasForeignKey(x => x.BookId);

            //Book-Company
            modelBuilder.Entity<BookCompany>()
                .HasKey(x => new {x.BookId, x.CompanyId});

            modelBuilder.Entity<BookCompany>()
                .HasOne(x => x.Book)
                .WithMany(x => x.BookCompanies)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<BookCompany>()
                .HasOne(x => x.Company)
                .WithMany(x => x.BookCompanies)
                .HasForeignKey(x => x.CompanyId);

            #endregion
        }
    }
}
