using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StalkPredictor.Contracts;

namespace StalkPredictor.Domain.PatternValidators.Provers
{
    public class SpecificDayOutsidePercentageRangeProver : IProver
    {
        private readonly float lower;
        private readonly float upper;
        private readonly int dayIndex;

        public SpecificDayOutsidePercentageRangeProver(int dayIndex, float lower, float upper)
        {
            this.dayIndex = dayIndex;
            this.lower = lower;
            this.upper = upper;
        }

        public bool MatchesFor(CurrentWeekData data)
        {
            if (data.NookBuyPrices.Count() < dayIndex + 1)
                return false;

            var specificPercentage = data.GetPercentages().ElementAt(dayIndex);

            return specificPercentage < lower || specificPercentage > upper;
        }
    }
}
