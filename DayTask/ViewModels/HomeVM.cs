using DayTask.Models;
using System.Collections.Generic;

namespace DayTask.ViewModels
{
    public class HomeVM
    {
        public List<Category> Categories{ get; set; }
        public List<Product> Products { get; set; }
    }
}
