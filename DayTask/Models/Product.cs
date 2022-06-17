using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Des { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Link { get; set; }
        public int CategoryId { get; set; }
        public Category Category{ get; set; }
    }
}
