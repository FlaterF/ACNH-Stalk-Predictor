using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StalkPredictor.Contracts
{
    public struct CurrentWeekData
    {
        public int DaisyMaeSellPrice { get; }
        public IEnumerable<int> NookBuyPrices { get; }

        public CurrentWeekData(int daisyMaeSellPrice, IEnumerable<int> nookBuyPrices)
        {
            this.DaisyMaeSellPrice = daisyMaeSellPrice;
            this.NookBuyPrices = nookBuyPrices;
        }
    }
}
