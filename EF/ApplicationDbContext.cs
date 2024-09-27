

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEF
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>

            options.UseLazyLoadingProxies().UseSqlServer(@"Data Source=WAFAA;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Stock> Stock { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }
    }


   

    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }

        public string Title { get; set; }   

        public string Content { get; set; }
        public virtual Blog Blog { get; set; }



    }
    
    public class Blog 
    {
        public int BlogId { get; set; }

        public string Url { get; set; }

        public DateTime AddOn { get; set; }

        [InverseProperty(nameof(Post.Blog))]
        public virtual ICollection<Post> Posts { get; set; }   

    }
    public class Stock
    {
        public int id { get;  set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

       
        public string gender { get; set; }
    }
    
    public class Book {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        [Required, MaxLength(255)]  
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
        public int? NationalityId { get; set; }

        public virtual Nationality Nationality { get; set; }

    }

    public class Nationality
    {
        public int NationalityId { get; set; }
        public string Name { get; set; }

    }
}
