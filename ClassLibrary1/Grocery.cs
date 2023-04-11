using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Grocery:Stock
    {
        int expiratioDate;

        public int ExpiratioDate { get { return expiratioDate; } set { expiratioDate = value; } }
        public Grocery(string name, string provider, int count, double price, int expirationDate) : base(name, provider, count, price)
        {
            this.expiratioDate = expirationDate;
        }

        override public string GetInfo()
        {
            return base.GetInfo() + "\n" + $"срок годности: {expiratioDate}";
        }
    }
}
