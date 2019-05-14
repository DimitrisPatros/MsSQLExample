using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }

        public Item(int id, string name, double price, int category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"Id:{Id}\nName:{Name}\nPrice:{Price}\nCategory{Category} ";
        }
    }
}
