using System;
using System.Collections.Generic;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Books;

namespace LibraryHouse.Application.Models.Books
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BookTypeEnum Type { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public Author Author { get; set; }
    }
}
