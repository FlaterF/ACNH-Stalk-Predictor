using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StalkPredictor.Contracts;

namespace StalkPredictor.Domain.PatternValidators.Provers
{
    public class AnyDayOutsidePercentageRangeProver : IProver
    {
        private readonly float lower;
        private readonly float upper;

        public AnyDayOutsidePercentageRangeProver(float lower, float upper)
        {
            this.lower = lower;
            this.upper = upper;
        }

        public bool MatchesFor(CurrentWeekData data)
        {
            return data.GetPercentages().Any(percentage => percentage < lower || percentage > upper);
        }
    }
}
