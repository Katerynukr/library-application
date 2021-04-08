using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class Book
    {
        private static int NextId { get; set; } = 1;
        public int Id { get; private set; } = 0;
        public string Name { get; set; }
        public Author Author { get; set; }
        public Categories Category{ get; set; }
        public Languages Language { get; set; }
        public int PublicationDate { get; set; }
        public string ISBN { get; set; }
        public Customer Customer { get; set; }
        public bool IsTaken = false;
        public Book()
        {
            Id = NextId;
            NextId++;
        }

    }
}
