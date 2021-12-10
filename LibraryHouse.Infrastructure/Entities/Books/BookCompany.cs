using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Companies;

namespace LibraryHouse.Infrastructure.Entities.Books
{
    [Table("BookCompanies")]
    public class BookCompany
    {
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
