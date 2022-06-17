using System.Collections.Generic;

namespace DayTask.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CatName { get; set; }
        public List<Product> Products { get; set; }
    }
}
