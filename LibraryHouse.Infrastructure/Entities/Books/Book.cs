using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Companies;
using LibraryHouse.Infrastructure.Entities.Users;

namespace LibraryHouse.Infrastructure.Entities.Books
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BookTypeEnum Type { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public Author Author { get; set; }

        public ICollection<UserBook> UserBooks { get; set; }

        public ICollection<BookCompany> BookCompanies { get; set; }
    }
}
