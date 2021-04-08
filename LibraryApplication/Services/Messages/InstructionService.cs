using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services.Messages
{
    public class InstructionService
    {
        public string ReturnAvailableCommands()
        {
            string commands = "Type : " +
                "\n list   - to get all books from library " +
                "\n add    - to add a new book " +
                "\n delete - to remove the book from library " +
                "\n borrow - to borrow book from the library " +
                "\n return - to return book to the library" +
                "\n";
            return commands;
        }

        public string RerturnInstructionsToAddNewBook()
        {
            string instructions = "Bellow you will see list of information to fill " +
                "in order to create a new book. Please enter valid data.";
            return instructions;
        }

        public string[] ReturnDataFieldsToCreateBook()
        {
            string[] dataFieldsToCreateBook = {
                "Book Title",
                "Author Name",
                "Author Surname",
                "Category",
                "ISBN",
                "Language",
                "Publication Year"
            };
            return dataFieldsToCreateBook;
        }

        public string ReturnInstructionsToDeleteBook()
        {
            string instructions = "Enter id of the book that you want to delete";
            return instructions;
        }

        public string ReturnInstructionsToBorrowBook()
        {
            string instructions = "Bellow you will see list of information to " +
                "fill in order to borrow a book.";
            return instructions;
        }

        public string[] ReturnCustomerFieldsToCreateCustomer()
        {
            string[] customerData = {
                "Customer Name",
                "Customer Surname"
            };
            return customerData;
        }

        public string ReturnEstimatedReturnDateInstructions()
        {
            string instructions = "Enter date when you plan to return a book." +
                " Note you cannot take book for longer than two month. " +
                "\n dd/mm/yyy";
            return instructions;
        }

        public string ReturnInstructionsForIdsOfBooks()
        {
            string instructions = "Enter id of the books you want to boorow. " +
                "Note that you cannot borrow more than 3 books. You have to enter id through \",\"";
            return instructions;
        }

        public string ReturnInstructionsToReturnBook()
        {
            string instructions = "Enter id of the book that you want to return";
            return instructions;
        }
    }
}
