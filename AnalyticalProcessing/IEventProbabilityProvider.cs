using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS.AnalyticalProcessing
{
    public interface IEventProbabilityProvider
    {
        double GetEventProbability(int eventIndex);
    }
}
