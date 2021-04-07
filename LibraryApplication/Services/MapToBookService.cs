using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class MapToBookService
    {
        public Book MapUserInput(Dictionary<string, string> userInput)
        {
            var author = new Author()
            {
                Name = userInput["Author Name"],
                Surname = userInput["Author Surname"]
            };
            var category = (Categories)Enum.Parse(typeof(Categories), userInput["Category"]);
            var year = int.Parse(userInput["Publication Date"]);
            var language = (Languages)Enum.Parse(typeof(Languages), userInput["Language"]);
            var book = new Book()
            {
                Name = userInput["Name"],
                Author = author,
                Category = category,
                ISBN = userInput["ISBN"],
                PublicationDate = year,
                Language = language,
                IsTaken = false
            };
            return book;
        }
    }
}
