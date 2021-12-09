using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryHouse.Application.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string PassportData { get; set; }

        public int? BankAccount { get; set; }

        public string TelephoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
