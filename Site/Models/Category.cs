﻿namespace Site.Models
{
    public class Category
    {
        public string Name { get; set; }
        public ICollection<ProductInputModel> Products { get; set; }

    }
}
