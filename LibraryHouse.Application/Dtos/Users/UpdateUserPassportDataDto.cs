using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryHouse.Application.Dtos.Users
{
    public class UpdateUserPassportDataDto
    {
        public int UserId { get; set; }
        public string PassportData { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
