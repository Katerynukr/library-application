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
        public bool IsValidBookName(Dictionary<string, string> userInput)
        {
            if (userInput["Name"] != null && userInput["Name"].Length > 1 && userInput["Name"].Length < 40)
            {
                //TODO: add trim to lower .Substring(0, 1).ToUpper();
                if (userInput["Name"].All(Char.IsLetter))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsValidAuthorName(Dictionary<string, string> userInput)
        {
            if (userInput["Author Name"] != null && userInput["Author Surname"] != null)
            {
                var isValidNameSurname = userInput["Author Name"].All(Char.IsLetter) && userInput["Author Surname"].All(Char.IsLetter) ? true : false;
                return isValidNameSurname;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidPublicationDate(Dictionary<string, string> userInput)
        {
            if (userInput["Publication Date"] != null)
            {
                try
                {
                    var year = int.Parse(userInput["Publication Date"]);
                    var isPastYear = year < 2021 && year > 800 ?  true : false;
                    return isPastYear;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsValidISBN(Dictionary<string, string> userInput)
        {
            if (userInput["ISBN"] != null && userInput["ISBN"].Length < 12)
            {
                var result = userInput["ISBN"].All(Char.IsDigit) ? true : false;
                return result;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidCategory(Dictionary<string, string> userInput)
        {
            if (userInput["Category"] != null)
            {
                List<string> categories = Enum.GetNames(typeof(Categories)).ToList();
                var isCategory = categories.Any(c => userInput["Category"].Contains(c));
                if (isCategory)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsValidLanguage(Dictionary<string, string> userInput)
        {
            if (userInput["Language"] != null)
            {
                List<string> languages = Enum.GetNames(typeof(Languages)).ToList();
                var isAvailableLanguage = languages.Any(c => userInput["Language"].Contains(c));
                if (isAvailableLanguage)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
