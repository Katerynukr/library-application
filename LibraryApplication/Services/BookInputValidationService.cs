using LibraryApplication.Interfaces;
using LibraryApplication.Loggers;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class BookInputValidationService : IBookInputValidation
    {
        private readonly ConsoleLogger _consoleLogger;

        public BookInputValidationService()
        {
            _consoleLogger = new ConsoleLogger();
        }

        public bool IsValidBookTitle(Dictionary<string, string> userInput)
        {
            if (userInput["Book Title"].Length > 1 && userInput["Book Title"].Length < 40 && userInput["Book Title"].All(Char.IsLetter))
            {
                return true;
            }
            throw new Exception("Book title should contain letters only. Min length 1 character, max length 40 characters");
        }

        public bool IsValidAuthorName(Dictionary<string, string> userInput)
        {
            if (userInput["Author Name"].All(Char.IsLetter) && userInput["Author Surname"].All(Char.IsLetter))
            {
                return true;
            }
            throw new Exception("Author name and surname should contain letters only");
        }

        public bool IsValidPublicationYear(Dictionary<string, string> userInput)
        {
            try
            {
                var year = int.Parse(userInput["Publication Year"]);
                if (year < DateTime.Now.Year && year > 800)
                {
                    return true;
                }
                throw new Exception("Year is not valid");
            }
            catch(InvalidCastException e)
            {
                _consoleLogger.Write(e.Message);
                return false;
            }

        }

        public bool IsValidISBN(Dictionary<string, string> userInput)
        {
            if (userInput["ISBN"].All(Char.IsDigit) && userInput["ISBN"].Length < 12 && userInput["ISBN"].Length > 4)
            {
                return true;
            }
            throw new Exception("ISBN should contain numbers only");
        }

        public bool IsValidCategory(Dictionary<string, string> userInput)
        {
            List<string> categories = Enum.GetNames(typeof(Categories)).ToList();
            var isCategory = categories.Any(c => userInput["Category"].Contains(c));
            if (isCategory)
            {
                return true;
            }
            throw new Exception("No such category in the library");
        }

        public bool IsValidLanguage(Dictionary<string, string> userInput)
        {
            List<string> languages = Enum.GetNames(typeof(Languages)).ToList();
            var isAvailableLanguage = languages.Any(c => userInput["Language"].Contains(c));
            if (isAvailableLanguage)
            {
                return true;
            }
            throw new Exception("No such language in the library");
        }

        public bool IsValidDataForNewBook(Dictionary<string, string> userInputToCreateNewBook)
        {
            List<bool> validationResults = new List<bool>();
            try
            {
                validationResults.Add(IsValidBookTitle(userInputToCreateNewBook));
                validationResults.Add(IsValidAuthorName(userInputToCreateNewBook));
                validationResults.Add(IsValidLanguage(userInputToCreateNewBook));
                validationResults.Add(IsValidCategory(userInputToCreateNewBook));
                validationResults.Add(IsValidISBN(userInputToCreateNewBook));
                validationResults.Add(IsValidPublicationYear(userInputToCreateNewBook));
                foreach (var result in validationResults)
                {
                    if (result == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                _consoleLogger.Write(e.Message);
                return false; 
            }  
        }

        public bool IsValidStringId(string id)
        {
            if (id.All(Char.IsDigit))
            {
                return true;
            }
            throw new Exception("Id should contain digits only");
        }


        public bool IsValidCustomerData(Dictionary<string, string> userInput)
        {
            if (userInput["Customer Name"].All(Char.IsLetter) && userInput["Customer Surname"].All(Char.IsLetter))
            {
                return true;
            }
            throw new Exception("Customer Name and Surname should contain numbers only");
        }
        public bool IsValidStringIds(string[] bookIds)
        {
            foreach(var id in bookIds)
            {
                if (!id.All(Char.IsDigit))
                {
                    throw new Exception("Id should contain digits only");
                }
            }
            return true;
        }

        public bool IsValidDataToBorrowBook(Dictionary<string, string> customerData,  string[] idsStringArray)
        {
            List<bool> validationResults = new List<bool>();
            try
            {
                validationResults.Add(IsValidStringIds(idsStringArray));
                validationResults.Add(IsValidCustomerData(customerData));
                foreach (var result in validationResults)
                {
                    if (result == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                _consoleLogger.Write(e.Message);
                return false;
            }
        }
    }
}
