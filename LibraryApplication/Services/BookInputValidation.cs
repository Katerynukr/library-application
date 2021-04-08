using LibraryApplication.Interfaces;
using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class BookInputValidation : IBookInputValidation
    {
        public bool IsValidBookTitle(Dictionary<string, string> userInput)
        {
            if (userInput["Book Title"].Length > 1 && userInput["Book Title"].Length < 40 && userInput["Book Title"].All(Char.IsLetter))
            {
                return true;
            }
            return false;
        }

        public bool IsValidAuthorName(Dictionary<string, string> userInput)
        {
            var isValidNameSurname = userInput["Author Name"].All(Char.IsLetter) && userInput["Author Surname"].All(Char.IsLetter) ? true : false;
            return isValidNameSurname;
        }

        public bool IsValidPublicationYear(Dictionary<string, string> userInput)
        {
            try
            {
                var year = int.Parse(userInput["Publication Year"]);
                var isPastYear = year < 2021 && year > 800 ? true : false;
                return isPastYear;
            }
            catch
            {
                return false;
            }

        }

        public bool IsValidISBN(Dictionary<string, string> userInput)
        {
            if (userInput["ISBN"].All(Char.IsDigit) && userInput["ISBN"].Length < 12 && userInput["ISBN"].Length > 4)
            {
                return true;
            }
            return false;

        }

        public bool IsValidCategory(Dictionary<string, string> userInput)
        {
            List<string> categories = Enum.GetNames(typeof(Categories)).ToList();
            var isCategory = categories.Any(c => userInput["Category"].Contains(c));
            if (isCategory)
            {
                return true;
            }
            return false;


        }

        public bool IsValidLanguage(Dictionary<string, string> userInput)
        {
            List<string> languages = Enum.GetNames(typeof(Languages)).ToList();
            var isAvailableLanguage = languages.Any(c => userInput["Language"].Contains(c));
            if (isAvailableLanguage)
            {
                return true;
            }
            return false;


        }

        public bool IsValidDataForNewBook(Dictionary<string, string> userInputToCreateNewBook)
        {
            List<bool> validationResults = new List<bool>();
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

        public bool IsValidStringId(string id)
        {
            if (id.All(Char.IsDigit))
            {
                return true;
            }
            return false;
        }


        public bool IsValidCustomerData(Dictionary<string, string> userInput)
        {
            var isValidData = userInput["Customer Name"].All(Char.IsLetter) && userInput["Customer Surname"].All(Char.IsLetter) ? true : false;
            return isValidData;
        }

        public bool IsValidDate(string dateString)
        {
            try
            {
                DateTime.Parse(dateString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidStringIds(string[] bookIds)
        {
            foreach(var id in bookIds)
            {
                if (!id.All(Char.IsDigit))
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsValidDataToBorrowBook(Dictionary<string, string> customerData, string dateString, string[] idsStringArray)
        {
            List<bool> validationResults = new List<bool>();
            validationResults.Add(IsValidStringIds(idsStringArray));
            validationResults.Add(IsValidCustomerData(customerData));
            validationResults.Add(IsValidDate(dateString));
            foreach (var result in validationResults)
            {
                if (result == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
