using System;
using System.Collections.Generic;
using System.Text;
using StalkPredictor.Domain.PatternValidators.Provers;

namespace StalkPredictor.Domain.PatternValidators
{
    static class PatternValidatorFactory
    {
        public static IEnumerable<PatternValidator> GetPatternValidators()
        {
            return new PatternValidator[] { Random, Decreasing, SmallSpike, LargeSpike };
        }

        private static PatternValidator Random =>
            new PatternValidator(
                Contracts.StalkPattern.Random,
                provers: new IProver[]
                {

                },
                disprovers: new IProver[]
                {
                    new AnyDayOutsidePercentageRangeProver(90, 140)
                });

        private static PatternValidator Decreasing =>
            new PatternValidator(
                Contracts.StalkPattern.Decreasing,
                provers: new IProver[]
                {

                },
                disprovers: new IProver[]
                {
                    new SpecificDayOutsidePercentageRangeProver(0, 85, 90),
                    new NotEveryDayDecreasesProver()
                });

        private static PatternValidator SmallSpike =>
            new PatternValidator(
                Contracts.StalkPattern.SmallSpike,
                provers: new IProver[]
                {

                },
                disprovers: new IProver[]
                {
                    new SpecificDayOutsidePercentageRangeProver(0, 40, 90)
                });

        private static PatternValidator LargeSpike =>
            new PatternValidator(
                Contracts.StalkPattern.LargeSpike,
                provers: new IProver[]
                {
                    new AnyDayOutsidePercentageRangeProver(0,200)
                },
                disprovers: new IProver[]
                {
                    new SpecificDayOutsidePercentageRangeProver(0, 85, 90)
                });
    }
}
