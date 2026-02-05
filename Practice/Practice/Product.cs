using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice
{
   public class Product
   {
        private string name;
        private double price;
        private Category category;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {

                if (value <= 0)
                {
                    Console.WriteLine("Invalid Price");
                }
                else
                {
                     price = value;
                }
            }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }



        public Product(string name , double price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        
       public Location PLocation { get; set; }
    }
}
