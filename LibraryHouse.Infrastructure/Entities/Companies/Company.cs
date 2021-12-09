using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Books;

namespace LibraryHouse.Infrastructure.Entities.Companies
{
    [Table("Companies")]
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookCompany> BookCompanies { get; set; }
    }
}
