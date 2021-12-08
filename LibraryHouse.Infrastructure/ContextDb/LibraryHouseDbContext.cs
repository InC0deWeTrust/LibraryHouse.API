using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LibraryHouse.Infrastructure.ContextDb
{
    public class LibraryHouseDbContext : DbContext
    {
        public LibraryHouseDbContext(DbContextOptions<LibraryHouseDbContext> options)
            : base(options)
        {
            
        }
    }
}
