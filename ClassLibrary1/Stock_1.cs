using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Stock
    {
        private string name;
        private string provider;
        private int count;
        private double price;

        public string Name { get { return name; } set { name = value; } }
        public string Provider { get { return provider; } set { provider = value; } }
        public int Count { get { return count; } set { count = value; } }
        public double Price { get { return price; } set { price = value; } }

        public Stock(string name, string provider, int count, double price)
        {
            this.name = name;
            this.provider = provider;
            this.count = count;
            this.price = price;
        }

        public virtual string GetInfo()
        {
            return $"Название товара: {name}\nпоставщик: {provider}\nколичество товара: {count}\nстоимость товара: {price}";
        }
    }
}
