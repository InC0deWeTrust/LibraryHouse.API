using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Users;

namespace LibraryHouse.Infrastructure.Entities.Roles
{
    [Table("Roles")]
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
