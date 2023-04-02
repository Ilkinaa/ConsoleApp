using BoltFood.Core.Enums;
using BoltFood.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Restaraunt : BaseModel
    {
        private static int _id;
        public RestarauntCategory restarauntcategory {  get; set; }
        public List<Product> products;
        public Product Product { get; set; }
        public Restaraunt(string name ,RestarauntCategory restarauntCategory)
            
        {
            _id++;
            Id = _id; 
            products = new List<Product>();
            restarauntcategory = restarauntCategory;
            Name= name;
            

        }


    }
}
