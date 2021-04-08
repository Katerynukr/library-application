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
        private const string path = @"Data\BooksList.json";
        public IEnumerable<Book> ParseFromJsonFile()
        {
            if (path != null)
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    IEnumerable<Book> books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
                    return books;
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        public void ParseToJsonFile(List<Book> newBooksList)
        {
            if (path != null && newBooksList != null)
            {
                //TODO:HOW TOWRITE
                File.WriteAllText(@"C:\Users\kater\Documents\dot-net\LibraryApplication\LibraryApplication\Data\BooksList.json", JsonConvert.SerializeObject(newBooksList));
                /* using (StreamWriter file = File.CreateText(path))
 {
                     JsonSerializer serializer = new JsonSerializer();
                     serializer.Serialize(file, newBooksList);
                 }*/
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
