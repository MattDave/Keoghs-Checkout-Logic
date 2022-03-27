using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout_Logic
{
    public class Item
    {
        public string SDK { get; }
        public decimal Price { get; }
        public string PromoType { get; }
        public int PromoQuant { get; }
        public decimal PromoTotal { get; }
        public decimal PromoPercent { get; }

        public Item(string sdk, decimal price, string promoType, int promoQuant, decimal promoTotal, decimal promoPercent)
        {
            SDK = sdk;
            Price = price;
            PromoType = promoType;
            PromoQuant = promoQuant;
            PromoTotal = promoTotal;
            PromoPercent = promoPercent;
        }
    }
}
