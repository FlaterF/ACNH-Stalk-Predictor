using StalkPredictor.Domain.PatternValidators.Provers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using StalkPredictor.Contracts;

namespace StalkPredictor.Domain.Tests.PatternValidators.Provers
{
    public class SpecificDayOutsidePercentageRangeProverTests
    {
        [Theory]
        [InlineData(new object[] { new int[] { 95, 100, 105 }, 0, 100, 110 })]
        [InlineData(new object[] { new int[] { 95, 100, 105 }, 2, 90, 100 })]
        public void ReturnsTrue_WhenSpecificDayOutsideRange(int[] buyPrices, int dayIndex, int lowerRange, int upperRange)
        {
            var data = GetBasicData(buyPrices);

            var prover = new SpecificDayOutsidePercentageRangeProver(dayIndex, lowerRange, upperRange);

            prover.MatchesFor(data).Should().BeTrue();
        }

        [Theory]
        [InlineData(new object[] { new int[] { 95, 100, 105 }, 0, 90, 95 })]
        [InlineData(new object[] { new int[] { 95, 100, 105 }, 2, 100, 105 })]
        public void ReturnsFalse_WhenSpecificDayInsideRange(int[] buyPrices, int dayIndex, int lowerRange, int upperRange)
        {
            var data = GetBasicData(buyPrices);

            var prover = new SpecificDayOutsidePercentageRangeProver(dayIndex, lowerRange, upperRange);

            prover.MatchesFor(data).Should().BeFalse();
        }

        [Theory]
        [InlineData(new object[] { new int[] { 95, 100, 105 }, 3, 90, 95 })]
        [InlineData(new object[] { new int[] { 95, 100, 105 }, 999, 100, 105 })]
        public void ReturnsFalse_WhenDayIndexHasNoPriceYet(int[] buyPrices, int dayIndex, int lowerRange, int upperRange)
        {
            var data = GetBasicData(buyPrices);

            var prover = new SpecificDayOutsidePercentageRangeProver(dayIndex, lowerRange, upperRange);

            prover.MatchesFor(data).Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalse_WhenNoBuyPrices()
        {
            var data = GetBasicData(new int[] { });

            var prover = new SpecificDayOutsidePercentageRangeProver(0, 95, 105);

            prover.MatchesFor(data).Should().BeFalse();
        }

        private CurrentWeekData GetBasicData(int[] prices)
        {
            // When daisyMaeSellPrice == 100, then a day's nookBuyPrice is equal to its sell percentage. Keeps things easy.
            return new CurrentWeekData(100, prices);
        }
    }
}
