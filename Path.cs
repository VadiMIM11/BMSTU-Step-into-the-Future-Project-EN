using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS
{
    public class Path : IList<Node>
    {
        private List<Node> _path = new List<Node>();

        /*public Path(List<Node> path)
        {
            _path = path;
        }*/
        public Path()
        {

        }
        
        public Path Clone()
        {
            Path clone = new Path();
            for(int i = 0; i < _path.Count; i++)
            {
                clone.Add(_path[i]);
            }
            return clone;
        }

        public List<Node> ToNodeList()
        {
            return _path;
        }

        /*public SetComparisonResult CompareTo(Path comparable)
        {
            for(int i = 0; i < this.Count; i++)
            {
                int value = 
                for
            }
        }*/

        #region IList implementation

        public Node this[int index] { get => ((IList<Node>)_path)[index]; set => ((IList<Node>)_path)[index] = value; }

        public int Count => ((IList<Node>)_path).Count;

        public bool IsReadOnly => ((IList<Node>)_path).IsReadOnly;

        public void Add(Node item)
        {
            ((IList<Node>)_path).Add(item);
        }

        public void Clear()
        {
            ((IList<Node>)_path).Clear();
        }

        public bool Contains(Node item)
        {
            return ((IList<Node>)_path).Contains(item);
        }

        public void CopyTo(Node[] array, int arrayIndex)
        {
            ((IList<Node>)_path).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return ((IList<Node>)_path).GetEnumerator();
        }

        public int IndexOf(Node item)
        {
            return ((IList<Node>)_path).IndexOf(item);
        }

        public void Insert(int index, Node item)
        {
            ((IList<Node>)_path).Insert(index, item);
        }

        public bool Remove(Node item)
        {
            return ((IList<Node>)_path).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Node>)_path).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Node>)_path).GetEnumerator();
        }
        #endregion


    }
}
