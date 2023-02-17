using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndyBooks.Models;
using IndyBooks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndyBooks.Controllers
{
    public class AdminController : Controller
    {
        private IndyBooksDbContext _db;
        public AdminController(IndyBooksDbContext db) { _db = db; }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchVM searchVM)
        {
            //Full Collection Search
            IQueryable<Book> foundBooks = _db.Books; //.Include(b => b.Author) ; //<<<< Why do you need this

            //Partial Title Search
            if (searchVM.Title != null)
            {
                foundBooks = foundBooks
                             .Where(b => b.Title.Contains(searchVM.Title));
            }

            //Author's Last Name Search
            if (searchVM.Name != null)
            {
                //TODO: Add Lamda method to include the Book's Author entity
                foundBooks = foundBooks
                             .Where(b=> b.Author.Name.EndsWith(searchVM.Name))
                             ;
            }
            //Priced Between Search (min and max price entered)
            if (searchVM.Max > 0)
            {
                foundBooks = foundBooks
                             .Where(b => b.Price >= searchVM.Min && b.Price <= searchVM.Max)
                             ;
            }
            if (searchVM.Sale)
            { 
                foundBooks = foundBooks
                             .Where(b => b.Price > 80)
                             .Select(b => new Book
                             {
                                 Title = b.Title,
                                 Author = b.Author,
                                 SKU = b.SKU,
                                 Price = b.Price / 2
                             });

            }

            //Pass a SearchResultsVM object to View
            var searchResults = new SearchResultsVM
            {
                FoundBooks = foundBooks,
                HalfPriceSale = searchVM.Sale
            };

            return View("SearchResults", searchResults);
        }
    }
}
