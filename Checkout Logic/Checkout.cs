using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout_Logic
{
    public class Checkout
    {
        public decimal Total { get; set; }

        private Dictionary<string, int> itemScanCountDictionary;

        public Checkout()
        {
            Total = 0;
            itemScanCountDictionary = new Dictionary<string, int>();
        }

        public void Scan(Item item)
        {
            if (itemScanCountDictionary.ContainsKey(item.SDK))
            {
                itemScanCountDictionary[item.SDK]++;
            }
            else
            {
                itemScanCountDictionary.Add(item.SDK, 1);
            }

            if (item.PromoQuant > 0 && item.PromoType == "Total" && itemScanCountDictionary[item.SDK] == item.PromoQuant)
            {
                decimal discount = (item.Price * item.PromoQuant) - item.PromoTotal;

                Total -= discount;

                itemScanCountDictionary[item.SDK] = 0;
            }


            if (item.PromoQuant > 0 && item.PromoType == "Percentage" && itemScanCountDictionary[item.SDK] == item.PromoQuant)
            {
                decimal discount = item.Price * item.PromoQuant * item.PromoPercent;

                Total -= discount;

                itemScanCountDictionary[item.SDK] = 0;
            }

            Total += item.Price;
        }
    }
}
