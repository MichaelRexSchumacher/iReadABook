using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iReadABook.Models.Book
{

    public class SearchResultsViewModel
    {
        public SearchResultsViewModel()
        {
            Books = new List<BookViewModel>();
        }

        public string SearchTerm { get; set; }
        public List<BookViewModel> Books { get; set; }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public string ID { get; set; }

        public string ImageLink { get; set; }
    }
}