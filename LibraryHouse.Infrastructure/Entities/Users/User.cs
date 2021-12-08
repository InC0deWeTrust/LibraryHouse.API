using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryHouse.Infrastructure.Entities.Users
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string PassportData { get; set; }

        public int? BankAccount { get; set; }

        [Phone]
        public string TelephoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
