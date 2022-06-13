﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryHouse.Application.Dtos.Authors
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> BookNames { get; set; }
    }
}
