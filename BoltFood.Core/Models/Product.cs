using BoltFood.Core.Enums;
using BoltFood.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Product: BaseModel
    {
        private static int _id;
        public double Price { get; set; }
        public Restaraunt Restaraunt { get; set; }
        public ProductCategory productCategory { get; set; }
        public Product(string name,double price,Restaraunt restaraunt, ProductCategory ProductCategory)
        {
            _id++;
            Id = _id;
            Price = price;
            Name = name;
            Restaraunt = restaraunt;
            productCategory = ProductCategory;
           

        }
    }
}
