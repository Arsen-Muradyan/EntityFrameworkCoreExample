using Microsoft.EntityFrameworkCore;
namespace WebServer.Models
{
  public class BlogDbContext : DbContext
  {
    public BlogDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Post> Post { get; set; }
  }
  public class BlogDbContextFactory
  {
    public static BlogDbContext Create(string connectionString)
    {
      var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
      optionsBuilder.UseMySQL(connectionString);
      var blogDbContext = new BlogDbContext(optionsBuilder.Options);
      return blogDbContext;
    }
  }
}