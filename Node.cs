using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS
{
    public class Node
    {
        private int _x;
        private int _y;
        private int _diameter;
        private bool _isStart;
        private bool _isEnd;
        private Color _color;
        private double _chance;
        private List<Node> _connections = new List<Node>();
        private bool _isDisabled;

        private int _nodeKey;

        public string Name { get; set; }

        /// <summary>
        /// Sets node's integer key. Must be managed by Graph
        /// </summary>
        /// <param name="key"></param>
        public void SetIndex(int key)
        {
            _nodeKey = key;
        }

        public Node(int x, int y, int diameter, Color color, double chance, bool isStart, bool isEnd, string name)
        {
            _x = x;
            _y = y;
            _diameter = diameter;
            _color = color;
            _chance = chance;
            _isStart = isStart;
            _isEnd = isEnd;
            Name = name;
        }
        public Node(int x, int y, int diameter, float chance, Graph _graph, string name)
        {
            _x = x;
            _y = y;
            _diameter = diameter;
            _chance = chance;
            Name = name;
        }
        public int GetIndex()
        {
            //return _graph.IndexOf(this);
            return _nodeKey;
        }
        public bool IsDisabled
        {
            get => _isDisabled;
            set => _isDisabled = value;
        }
        public int X
        {
            get => _x;
            set => _x = value;
        }
        public int Y
        {
            get => _y;
            set => _y = value;
        }
        public int diameter
        {
            get => _diameter;
            set => _diameter = value;
        }
        public Color Color
        {
            get => _color;
            set => _color = value;
        }
        public double Chance
        {
            get => _chance;
            set => _chance = value;
        }
        public List<Node> Connections
        {
            get => _connections;
            set => _connections = value;
        }
        private List<Node> DeleteDisabledConnetions(List<Node> _connections)
        {
            List<Node> editedConnList = new List<Node>();
            for (int i = 0; i < _connections.Count; i++)
            {
                if (!_connections.ElementAt(i).IsDisabled)
                {
                    editedConnList.Add(_connections.ElementAt(i));
                }
            }
            return editedConnList;
        }
        public bool IsStart
        {
            get => _isStart;
            set => _isStart = value;
        }
        public bool IsEnd
        {
            get => _isEnd;
            set => _isEnd = value;
        }
        /*public Node Copy()
        {
            Node copiedNode = new Node(_x, _y, _diameter, _color);
            for(int i = 0; i < _connections.Count(); i++)
            {
                
            }
        }*/
        public void AddConnection(Node node)
        {
            _connections.Add(node);
        }
    }
}
