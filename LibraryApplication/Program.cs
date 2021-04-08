using LibraryApplication.Interfaces;
using LibraryApplication.Loggers;
using LibraryApplication.Services;
using System;

namespace LibraryApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            UIService userInteractionService = new UIService(logger);
            while (true)
            {
                var userCommand = userInteractionService.DisplayListOfCommands();
                switch (userCommand)
                {
                    case "list":
                        userInteractionService.GenerateListOfBooks();
                        break;
                    case "add":
                        userInteractionService.AddNewBook();
                        break;
                    case "delete":
                        userInteractionService.DeleteBook();
                        break;
                    case "borrow":
                        userInteractionService.BorrowBook();
                        break;
                    case "return":
                        userInteractionService.ReturnBook();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
