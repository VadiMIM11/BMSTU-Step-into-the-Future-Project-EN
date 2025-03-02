using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS.AnalyticalProcessing
{
    class GraphEventProbabilityProvider : IEventProbabilityProvider
    {
        private Graph _graph;
        public GraphEventProbabilityProvider(Graph graph)
        {
            _graph = graph;
        }
        public double GetEventProbability(int eventIndex)
        {
            var list = _graph.GetNodes();
            Node node = list[eventIndex];
            return node.Chance;
        }
    }
}
