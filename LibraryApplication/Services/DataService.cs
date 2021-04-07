using LibraryApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class DataService
    {
        public IEnumerable<Book> books {get; set;}
        private string path = "Data\\BooksList.json";
        public IEnumerable<Book> ParseFromJsonFile()
        {
            if (this.path != null)
            {
                using (StreamReader r = new StreamReader(this.path))
                {
                    string json = r.ReadToEnd();
                    books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
                    return books;
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        public void ParseToJsonFile(IEnumerable<Book> newBooksList)
        {
            if (this.path != null && newBooksList != null)
            {
                using (StreamWriter file = File.CreateText(this.path))
{
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, newBooksList);
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
