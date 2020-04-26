using System;
using System.Collections.Generic;
using System.Text;

namespace StalkPredictor.Contracts
{
    public interface IPredictor
    {
        IEnumerable<StalkPattern> GetPossibleStalkPatterns(CurrentWeekData data);
    }
}
