using System;
using System.Collections.Generic;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Authors;

namespace LibraryHouse.Application.Dtos.Books
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public string BookType { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public Author Author { get; set; }
    }
}
