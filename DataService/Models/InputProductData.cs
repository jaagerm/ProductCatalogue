using System;
using System.Collections.Generic;
using System.Text;
using DataService.Domain.Products;

namespace DataService.Models
{
    public class InputProductData
    {
        public string EmployeeId { get; set; }
        public Product[] Products { get; set; }
    }
}
