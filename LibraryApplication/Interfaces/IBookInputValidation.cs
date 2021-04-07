using System.Collections.Generic;

namespace LibraryApplication.Interfaces
{
    public interface IBookInputValidation
    {
        bool IsValidAuthorName(Dictionary<string, string> userInput);
        bool IsValidBookName(Dictionary<string, string> userInput);
        bool IsValidCategory(Dictionary<string, string> userInput);
        bool IsValidISBN(Dictionary<string, string> userInput);
        bool IsValidPublicationDate(Dictionary<string, string> userInput);
    }
}