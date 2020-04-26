using StalkPredictor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StalkPredictor.Domain.PatternValidators
{
    class PatternValidator
    {
        public StalkPattern Pattern { get; private set; }
        
        private readonly IEnumerable<IProver> Disprovers;
        private readonly IEnumerable<IProver> Provers;

        public PatternValidator(StalkPattern pattern, IEnumerable<IProver> provers, IEnumerable<IProver> disprovers)
        {
            this.Pattern = pattern;
            this.Provers = provers;
            this.Disprovers = disprovers;
        }

        public bool IsProvenFor(CurrentWeekData data) => Provers.Any(prover => prover.MatchesFor(data));
        public bool IsDisprovenFor(CurrentWeekData data) => Disprovers.Any(disprover => disprover.MatchesFor(data));
        public bool IsPossibleFor(CurrentWeekData data) => !IsProvenFor(data) && !IsDisprovenFor(data);
    }
}
