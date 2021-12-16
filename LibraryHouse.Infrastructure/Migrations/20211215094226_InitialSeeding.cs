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
            migrationBuilder.Sql($"INSERT INTO Roles (Id,Name) VALUES ('2', '{RoleEnum.Admin}')");
            migrationBuilder.Sql($"INSERT INTO Roles (Id,Name) VALUES ('3', '{RoleEnum.User}')");
            migrationBuilder.Sql($"INSERT INTO Roles (Id,Name) VALUES ('4', '{RoleEnum.Guest}')");

            //Users seeding
            migrationBuilder.Sql(
                $"INSERT INTO Users (Id,FirstName,LastName,UserName,Address,PassportData,BankAccount,TelephoneNumber,Email,Password) " +
                $"VALUES('1', 'andrey', 'matviychuk', 'andreymatviychuk', 'Vasilkov,13', 'UA2901', '012345', '0662205394', 'matviychukandrey1@gmail.com', '{BCrypt.Net.BCrypt.HashPassword("andrey")}')");
            migrationBuilder.Sql(
                $"INSERT INTO Users (Id,FirstName,LastName,UserName,Address,PassportData,BankAccount,TelephoneNumber,Email,Password) " +
                $"VALUES('2', 'vitaliy', 'gorobets', 'vitaliygorobets', 'Kiev,19', 'UA2610', '99999', '0668902323', 'vitaliy@gmail.com', '{BCrypt.Net.BCrypt.HashPassword("vitaliy")}')");
            migrationBuilder.Sql(
                $"INSERT INTO Users (Id,FirstName,LastName,UserName,Address,PassportData,TelephoneNumber,Email,Password) " +
                $"VALUES('3', 'vanya', 'gorobets', 'vanyagorobets', 'Odessa,40', 'UA7267', '0897675610', 'vanya@gmail.com', '{BCrypt.Net.BCrypt.HashPassword("vanya")}')");
            migrationBuilder.Sql(
                $"INSERT INTO Users (Id,FirstName,LastName,UserName,Address,PassportData,BankAccount,TelephoneNumber,Email,Password) " +
                $"VALUES('4', 'dima', 'lemeshko', 'dimalemeshko', 'Evolve,99', 'UA999923', '666666', '0456789012', 'dima@gmail.com', '{BCrypt.Net.BCrypt.HashPassword("dima")}')");

            //UserRole seeding
            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId,RoleId) VALUES ('1', '1')");
            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId,RoleId) VALUES ('2', '2')");
            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId,RoleId) VALUES ('3', '3')");
            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId,RoleId) VALUES ('4', '4')");

            //BookType seeding
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('1', '{BookTypeEnum.Action}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('2', '{BookTypeEnum.Adventure}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('3', '{BookTypeEnum.Classics}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('4', '{BookTypeEnum.Comic}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('5', '{BookTypeEnum.Detective}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('6', '{BookTypeEnum.Fantasy}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('7', '{BookTypeEnum.Horror}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('8', '{BookTypeEnum.Mystery}')");
            migrationBuilder.Sql($"INSERT INTO BookTypes (Id,Type) VALUES ('9', '{BookTypeEnum.Romance}')");

            //Authors seeding
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('1', 'john', 'milton')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('2', 'william', 'blake')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('3', 'franz', 'kafka')");
            migrationBuilder.Sql($"INSERT INTO Authors (Id,FirstName,LastName) VALUES ('4', 'george', 'orwell')");

            //Companies seeding
            migrationBuilder.Sql($"INSERT INTO Companies (Id,Name) VALUES ('1', 'Google')");
            migrationBuilder.Sql($"INSERT INTO Companies (Id,Name) VALUES ('2', 'Samsung')");
            migrationBuilder.Sql($"INSERT INTO Companies (Id,Name) VALUES ('3', 'RedHat')");
            migrationBuilder.Sql($"INSERT INTO Companies (Id,Name) VALUES ('4', 'ABC')");

            //Books seeding
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('1', 'roses and violets', '{DateTime.Now.ToString("yyyy-MM-dd")}', '1', '9')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('2', 'doom', '{DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")}', '2', '7')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('3', 'futurama', '{DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")}', '3', '6')");
            migrationBuilder.Sql($"INSERT INTO Books (Id,Name,DateOfDelivery,AuthorId,BookTypeId) VALUES ('4', 'charlie chaplin', '{DateTime.Now.AddDays(3).ToString("yyyy-MM-dd")}', '4', '3')");

            //BookCompanies seeding
            migrationBuilder.Sql($"INSERT INTO BookCompanies (BookId,CompanyId) VALUES ('1', '1')");
            migrationBuilder.Sql($"INSERT INTO BookCompanies (BookId,CompanyId) VALUES ('2', '2')");
            migrationBuilder.Sql($"INSERT INTO BookCompanies (BookId,CompanyId) VALUES ('3', '3')");
            migrationBuilder.Sql($"INSERT INTO BookCompanies (BookId,CompanyId) VALUES ('4', '4')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Delete initial roles
            migrationBuilder.Sql($"DELETE FROM Roles WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM Roles WHERE Id='2';");
            migrationBuilder.Sql($"DELETE FROM Roles WHERE Id='3';");
            migrationBuilder.Sql($"DELETE FROM Roles WHERE Id='4';");

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

            //Delete initial authors
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='2';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='3';");
            migrationBuilder.Sql($"DELETE FROM Authors WHERE Id='4';");

            //Delete initial companies
            migrationBuilder.Sql($"DELETE FROM Companies WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM Companies WHERE Id='2';");
            migrationBuilder.Sql($"DELETE FROM Companies WHERE Id='3';");
            migrationBuilder.Sql($"DELETE FROM Companies WHERE Id='4';");

            //Delete initial books
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='1';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='2';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='3';");
            migrationBuilder.Sql($"DELETE FROM Books WHERE Id='4';");
        }
    }
}
