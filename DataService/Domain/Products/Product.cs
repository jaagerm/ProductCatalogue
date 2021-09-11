using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Domain.Products
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int Quantity { get; set; }
    }
}
