using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGraphProjectCSS
{
    public partial class NodeRatingForm : Form
    {
        private Graph _graph;

        private List<NodeRatingEntry> _nodeRatingList = new List<NodeRatingEntry>();

        private class NodeRatingEntry
        {
            public Node Node { get; set; }
            public int EntriesCount { get; set; }
            public double Rating { get; set; }
        }

        public double GetNodeRating(Node node)
        {
            //NodeRatingEntry entry = _nodeRatingList.First((NodeRatingEntry ne) => ne.Node == node);
            //return entry.Rating;
            return GetNodeRatingFromTable(node);
        }

        public NodeRatingForm(Graph graph)
        {
            _graph = graph;
            InitializeComponent();
        }

        private List<Path> GetNodePathEntries(Node node, IEnumerable<Path> pathEnumerable)
        {
            List<Path> result = new List<Path>();
            foreach (var path in pathEnumerable)
            {
                if (path.Contains(node))
                {
                    result.Add(path);
                }
            }

            return result;
        }

        private double GetNodeRating(Graph graph, IEnumerable<Path> pathEntries, Node node)
        {
            double result = 0;
            foreach (var path in pathEntries)
            {
                double pathExReliability = 1;
                foreach (var pathNode in path)
                {
                    if (pathNode != node)
                    {
                        pathExReliability *= pathNode.Chance;
                    }
                }

                result += pathExReliability;
            }

            result *= (1 - node.Chance);
            return result;
        }

        private void AddRow(string name, int entries, double reliability, double rating)
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
            nameCell.Value = name;

            DataGridViewTextBoxCell entriesCell = new DataGridViewTextBoxCell();
            entriesCell.Value = entries;

            DataGridViewTextBoxCell reliabilityCell = new DataGridViewTextBoxCell();
            reliabilityCell.Value = reliability;

            DataGridViewTextBoxCell ratingCell = new DataGridViewTextBoxCell();
            ratingCell.Value = rating;

            row.Cells.Add(nameCell);
            row.Cells.Add(entriesCell);
            row.Cells.Add(reliabilityCell);
            row.Cells.Add(ratingCell);
            nodeRatingTable.Rows.Add(row);
        }

        private void SetNodeRating(Node node, double rating)
        {
            int index = node.GetIndex();
            DataGridViewRow row = nodeRatingTable.Rows[index];
            row.Cells[3].Value = rating;
        }

        private void SetDefaultSortingMode()
        {
            nodeRatingTable.Sort(NodeRatingColumn, ListSortDirection.Descending);
        }

        private double GetNodeRatingFromTable(Node node)
        {
            /*
            int index = node.GetIndex();
            if(nodeRatingTable.Rows.Count <= index)
            {
                return 0;
            }
            DataGridViewRow row = nodeRatingTable.Rows[index];
            if(row == null)
            {
                return 0;
            }
            return (double)row.Cells[3].Value;
            */
            NodeRatingEntry entry = _nodeRatingList.First((NodeRatingEntry ne) => ne.Node == node);
            return entry.Rating;
        }

        private void NormalizeRatings()
        {
            double sum = 0;
            for (int i = 0; i < _graph.GetNodes().Count; i++)
            {
                double rating = GetNodeRatingFromTable(_graph.GetNodes()[i]);
                sum += rating;
            }
            for (int i = 0; i < _graph.GetNodes().Count; i++)
            {
                Node node = _graph.GetNodes()[i];
                double rating = GetNodeRatingFromTable(node);
                if (sum == 0)
                {
                    rating = 0;
                }
                else
                {
                    rating /= sum;
                }

                //SetNodeRating(_graph.GetNodes()[i], rating);
                NodeRatingEntry entry = _nodeRatingList.First((NodeRatingEntry ne) => ne.Node == node);
                entry.Rating = rating;
            }

        }

        private void NodeRatingForm_Load(object sender, EventArgs e)
        {
            _nodeRatingList.Clear();
            for (int i = 0; i < _graph.GetNodes().Count; i++)
            {
                Node node = _graph.GetNodes()[i];
                string name = node.Name;
                double reliability = node.Chance;
                List<Path> entries = GetNodePathEntries(node, _graph.GetPaths());
                double rating = GetNodeRating(_graph, entries, node);
                _nodeRatingList.Add(new NodeRatingEntry() { Node = node, EntriesCount = entries.Count, Rating = rating });
                //AddRow(name, entries.Count, reliability, rating);
            }

            NormalizeRatings();
            SetDefaultSortingMode();

            foreach(var entry in _nodeRatingList)
            {
                AddRow(entry.Node.Name, entry.EntriesCount, entry.Node.Chance, entry.Rating);
            }
        }
    }
}
