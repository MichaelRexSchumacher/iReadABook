using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iReadABook.Models.Book
{
    public class BookDetailsViewModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string ImageLink { get; set; }

        public string Id { get; set; }
    }
}