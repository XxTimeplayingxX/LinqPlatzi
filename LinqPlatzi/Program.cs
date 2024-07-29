using LinqPlatzi;
using System.Dynamic;

LinqQueries queries = new LinqQueries();

//Toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//ImprimirValores(queries.LibrosDespuesDel2000());

//Todos Los libros tienen status
//Console.WriteLine($"¿Todos los libros tienen status? \n{queries.TodosLosLibrosTienenStatus()}");

//Console.WriteLine($"¿Algún libro fue publicado en el año 2005? \n{queries.Libros2005()}");

ImprimirValores(queries.Primeros3LibrosJava());
void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 11}\n", "Título", "N. Páginas", "Fecha publicación");
    foreach (var item in listaDeLibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}