using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryHouse.Application.Dtos.Users
{
    public class UserDto
    {
        public int UserId { get; set; }

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
    }
}
