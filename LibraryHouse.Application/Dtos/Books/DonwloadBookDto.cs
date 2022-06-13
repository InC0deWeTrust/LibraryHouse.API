using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryHouse.Application.Dtos.Books
{
    public class DownloadBookDto
    {
        public byte[] File { get; set; }

        public string FileName { get; set; }
    }
}
