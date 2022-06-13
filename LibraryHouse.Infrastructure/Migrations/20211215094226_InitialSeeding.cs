using System;
using LibraryHouse.Infrastructure.Entities.Books;
using LibraryHouse.Infrastructure.Entities.Roles;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryHouse.Infrastructure.Migrations
{
    public partial class InitialSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Roles seeding
            migrationBuilder.Sql($"INSERT INTO Roles (Id,Name) VALUES ('1', '{RoleEnum.SuperAdmin}')");
            migrationBuilder.Sql($"INSERT INTO Roles (Id,Name) VALUES ('2', '{RoleEnum.User}')");

            //Users seeding
            migrationBuilder.Sql(
                $"INSERT INTO Users (Id,FirstName,LastName,UserName,Address,PassportData,BankAccount,TelephoneNumber,Email,Password) " +
                $"VALUES('1', 'andrey', 'matviychuk', 'andreymatviychuk', 'Vasilkov,13', 'UA2901', '012345', '0662205394', 'matviychukandrey1@gmail.com', '{BCrypt.Net.BCrypt.HashPassword("123qwe")}')");
            migrationBuilder.Sql(
                $"INSERT INTO Users (Id,FirstName,LastName,UserName,Address,PassportData,BankAccount,TelephoneNumber,Email,Password) " +
                $"VALUES('2', 'vitaliy', 'gorobets', 'vitaliygorobets', 'Kiev,19', 'UA2610', '99999', '0668902323', 'vitaliy@gmail.com', '{BCrypt.Net.BCrypt.HashPassword("123qwe")}')");
            migrationBuilder.Sql(
                $"INSERT INTO Users (Id,FirstName,LastName,UserName,Address,PassportData,TelephoneNumber,Email,Password) " +
                $"VALUES('3', 'vanya', 'gorobets', 'vanyagorobets', 'Odessa,40', 'UA7267', '0897675610', 'vanya@gmail.com', '{BCrypt.Net.BCrypt.HashPassword("123qwe")}')");
            migrationBuilder.Sql(
                $"INSERT INTO Users (Id,FirstName,LastName,UserName,Address,PassportData,BankAccount,TelephoneNumber,Email,Password) " +
                $"VALUES('4', 'dima', 'lemeshko', 'dimalemeshko', 'Evolve,99', 'UA999923', '666666', '0456789012', 'dima@gmail.com', '{BCrypt.Net.BCrypt.HashPassword("123qwe")}')");

            //UserRole seeding
            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId,RoleId) VALUES ('1', '1')");
            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId,RoleId) VALUES ('2', '1')");
            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId,RoleId) VALUES ('3', '2')");
            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId,RoleId) VALUES ('4', '2')");

            //BookType seeding
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('1', '{BookTypeEnum.Fantasy}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('2', '{BookTypeEnum.Adventure}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('3', '{BookTypeEnum.Romance}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('4', '{BookTypeEnum.Contemporary}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('5', '{BookTypeEnum.Dystopian}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('6', '{BookTypeEnum.Mystery}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('7', '{BookTypeEnum.Horror}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('8', '{BookTypeEnum.Thriller}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('9', '{BookTypeEnum.Paranormal}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('10', '{BookTypeEnum.History}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('11', '{BookTypeEnum.Health}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('12', '{BookTypeEnum.Motivational}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('13', '{BookTypeEnum.Cooking}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('14', '{BookTypeEnum.Development}')");

            //Authors seeding
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('1', 'danieal', 'kelhman')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('2', 'akeel', 'bilgrami')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('3', 'jeff', 'vanderMeer')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('4', 'johan', 'wolfgang')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('5', 'steve', 'fraser')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('6', 'charlie', 'smith')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('7', 'menzie', 'chinn')");

            //Companies seeding
            //migrationBuilder.Sql($"INSERT INTO Companies (Id,Name) VALUES ('1', 'Google')");
            //migrationBuilder.Sql($"INSERT INTO Companies (Id,Name) VALUES ('2', 'Samsung')");
            //migrationBuilder.Sql($"INSERT INTO Companies (Id,Name) VALUES ('3', 'RedHat')");
            //migrationBuilder.Sql($"INSERT INTO Companies (Id,Name) VALUES ('4', 'ABC')");

            //Books seeding
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('1', 'Tyll', '{DateTime.Now.ToString("yyyy-MM-dd")}', '1', '1')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('2', 'Nature and Value', '{DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}', '2', '2')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('3', 'Dead Astrounats', '{DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd")}', '3', '6')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('4', 'The Essential Goethe', '{DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")}', '4', '6')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('5', 'Cancer Ward', '{DateTime.Now.ToString("yyyy-MM-dd")}', '1', '10')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('6', 'Wall Street', '{DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd")}', '5', '14')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('7', 'Three Delays', '{DateTime.Now.AddDays(-8).ToString("yyyy-MM-dd")}', '6', '3')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('8', 'Lost Decades', '{DateTime.Now.AddDays(-20).ToString("yyyy-MM-dd")}', '7', '10')");

            //BookCompanies seeding
            //migrationBuilder.Sql($"INSERT INTO BookCompanies (BookId,CompanyId) VALUES ('1', '1')");
            //migrationBuilder.Sql($"INSERT INTO BookCompanies (BookId,CompanyId) VALUES ('2', '2')");
            //migrationBuilder.Sql($"INSERT INTO BookCompanies (BookId,CompanyId) VALUES ('3', '3')");
            //migrationBuilder.Sql($"INSERT INTO BookCompanies (BookId,CompanyId) VALUES ('4', '4')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Delete initial roles
            migrationBuilder.Sql($"DELETE FROM Roles WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM Roles WHERE Id='2';");

            //Delete initial users
            migrationBuilder.Sql($"DELETE FROM Users WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM Users WHERE Id='2';");
            migrationBuilder.Sql($"DELETE FROM Users WHERE Id='3';");
            migrationBuilder.Sql($"DELETE FROM Users WHERE Id='4';");

            //Delete initial booktypes
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='2';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='3';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='4';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='5';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='6';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='7';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='8';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='9';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='10';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='11';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='12';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='13';");
            migrationBuilder.Sql($"DELETE FROM BookTypes WHERE Id='14';");

            //Delete initial authors
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='2';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='3';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='4';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='5';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='6';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='7';");

            //Delete initial companies
            //migrationBuilder.Sql($"DELETE FROM Companies WHERE Id='1';");
            //migrationBuilder.Sql($"DELETE FROM Companies WHERE Id='2';");
            //migrationBuilder.Sql($"DELETE FROM Companies WHERE Id='3';");
            //migrationBuilder.Sql($"DELETE FROM Companies WHERE Id='4';");

            //Delete initial books
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='2';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='3';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='4';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='5';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='6';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='7';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='8';");
        }
    }
}
