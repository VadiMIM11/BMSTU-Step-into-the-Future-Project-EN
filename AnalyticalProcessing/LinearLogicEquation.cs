using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS.AnalyticalProcessing
{
    class LinearLogicEquation
    {
        private List<List<int>> conjunctionList = null;

        public LinearLogicEquation(List<List<int>> conjunctionList)
        {
            this.conjunctionList = new List<List<int>>();
            for (int i = 0; i < conjunctionList.Count; i++)
            {
                List<int> disjunction = conjunctionList[i];
                List<int> disjunctionClone = new List<int>();

                for (int j = 0; j < disjunction.Count; j++)
                {
                    disjunctionClone.Add(disjunction[j]);
                }

                this.conjunctionList.Add(disjunctionClone);
            }
        }

        public double GetProbability(IEventProbabilityProvider provider)
        {
            double probabilitySumm = 0;
            for (int i = 0; i < conjunctionList.Count; i++)
            {
                double probabilityMult = 1;
                List<int> disjunction = conjunctionList[i];
                for (int j = 0; j < disjunction.Count; j++)
                {
                    int nodeKey = disjunction[j];
                    double mult;
                    if (nodeKey < 0)
                    {
                        mult = 1 - provider.GetEventProbability(-nodeKey);
                    }
                    else
                    {
                        mult = provider.GetEventProbability(nodeKey);
                    }

                    probabilityMult *= mult;
                }

                probabilitySumm += probabilityMult;
            }

            return probabilitySumm;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < conjunctionList.Count; i++)
            {
                List<int> operand = conjunctionList[i];
                for (int j = 0; j < operand.Count; j++)
                {
                    int eventIndex = operand[j];
                    char symbol = (char) (Math.Abs(eventIndex) + 0x41);
                    if (eventIndex < 0)
                    {
                        builder.Append('-');
                    }

                    builder.Append(symbol);
                }

                if (i < conjunctionList.Count - 1)
                    builder.Append(" + ");
            }

            return builder.ToString();
        }
    }
}