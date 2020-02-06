using Microsoft.AspNetCore.Mvc;
using WebServer.Models;
using System.Linq;
namespace WebServer.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PostsController : ControllerBase
  {
    private BlogDbContext dbContext;
    public PostsController()
    {
      string connectionString = "server=localhost;port=3306;database=blog;userid=arsen;pwd=Strong123S#;sslmode=none";
      dbContext = BlogDbContextFactory.Create(connectionString);
    }
    [HttpGet]
    public ActionResult Get()
    {
      return Ok(dbContext.Post.ToArray());
    }
    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
      var target = dbContext.Post.SingleOrDefault(p => p.ID == id);
      if (target != null)
      {
        return Ok(target);
      }
      else
      {
        return NotFound();
      }
    }
    [HttpPost]
    public ActionResult Post([FromBody]Post post)
    {
      if (!ModelState.IsValid) return BadRequest();
      dbContext.Post.Add(post);
      dbContext.SaveChanges();
      return Created("/api/posts", post);
    }
    [HttpPut("{id}")]
    public ActionResult Put([FromBody]Post post, int id)
    {
      var target = dbContext.Post.SingleOrDefault(p => p.ID == id);
      if (target != null && ModelState.IsValid)
      {
        dbContext.Entry(target).CurrentValues.SetValues(post);
        dbContext.SaveChanges();
        return Ok();
      }
      else
      {
        return BadRequest();
      }
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {

      var target = dbContext.Post.SingleOrDefault(p => p.ID == id);
      if (target != null)
      {
        dbContext.Post.Remove(target);
        dbContext.SaveChanges();
        return Ok();
      }
      else
      {
        return NotFound();
      }
    }
  }
}