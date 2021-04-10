using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Messages
{
    public static class InstructionHelpers
    {
        public static string GetCommands()
        {
            string commands = "Type : " +
                "\n list   - to get all books from library " +
                "\n add    - to add a new book " +
                "\n delete - to remove the book from library " +
                "\n borrow - to borrow book from the library " +
                "\n return - to return book to the library " +
                "\n leave  - to leave the library" +
                "\n";
            return commands;
        }

        public static string GetAddNewBookInstructions()
        {
            string instructions = "Bellow you will see list of information to fill " +
                "in order to create a new book. Please enter valid data.";
            return instructions;
        }

        public static string[] GetBookFields()
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

        public static string GetDeleteBookInstruction()
        {
            string instructions = "Enter id of the book that you want to delete";
            return instructions;
        }

        public static string GetReturnBookInstruction()
        {
            string instructions = "Bellow you will see list of information to " +
                "fill in order to borrow a book.";
            return instructions;
        }

        public static string[] GetCustomerFields()
        {
            string[] customerData = {
                "Customer Name",
                "Customer Surname"
            };
            return customerData;
        }


        public static string GetIdsInstructions()
        {
            string instructions = "Enter id of the books you want to boorow. " +
                "Note that you cannot borrow more than 3 books. You have to enter id through \",\"";
            return instructions;
        }

        public static string GetReturnBookInstructions()
        {
            string instructions = "Enter id of the book that you want to return";
            return instructions;
        }
    }
}
