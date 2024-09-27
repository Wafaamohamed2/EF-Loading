using Microsoft.EntityFrameworkCore;
using NewEF;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        
        var _context = new ApplicationDbContext();


        // Eager Loading ----> effect on the performance because it retrieve all data of the related table 
        // Although you will not use all that data .... yoyu can include more than one table

        Console.WriteLine("--------- Eager Loading---------");
        var book = _context.Books.Include(b => b.Author).SingleOrDefault(b => b.Id==2);

        Console.WriteLine(book.Author.Name);


        //Explicit Loading -----> retrive the data of the main table
        //then retrieve data than we needed from the related table 
        Console.WriteLine("-------------Explicit Loading--------------");
        var book2 = _context.Books.SingleOrDefault(b => b.Id == 2);

        _context.Entry(book2).Reference(b => b.Author).Load();

        Console.WriteLine(book2.Author.Name);



        //Lazy Loading --------> retrieve  data of the related table after you access the navigation proprity frist

        Console.WriteLine("--------------Lazy Loading---------");
        var book3 = _context.Books.SingleOrDefault(book => book.Id == 2);
        Console.WriteLine(book.Author.Name);


    }
}