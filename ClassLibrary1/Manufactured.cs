using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Manufactured:Stock
    {
        int countInBox;
        bool fragile;

        public int CountInBox { get { return countInBox; } set { countInBox = value; } }
        public bool Fragile { get { return fragile; } set { fragile = value; } }
        public Manufactured(string name, string provider, int count, double price, int countInBox, bool fragile) : base(name, provider, count, price)
        {
            this.countInBox = countInBox;
            this.fragile = fragile;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + "\n" + $"кол-во в коробке: {countInBox}\nхрупкий: {fragile}";
        }
    }
}
