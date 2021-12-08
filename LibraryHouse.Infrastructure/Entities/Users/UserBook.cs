using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryHouse.Infrastructure.Entities.Users
{
    [Table("UserBooks")]
    public class UserBook
    {
        public int Id { get; set; }
    }
}
