using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryHouse.Application.Dtos.Users
{
    public class UpdateUserDto
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        [Phone]
        public string TelephoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
