using StalkPredictor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StalkPredictor.Domain.PatternValidators
{
    interface IProver
    {
        bool MatchesFor(CurrentWeekData data);
    }
}
