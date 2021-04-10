using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class ConverterService
    {
        public Book ConvertToBook(Dictionary<string, string> userInput)
        {
            var author = ConvertToAuthor(userInput["Author Name"], userInput["Author Surname"]);
            var category = ConvertToCategory(userInput["Category"]);
            var year = ConvertToInteger(userInput["Publication Year"]);
            var language = ConverToLanguage(userInput["Language"]);
            var book = new Book()
            {
                Name = userInput["Book Title"],
                Author = author,
                Category = category,
                ISBN = userInput["ISBN"],
                PublicationDate = year,
                Language = language,
                IsTaken = false
            };
            return book;
        }

        private Author ConvertToAuthor(string authourName, string authorSurname)
        {
            var author = new Author()
            {
                Name = authourName,
                Surname = authorSurname
            };
            return author;
        }

        private Categories ConvertToCategory(string categoryString)
        {
            var category = (Categories)Enum.Parse(typeof(Categories), categoryString);
            return category;
        }

        private Languages ConverToLanguage(string languageString)
        {
            var language = (Languages)Enum.Parse(typeof(Languages), languageString);
            return language;
        }

        public Customer ConvertToCustomer(Dictionary<string, string> userInputForCustomerData, DateTime borrowDate)
        {
            var customer = new Customer()
            {
                Name = userInputForCustomerData["Customer Name"],
                Surname = userInputForCustomerData["Customer Surname"],
                BorrowDate = borrowDate
            };
            return customer;
        }

        private DateTime ConverToDate(string dateString)
        {
            var date = DateTime.Parse(dateString);
            return date;
        }

        public int ConvertToInteger(string intString)
        {
            var number = int.Parse(intString);
            return number;
        }

        public int[] ConvertToIntegerArray(string[] stringArray)
        {
            int[] array = stringArray.Select(int.Parse).ToArray();
            return array;
        }
    }
}
