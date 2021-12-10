using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Books;

namespace LibraryHouse.Infrastructure.Entities.Users
{
    [Table("UserBooks")]
    public class UserBook
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
