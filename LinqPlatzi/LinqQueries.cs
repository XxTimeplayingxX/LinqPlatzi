using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlatzi
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();
        public LinqQueries()
        {
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }
        public IEnumerable<Book> LibrosDespuesDel2000()
        {
            //Extension Method
            //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

            //Query Expression
            return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
        }
        public IEnumerable<Book> LibrosInAction()
        {
            //Extension Method
            //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

            return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
        }
        public bool TodosLosLibrosTienenStatus()
        {
            //Extension Method
            return librosCollection.All(l => l.Status != string.Empty);
        }
        public bool Libros2005()
        {
            return librosCollection.Any(l => l.PublishedDate.Year == 2005);
        }
        public IEnumerable<Book> LibrosCategoriaPython()
        {
            return librosCollection.Where(l => l.Categories.Contains("Python", StringComparer.CurrentCultureIgnoreCase));
        }
        public IEnumerable<Book> LibrosCategoriaJava()
        {
            return librosCollection.Where(l => l.Categories.Contains("Java")).OrderByDescending(p => p.Title);
        }
        public IEnumerable<Book> Libros450PaginasDescending()
        {
            return librosCollection.Where(l => l.PageCount > 450).OrderByDescending(l => l.PageCount);
        }
        public IEnumerable<Book> Primeros3LibrosJava()
        {
            return librosCollection.Where(l => l.Categories.Contains("Java")).OrderBy(l => l.PublishedDate.Year).Take(3);
        }
    }
    
}
