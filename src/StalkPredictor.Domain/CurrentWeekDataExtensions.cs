using StalkPredictor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StalkPredictor.Domain
{
    public static class CurrentWeekDataExtensions
    {
        public static IEnumerable<float> GetPercentages(this CurrentWeekData data)
        {
            return data.NookBuyPrices.Select(buyPrice => (float)(buyPrice * 100) / data.DaisyMaeSellPrice);
        }
    }
}
