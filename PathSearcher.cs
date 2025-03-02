using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS
{
    static class PathSearcher
    {
        static public bool PathExictanceCheck(Graph graph)
        {
            Node start = graph.StartNode;
            Node end = graph.EndNode;
            List<Node> visitedList = new List<Node>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(start);
            visitedList.Add(start);
            if ((start != null) && (end != null))
            {
                while (queue.Count != 0)
                {
                    Node node = queue.Dequeue();
                    if (node == end)
                    {
                        return true;
                    }
                    List<Node> nodeConn = node.Connections;
                    for (int i = 0; i < nodeConn.Count; i++)
                    {
                        if (visitedList.IndexOf(nodeConn[i]) == -1)
                        {
                            queue.Enqueue(nodeConn[i]);
                            visitedList.Add(nodeConn[i]);
                        }
                    }
                }
            }
            return false;
        }

        static public void FindAllPaths(Graph graph)
        {
            graph.GetPaths().Clear();

            Node start = graph.StartNode;
            Path path = new Path();
            //path.Add(start);
            //visited.Add(start);
            Dfs(graph, start, path);
            return;
        }
        static private void Dfs(Graph graph, Node currentNode, Path path)
        {
            path.Add(currentNode);

            if(currentNode == graph.EndNode)
            {
                graph.Add(path);
                return;
            }

            if (currentNode.Connections.Count == 0)
            {
                return;
            }

            for(int i = 0; i < currentNode.Connections.Count; i++)
            {
                Node connection = currentNode.Connections[i];
                if (path.Contains(connection))
                {
                    continue;
                }
                Path pathClone = new Path();
                pathClone = path.Clone();
                Dfs(graph, connection, pathClone);
            }
        }

        /*private int dfs(Graph graph, List<Node> visited, Node currentNode, Path path, int count)
        {

            if(currentNode == graph.EndNode)
            {
                path.Add(currentNode);
                path.Add(graph.EndNode);
                graph.Add(path);
                //path.Clear();
                count++;
                return count;
            }
            else
            {
                visited.Add(currentNode);
                List<Node> conns = currentNode.Connections;
                for (int i = 0; i < conns.Count; i++)
                {
                    Node currConnected = conns[i];
                    int index = visited.IndexOf(currConnected);
                    if ((index == -1))
                    {
                        count = dfs(graph, visited, currConnected, path, count);
                        path.Add(currConnected);
                        visited.Remove(currConnected);
                    }
                }
                return count;
            }
        }*/

    }
}
