using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StalkPredictor.Contracts;

namespace StalkPredictor.Domain.PatternValidators.Provers
{
    public class NotEveryDayDecreasesProver : IProver
    {
        public bool MatchesFor(CurrentWeekData data)
        {
            var priceChanges =
                    data.NookBuyPrices
                            .Zip(data.NookBuyPrices.Skip(1), (first, second) => second - first);

            var everyDayDecreases = priceChanges.All(priceChange => priceChange < 0);

            return !everyDayDecreases;
        }
    }
}
