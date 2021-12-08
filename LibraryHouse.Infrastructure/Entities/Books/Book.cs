using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryHouse.Infrastructure.Entities.Books
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //TODO: THINK IF IT'S POSSIBLE TO USE ENUM HERE WITH LIST OF DIFFERENT TYPES OF BOOK
        public string Type { get; set; }

        public DateTime DateOfDelivery { get; set; }
    }
}
