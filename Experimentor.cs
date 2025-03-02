using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS
{
    static class Experimentor
    {
        static Random random = new Random();

        static public double Experiment(int number, Graph graph)
        {
            int count;// = graphCopy.Count();
            int succeed = 0;
            double chance;
            //PathSearcher pathSearcher = new PathSearcher();
            for (int i = 0; i < number; i++)
            {
                Graph graphCopy = graph.Copy();
                count = graphCopy.GetNodes().Count;
                for (int j = 0; j < count; j++)
                {
                    chance = graphCopy.GetNodes().ElementAt(j).Chance;
                    if (GetTrueByChance(chance))
                    {
                        if (graphCopy.ElementAt(j).IsStart) graphCopy.StartNode = null;
                        if (graphCopy.ElementAt(j).IsEnd) graphCopy.EndNode = null;
                        graphCopy.DeleteNode(j);
                        j--;
                        count--;
                    }
                }
                if (PathSearcher.PathExictanceCheck(graphCopy))
                {
                    succeed++;
                }
            }
            double result = (double)succeed / number;
            return result;
        }


        static private bool GetTrueByChance(double chance)
        {
            double rnd = random.NextDouble();
            if (rnd >= chance) return true;
            else return false;
        }

    }
}
