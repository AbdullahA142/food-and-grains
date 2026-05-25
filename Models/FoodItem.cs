using System;

namespace Food_and_Grains.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public string ImagePath { get; set; }
        public DateTime AddedDate { get; set; }

        public string Description { get; set; }
    }
}