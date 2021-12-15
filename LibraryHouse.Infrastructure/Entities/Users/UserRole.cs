using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LibraryHouse.Infrastructure.Entities.Roles;

namespace LibraryHouse.Infrastructure.Entities.Users
{
    [Table("UserRoles")]
    public class UserRole
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
