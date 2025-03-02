using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS
{
    public class Graph : IList<Node> , IList<Path>
    {
        private List<Node> NodeList = new List<Node>();
        private List<Path> PathList = new List<Path>();
        //private List<Node> PathList_node = new List<Node>();
        private Node _startNode;
        private Node _endNode;
        private MainForm form1;


        #region IList implementation PathList
        public int IndexOf(Path item)
        {
            return ((IList<Path>)PathList).IndexOf(item);
        }

        public void Insert(int index, Path item)
        {
            ((IList<Path>)PathList).Insert(index, item);
        }

        public void Add(Path item)
        {
            ((IList<Path>)PathList).Add(item);
            //PathList_node.AddRange(item.ToNodeList());
        }

        public bool Contains(Path item)
        {
            return ((IList<Path>)PathList).Contains(item);
        }

        public void CopyTo(Path[] array, int arrayIndex)
        {
            ((IList<Path>)PathList).CopyTo(array, arrayIndex);
        }

        public bool Remove(Path item)
        {
            return ((IList<Path>)PathList).Remove(item);
        }

        IEnumerator<Path> IEnumerable<Path>.GetEnumerator()
        {
            return ((IList<Path>)PathList).GetEnumerator();
        }

        int ICollection<Path>.Count => ((IList<Path>)PathList).Count;

        Path IList<Path>.this[int index] { get => ((IList<Path>)PathList)[index]; set => ((IList<Path>)PathList)[index] = value; }


        #endregion

        #region IList implementation NodeList
        public Graph(MainForm form)
        {
            form1 = form;
        }
        int ICollection<Node>.Count => ((IList<Node>)NodeList).Count;

        public bool IsReadOnly => ((IList<Node>)NodeList).IsReadOnly;

        public Node this[int index] { get => ((IList<Node>)NodeList)[index]; set => ((IList<Node>)NodeList)[index] = value; }


       
        public int Count()
        {
            return NodeList.Count;
        }

        public Node ElementAt(int i)
        {
            return NodeList.ElementAt(i);
        }

        public int IndexOf(Node item)
        {
            return ((IList<Node>)NodeList).IndexOf(item);
        }

        public void Insert(int index, Node item)
        {
            ((IList<Node>)NodeList).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Node>)NodeList).RemoveAt(index);
        }

        public void Add(Node item)
        {
            ((IList<Node>)NodeList).Add(item);
            item.SetIndex(NodeList.Count - 1);
        }

        public void Clear()
        {
            ((IList<Node>)NodeList).Clear();
        }

        public bool Contains(Node item)
        {
            return ((IList<Node>)NodeList).Contains(item);
        }

        public void CopyTo(Node[] array, int arrayIndex)
        {
            ((IList<Node>)NodeList).CopyTo(array, arrayIndex);
        }

        public bool Remove(Node item)
        {
            return ((IList<Node>)NodeList).Remove(item);
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return ((IList<Node>)NodeList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Node>)NodeList).GetEnumerator();
        }

        #endregion

        public List<Node> GetNodes()
        {
            return NodeList;
        }

        public List<Node> GetUsedNodes()
        {
            int count = NodeList.Count;
            List<Node> result = new List<Node>();
            for (int i = 0; i < count; i++)
            {
                for(int j = 0; j < PathList.Count; j++)
                {
                    Path currentPath = PathList[j];
                    Node currentNode = NodeList[i];
                    if (currentPath.Contains(currentNode))
                    {
                        result.Add(currentNode);
                        break;
                    }
                }
            }
            return result;
        }

        public List<Path> GetPaths()
        {
            return PathList;
        }
        /*public List<Node> GetPathsNodeList()
        {
            return PathList_node;
        }*/


        public Node StartNode
        {
            get => _startNode;
            set => _startNode = value;
        }
        public Node EndNode
        {
            get => _endNode;
            set => _endNode = value;
        }

        public Graph Copy()
        {
            Graph copiedGraph = new Graph(form1);
            for(int i = 0; i < this.Count(); i++)
            {
                int x = this.ElementAt(i).X;
                int y = this.ElementAt(i).Y;
                int diameter = this.ElementAt(i).diameter;
                Color color = this.ElementAt(i).Color;
                double chance = this.ElementAt(i).Chance;
                bool isStart = this.ElementAt(i).IsStart;
                bool isEnd = this.ElementAt(i).IsEnd;
                Node copiedNode = new Node(x, y, diameter, color, chance, isStart, isEnd, ElementAt(i).Name);
                if (copiedNode.IsStart) copiedGraph.StartNode = copiedNode;
                if (copiedNode.IsEnd) copiedGraph.EndNode = copiedNode;
                //List<Node> originalConnList = this.ElementAt(i).Connections;

                /*for (int j = 0; j < originalConnList.Count(); j++)
                {
                    copiedNode.AddConnection(originalConnList.ElementAt(j));
                }*/
                copiedGraph.Add(copiedNode);
            }
            for (int i = 0; i < copiedGraph.Count(); i++)
            {
                Node copiedNode = copiedGraph.ElementAt(i);
                Node originalNode = this.ElementAt(i);
                List<Node> originalConnList = originalNode.Connections;
                for (int j = 0; j < originalConnList.Count(); j++)
                {
                    int index = this.IndexOf(originalConnList.ElementAt(j));
                    copiedNode.AddConnection(copiedGraph.ElementAt(index));
                }

            }
            return copiedGraph;
        }
        public void DeleteNode(Node delNode, Graph sender)
        {
            List<Node> nodeList = sender.GetNodes();
            int index = delNode.GetIndex();
            if(index <= -1)
            {
                throw new ArgumentOutOfRangeException();
            }
            nodeList.RemoveAt(index);
            List<Node> connections = delNode.Connections;

            // Removing all mentions about delNode
            for (int i = 0; i < connections.Count; i++)
            {
                Node connectedNode = connections.ElementAt(i);
                connectedNode.Connections.Remove(delNode);
            }

            // Decreasing indexes of all nodes, placed after the deleted one
            for(int i = index; i < nodeList.Count; i++)
            {
                int nodeIndex = nodeList[i].GetIndex();
                nodeList[i].SetIndex(nodeIndex - 1);
            }
        }

        public void DeleteNode(int index)
        {
            Node delNode = NodeList[index];
            NodeList.RemoveAt(index);
            List<Node> connections = delNode.Connections;

            // Removing all mentions about delNode
            for (int i = 0; i < connections.Count; i++)
            {
                Node connectedNode = connections.ElementAt(i);
                connectedNode.Connections.Remove(delNode);
            }

            // Decreasing indexes of all nodes, placed after the deleted one
            for (int i = index; i < NodeList.Count; i++)
            {
                int nodeIndex = NodeList[i].GetIndex();
                NodeList[i].SetIndex(nodeIndex - 1);
            }
        }

        public void Connect(Node n1, Node n2)
        {
            n1.AddConnection(n2);
            n2.AddConnection(n1);
        }

        public void DeleteEdge(Node node1, Node node2)
        {
            node1.Connections.Remove(node2);
            node2.Connections.Remove(node1);
        }


        /*private void DisableNode(Node node)
        {
            node.IsDisabled = true;
        }*/
    }

}
