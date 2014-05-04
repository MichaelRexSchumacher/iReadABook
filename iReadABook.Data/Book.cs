using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iReadABook.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
    }
}
