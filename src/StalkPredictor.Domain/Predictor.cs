using StalkPredictor.Contracts;
using StalkPredictor.Domain.PatternValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StalkPredictor.Domain
{
    public class Predictor : IPredictor
    {
        public IEnumerable<StalkPattern> GetPossibleStalkPatterns(CurrentWeekData data)
        {
            var validators = PatternValidatorFactory.GetPatternValidators();

            // Look for a proven pattern

            if(OnePatternIsProven(data, validators, out StalkPattern? pattern))
            {
                return new StalkPattern[] { pattern.Value };
            }

            // Get all possible patterns

            IEnumerable<StalkPattern> possibleStalkPatterns = Enum.GetValues(typeof(StalkPattern)).Cast<StalkPattern>().ToList();

            // Subtract any disproven patterns

            var disprovenPatterns = validators
                                        .Where(validator => validator.IsDisprovenFor(data))
                                        .Select(validator => validator.Pattern);

            return possibleStalkPatterns.Except(disprovenPatterns);
        }

        private bool OnePatternIsProven(CurrentWeekData data, IEnumerable<PatternValidator> validators, out StalkPattern? provenPattern)
        {
            try
            {
                var provenValidator = validators.SingleOrDefault(validator => validator.IsProvenFor(data));

                provenPattern = provenValidator?.Pattern;

                return provenValidator != null;
            }
            catch (InvalidOperationException)
            {
                // More than one validator claims to be proven, that's impossible!

                var provenValidatorPatterns = validators
                                                .Where(validator => validator.IsProvenFor(data))
                                                .Select(validator => validator.Pattern);
                var names = String.Join(", ", provenValidatorPatterns);

                throw new Exception($"More than one pattern is proven! (${names})");
            }
        }
    }
}
