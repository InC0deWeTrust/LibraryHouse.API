using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryHouse.Application.Dtos.Users
{
    public class UpdateUserBankAccountDto
    {
        public int UserId { get; set; }
        public int BankAccount { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
