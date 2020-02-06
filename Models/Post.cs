using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebServer.Models
{
  public class Post
  {
    [Key, Column("post_id")]
    public int ID { get; set; }
    [Column("title")]
    public string title { get; set; }
    [Column("body", TypeName = "text")]
    public string body { get; set; }
  }
}