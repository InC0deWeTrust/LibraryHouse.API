﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryHouse.Infrastructure.Entities.Companies
{
    [Table("Companies")]
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
