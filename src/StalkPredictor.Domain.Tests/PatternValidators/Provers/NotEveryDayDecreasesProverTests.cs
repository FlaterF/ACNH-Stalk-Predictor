using FluentAssertions;
using StalkPredictor.Contracts;
using StalkPredictor.Domain.PatternValidators.Provers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StalkPredictor.Domain.Tests.PatternValidators.Provers
{
    public class NotEveryDayDecreasesProverTests
    {
        [Theory]
        [InlineData(new object[] { new int[] { 5, 4, 3, 2, 1 }})]
        [InlineData(new object[] { new int[] { 5 }})]
        public void ReturnsFalse_IfPricesAlwaysDecrease(int[] buyPrices)
        {
            var data = GetBasicData(buyPrices);

            var prover = new NotEveryDayDecreasesProver();

            prover.MatchesFor(data).Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalse_IfNoBuyPrices()
        {
            var data = GetBasicData(new int[] { });

            var prover = new NotEveryDayDecreasesProver();

            prover.MatchesFor(data).Should().BeFalse();
        }

        [Theory]
        [InlineData(new object[] { new int[] { 5, 4, 3, 2, 3 } })]
        public void ReturnsTrue_IfAPriceIncreaseOccurs(int[] buyPrices)
        {
            var data = GetBasicData(buyPrices);

            var prover = new NotEveryDayDecreasesProver();

            prover.MatchesFor(data).Should().BeTrue();
        }

        [Theory]
        [InlineData(new object[] { new int[] { 5, 4, 3, 2, 2 } })]
        public void ReturnsTrue_IfAPriceStaysTheSame(int[] buyPrices)
        {
            var data = GetBasicData(buyPrices);

            var prover = new NotEveryDayDecreasesProver();

            prover.MatchesFor(data).Should().BeTrue();
        }

        private CurrentWeekData GetBasicData(int[] prices)
        {
            // When daisyMaeSellPrice == 100, then a day's nookBuyPrice is equal to its sell percentage. Keeps things easy.
            return new CurrentWeekData(100, prices);
        }
    }
}
