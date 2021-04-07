using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class Book
    {
        public int Id { get; } = 0;
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
            this.Id++;
        }

    }
}
