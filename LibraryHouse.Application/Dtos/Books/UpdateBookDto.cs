using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryHouse.Application.Dtos.Books
{
    public class UpdateBookDto
    {
        public int BookId { get; set; }

        public string BookType { get; set; }
    }
}
