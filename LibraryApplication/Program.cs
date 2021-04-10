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
            UIService userInteractionService = new UIService();
            bool isContinue = true;
            while (isContinue)
            {
                userInteractionService.DisplayCommands();
                var userCommand = userInteractionService.ReadCommands();
                switch (userCommand)
                {
                    case "list":
                        userInteractionService.GenerateBooksList();
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
                    case "leave":
                        isContinue = false;
                        userInteractionService.ExitLibrary();
                        break;
                }
            }
        }
    }
}
