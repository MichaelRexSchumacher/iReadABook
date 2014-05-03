using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleSearchApi;
using Google.Apis.Books;
using Google.Apis.Books.v1;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using iReadABook.Models.Book;

namespace iReadABook.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        [HttpGet]
        public ActionResult Search(string searchTerm)
        {
            // Create the service.
            var service = new BooksService(new BaseClientService.Initializer()
            {
                //ApiKey = "IzaSyBv71CkLIRo_JmLo9UeZud8kRNFVJ1Sb0k"
            });

            var request = new VolumesResource.ListRequest(service, searchTerm);
            request.MaxResults = 40;

            var searchResult = request.Execute();


            var result = new SearchResultsViewModel();
            
            result.SearchTerm = searchTerm;

            foreach (var resultItem in searchResult.Items)
            {
                var bookViewModel = new BookViewModel
                {
                    Title = resultItem.VolumeInfo.Title,
                    ID = resultItem.Id
                };
                var author = resultItem.VolumeInfo.Authors != null ? resultItem.VolumeInfo.Authors.Aggregate((i, j) => i + ", " + j) : null;
                Google.Apis.Books.v1.Data.Volume.VolumeInfoData.IndustryIdentifiersData industryIdentifier = null;

                if (resultItem.VolumeInfo.IndustryIdentifiers != null && resultItem.VolumeInfo.IndustryIdentifiers.Any())
                {
                    industryIdentifier = resultItem.VolumeInfo.IndustryIdentifiers.FirstOrDefault(x => x.Type == "ISBN_13") ??
                        resultItem.VolumeInfo.IndustryIdentifiers.FirstOrDefault(x => x.Type == "ISBN_10");
                }


                var imageLink = resultItem.VolumeInfo.ImageLinks != null ? resultItem.VolumeInfo.ImageLinks.Thumbnail : null;

                if (industryIdentifier != null && imageLink != null && author != null)
                {
                    bookViewModel.Author = author;
                    bookViewModel.ImageLink = imageLink;
                    bookViewModel.ISBN = industryIdentifier.Identifier;
                    result.Books.Add(bookViewModel);               
                }

            }

            return View(result);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            var service = new BooksService(new BaseClientService.Initializer()
            {
            });

            var request = service.Volumes.Get(id);
            var result = request.Execute();

            var industryIdentifier = result.VolumeInfo.IndustryIdentifiers.First(x => x.Type == "ISBN_13") ?? result.VolumeInfo.IndustryIdentifiers.First(x => x.Type == "ISBN_10");
            var imageLink = result.VolumeInfo.ImageLinks.Thumbnail;

            var viewModel = new BookDetailsViewModel { 
                Author = result.VolumeInfo.Authors.Aggregate((i, j) => i + ", " + j),
                ISBN = industryIdentifier.Identifier,
                Title = result.VolumeInfo.Title,
                ImageLink = imageLink,
                Id = id,
                Description = result.VolumeInfo.Description
            };

            viewModel.Questions = new List<string> { "This is a question?" };

            return View(viewModel);
        }
        
	}
}