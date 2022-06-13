using System;
using System.Collections.Generic;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Books;
using Microsoft.AspNetCore.Mvc;

namespace LibraryHouse.Application.Dtos.Books
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public int BookTypeId { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public int AuthorId { get; set; }

        public FileContentResult PictureResult { get; set; }
    }
}
