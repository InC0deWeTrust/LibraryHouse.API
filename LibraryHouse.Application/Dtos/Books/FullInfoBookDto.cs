using System;
using System.Collections.Generic;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Books;

namespace LibraryHouse.Application.Dtos.Books
{
    public class FullInfoBookDto
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public Author Author { get; set; }

        public string Description { get; set; }
    }
}
