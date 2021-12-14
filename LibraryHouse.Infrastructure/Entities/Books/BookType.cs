using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryHouse.Infrastructure.Entities.Books
{
    [Table("BookTypes")]
    public class BookType
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
