using FluentAssertions;
using StalkPredictor.Contracts;
using StalkPredictor.Domain.PatternValidators.Provers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StalkPredictor.Domain.Tests.PatternValidators.Provers
{
    public class AnyDayOutsidePercentageRangeProverTests
    {
        [Theory]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5 }, 1, 4 })]
        [InlineData(new object[] { new int[] { 100 }, 1, 4 })]
        public void ReturnsTrue_IfAnyValueOutsideRange(int[] buyPrices, int lowerRange, int upperRange)
        {
            var data = GetBasicData(buyPrices);

            var prover = new AnyDayOutsidePercentageRangeProver(lowerRange, upperRange);

            prover.MatchesFor(data).Should().BeTrue();
        }

        [Theory]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4 }, 1, 4 })]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5 }, 1, 5 })]
        [InlineData(new object[] { new int[] { 100 }, 99, 101 })]
        public void ReturnsFalse_IfAllValuesInRange(int[] buyPrices, int lowerRange, int upperRange)
        {
            var data = GetBasicData(buyPrices);

            var prover = new AnyDayOutsidePercentageRangeProver(lowerRange, upperRange);

            prover.MatchesFor(data).Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalse_IfNoBuyPrices()
        {
            var data = GetBasicData(new int[] { });

            var prover = new AnyDayOutsidePercentageRangeProver(0, 100);

            prover.MatchesFor(data).Should().BeFalse();
        }

        private CurrentWeekData GetBasicData(int[] prices)
        {
            // When daisyMaeSellPrice == 100, then a day's nookBuyPrice is equal to its sell percentage. Keeps things easy.
            return new CurrentWeekData(100, prices);
        }
    }
}
