﻿// <auto-generated />
using System;
using LibraryHouse.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryHouse.Infrastructure.Migrations
{
    [DbContext(typeof(LibraryHouseDbContext))]
    [Migration("20211210131554_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Authors.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Books.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfDelivery")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Books.BookCompany", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("BookId", "CompanyId");

                    b.ToTable("BookCompanies");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Companies.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("BankAccount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PassportData")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Users.UserBook", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId", "BookId");

                    b.ToTable("UserBooks");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Users.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Books.Book", b =>
                {
                    b.HasOne("LibraryHouse.Infrastructure.Entities.Authors.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Books.BookCompany", b =>
                {
                    b.HasOne("LibraryHouse.Infrastructure.Entities.Books.Book", "Book")
                        .WithMany("BookCompanies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryHouse.Infrastructure.Entities.Companies.Company", "Company")
                        .WithMany("BookCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Users.UserBook", b =>
                {
                    b.HasOne("LibraryHouse.Infrastructure.Entities.Books.Book", "Book")
                        .WithMany("UserBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryHouse.Infrastructure.Entities.Users.User", "User")
                        .WithMany("UserBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryHouse.Infrastructure.Entities.Users.UserRole", b =>
                {
                    b.HasOne("LibraryHouse.Infrastructure.Entities.Roles.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryHouse.Infrastructure.Entities.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
