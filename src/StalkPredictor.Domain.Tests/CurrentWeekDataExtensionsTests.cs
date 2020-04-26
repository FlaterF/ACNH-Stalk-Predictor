using StalkPredictor.Contracts;
using System;
using System.Collections.Generic;
using Xunit;
using StalkPredictor.Domain;
using FluentAssertions;

namespace StalkPredictor.Domain.Tests
{
    public class CurrentWeekDataExtensionsTests
    {
        [Theory]
        [InlineData(new object[] { 50, new int[] { 45, 50, 60 } , new float[] { 90, 100, 120 } })]
        [InlineData(new object[] { 100, new int[] { 90, 100, 120 } , new float[] { 90, 100, 120 } })]
        public void Calculates_correct_percentages(int daisyMaeSellPrice, int[] nookBuyPrices, float[] expected)
        {
            var exampleData = new CurrentWeekData(daisyMaeSellPrice, nookBuyPrices);

            var actual = exampleData.GetPercentages();

            actual.Should().ContainInOrder(expected);
        }
    }
}
