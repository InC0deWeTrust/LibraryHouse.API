using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryHouse.Application.Dtos.Books
{
    public class CreateBookDto
    {
        public string Name { get; set; }

        public string BookType { get; set; }

        public string AuthorName { get; set; }

        public string AuthorSurname { get; set; }
    }
}
