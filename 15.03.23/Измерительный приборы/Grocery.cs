using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Grocery:Stock
    {
        string expiratioDate;

        public string ExpiratioDate { get { return expiratioDate; } set { expiratioDate = value; } }
        public Grocery(string name, string provider, int count, double price, string expirationDate) : base(name, provider, count, price)
        {
            this.expiratioDate = expirationDate;
        }

        override public string GetInfo()
        {
            return base.GetInfo() + "\n" + $"срок годности: {expiratioDate}";
        }
    }
}
