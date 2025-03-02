using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS.AnalyticalProcessing
{
    public static class AnalyticalProcessor
    {
        private static void CopyListContents<T>(List<T> source, List<T> clone)
        {
            for (int i = 0; i < source.Count; i++)
            {
                clone.Add(source[i]);
            }
        }

        private enum SetComparisonResult
        {
            Less = -1,
            Equal = 0,
            Greater = 1,
            Uncomparable = 2
        }

        private static bool IsSubset<T>(IList<T> set1, IList<T> set2)
        {
            for (int i = 0; i < set1.Count; i++)
            {
                T value = set1[i];
                if (!set2.Contains(value))
                {
                    return false;
                }
            }

            return true;
        }

        private static SetComparisonResult ComparePaths(Path path1, Path path2)
        {
            bool isSubset12 = IsSubset(path1, path2);

            bool isSubset21 = IsSubset(path2, path1);


            if (isSubset12)
            {
                return SetComparisonResult.Less;
            }
            else if (isSubset12 && isSubset21)
            {
                return SetComparisonResult.Equal;
            }
            else if (isSubset21)
            {
                return SetComparisonResult.Greater;
            }
            else
            {
                return SetComparisonResult.Uncomparable;
            }
        }

        private static void RemoveComplexPaths(List<Path> pathList)
        {
            for (int i = 0; i < pathList.Count; i++)
            {
                Path current = pathList[i];
                for (int j = i + 1; j < pathList.Count; j++)
                {
                    Path comparable = pathList[j];
                    SetComparisonResult comparisonResult = ComparePaths(current, comparable);

                    if (comparisonResult == SetComparisonResult.Less)
                    {
                        pathList.RemoveAt(j);
                        j--;
                    }
                    else if (comparisonResult == SetComparisonResult.Equal)
                    {
                        // This must not happen!
                        pathList.RemoveAt(i);
                        i--;
                        break;
                    }
                    else if (comparisonResult == SetComparisonResult.Greater)
                    {
                        pathList.RemoveAt(i);
                        i--;
                        break;
                    }
                    else
                    {
                        // Uncomparible, do nothing
                    }
                }
            }
        }

        private static void SortedInsertUnique(List<int> nodeIndexList, int value)
        {
            if (nodeIndexList.Count == 0)
            {
                nodeIndexList.Add(value);
                return;
            }

            int index = 0;
            while (index < nodeIndexList.Count)
            {
                int valueAt = nodeIndexList[index];
                int comparison = value - valueAt;
                if (comparison > 0)
                {
                    index++;
                }
                else if (comparison < 0)
                {
                    break;
                }
                else
                {
                    return;
                }
            }
            nodeIndexList.Insert(index, value);
        }

        private static void GetNodeSet(List<Path> pathList, List<int> nodeIndexList)
        {
            for (int i = 0; i < pathList.Count; i++)
            {
                Path path = pathList[i];
                for (int j = 0; j < path.Count; j++)
                {
                    Node node = path[j];
                    int nodeKey = node.GetIndex();
                    SortedInsertUnique(nodeIndexList, nodeKey);
                }
            }
        }

        private static void GetPathMask(Path path, out UInt64 pathMask)
        {
            pathMask = 0;
            for (int i = 0; i < path.Count; i++)
            {
                var node = path[i];
                pathMask |= (1UL << node.GetIndex());
            }
        }

        private static void GetPathMasks(List<Path> pathList, UInt64[] pathMasks)
        {
            for (int i = 0; i < pathList.Count; i++)
            {
                Path path = pathList[i];
                UInt64 mask;
                GetPathMask(path, out mask);
                pathMasks[i] = mask;
            }
        }

        private static void GetPresentMissingNodes(UInt64 mask, List<int> nodeIndexList, List<int> presentNodes, List<int> missingNodes)
        {
            for (int i = 0; i < nodeIndexList.Count; i++)
            {
                int nodeIndex = (int)nodeIndexList[i];
                if ((mask & (1UL << nodeIndex)) != 0)
                {
                    presentNodes.Add(nodeIndex);
                }
                else if (missingNodes != null)
                {
                    missingNodes.Add(nodeIndex);
                }
            }
        }

        private static void AppendInvertedNodes(List<int> source, List<int> target)
        {
            for (int i = 0; i < source.Count; i++)
            {
                int nodeKey = source[i];
                target.Add(-nodeKey);
            }
        }

        private static UInt64 GetMaskFromMissingNodesCombination(UInt64 baseMask, List<int> missingNodes, UInt64 combination)
        {
            //int bit0 = baseMask & (1 << 0);
            //int bit1 = baseMask & (1 << 1);
            for (int i = 0; i < missingNodes.Count; i++)
            {
                if ((combination & 1UL << i) != 0)
                {
                    baseMask |= (1UL << missingNodes[i]);
                }
            }

            return baseMask;
        }

        private static bool HasNewZeros(UInt64 a, UInt64 b)
        {
            UInt64 mask = ~(~a | b);
            return mask != 0;
        }

        private static bool IsSuperset(UInt64 mask, UInt64 possibleSuperset)
        {
            return !HasNewZeros(mask, possibleSuperset);
        }

        private static int FindSubsetIndex(List<UInt64> subsetList, UInt64 mask)
        {
            for (int i = 0; i < subsetList.Count; i++)
            {
                UInt64 possibleSubset = subsetList[i];
                bool isSuperset = IsSuperset(possibleSubset, mask);
                if (isSuperset)
                {
                    return i;
                }
            }

            return -1;
        }

        private static UInt64 SkipSubsetCombinations(UInt64 combination)
        {
            UInt64 mask = 1;
            while ((combination & mask) == 0)
            {
                mask <<= 1;
            }
            return combination + mask;
        }

        private static void AppendNodesByMask(List<int> source, List<int> target, UInt64 mask)
        {
            for (int i = 0; i < source.Count; i++)
            {
                int nodeKey = source[i];
                if ((mask & (1UL << nodeKey)) != 0)
                {
                    target.Add(nodeKey);
                }
                else
                {
                    target.Add(-nodeKey);
                }
            }
        }


        private static void GetPdnfConjunction(List<Path> pathList, List<List<int>> resultVectorMatrix)
        {
            List<Path> listClone = new List<Path>();
            CopyListContents(pathList, listClone);
            RemoveComplexPaths(listClone);

            List<int> nodeIndexSet = new List<int>();
            GetNodeSet(listClone, nodeIndexSet);

            UInt64[] pathMasks = new UInt64[listClone.Count];

            GetPathMasks(listClone, pathMasks);

            List<UInt64> conjunctionList = new List<UInt64>();
            List<UInt64> subsetList = new List<UInt64>();

            for (int i = 0; i < listClone.Count; i++)
            {
                UInt64 pathMask = pathMasks[i];
                List<int> presentNodes = new List<int>();
                List<int> missingNodes = new List<int>();
                List<int> conjunctionOperand = new List<int>();
                GetPresentMissingNodes(pathMask, nodeIndexSet, presentNodes, missingNodes);
                CopyListContents(presentNodes, conjunctionOperand);
                AppendInvertedNodes(missingNodes, conjunctionOperand);
                resultVectorMatrix.Add(conjunctionOperand);
                conjunctionOperand = null;

                UInt64 combinationsCount = (1UL << missingNodes.Count) - 1;

                for (UInt64 combination = 1; combination < combinationsCount; combination++)
                {
                    UInt64 combinationMask = GetMaskFromMissingNodesCombination(pathMask, missingNodes, combination);
                    int subsetIndex = FindSubsetIndex(subsetList, combinationMask);
                    if (subsetIndex != -1)
                    {
                        combination = SkipSubsetCombinations(combination) - 1;
                    }
                    else
                    {
                        conjunctionOperand = new List<int>();
                        AppendNodesByMask(nodeIndexSet, conjunctionOperand, combinationMask);
                        resultVectorMatrix.Add(conjunctionOperand);
                        conjunctionOperand = null;
                    }
                }

                subsetList.Add(pathMask);
            }

            if (listClone.Count > 1)
            {
                resultVectorMatrix.Add(nodeIndexSet);
            }
        }

        private static LinearLogicEquation GetPdnfLinear(List<Path> pathList)
        {
            List<List<int>> conjunctionList = new List<List<int>>();
            GetPdnfConjunction(pathList, conjunctionList);
            LinearLogicEquation equation = new LinearLogicEquation(conjunctionList);
            return equation;
        }

        public static double Calculate(Graph graph)
        {
            List<Path> pathList = graph.GetPaths();
            int pathsCount = pathList.Count;

            if (pathsCount == 0)
            {
                return 0;
            }

            GraphEventProbabilityProvider probabilityProvider = new GraphEventProbabilityProvider(graph);

            LinearLogicEquation analyticallyDerivedEquation = GetPdnfLinear(pathList);
#if DEBUG
            File.WriteAllText("LogicalEquationLog.txt", analyticallyDerivedEquation.ToString());
#endif
            double analyticallyDerivedResult = analyticallyDerivedEquation.GetProbability(probabilityProvider);
            return analyticallyDerivedResult;
        }
    }
}
