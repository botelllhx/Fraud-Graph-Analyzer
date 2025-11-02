using FraudGraphAnalyzer.Models;
using System.Collections.Generic;
using System.Linq;

namespace FraudGraphAnalyzer.Graph
{
    public class Graph
    {
        private readonly Dictionary<string, Node> nodesById = new Dictionary<string, Node>();

        public IEnumerable<Node> GetNodes() => nodesById.Values;

        public void AddNode(Node node)
        {
            if (!nodesById.ContainsKey(node.Id))
                nodesById[node.Id] = node;
        }

        public Node EnsureNode(string id)
        {
            if (!nodesById.ContainsKey(id))
                nodesById[id] = new Node(id);
            return nodesById[id];
        }

        public void AddEdge(string fromId, string toId, double value)
        {
            var from = EnsureNode(fromId);
            var to = EnsureNode(toId);
            var edge = new Edge(from, to, value);
            from.OutgoingEdges.Add(edge);
        }

        public void AddEdge(Node from, Node to, double value)
        {
            AddNode(from);
            AddNode(to);
            var edge = new Edge(from, to, value);
            from.OutgoingEdges.Add(edge);
        }

        public IEnumerable<Edge> GetEdges(Node node) => node.OutgoingEdges;

        public Node FindNode(string id) => nodesById.ContainsKey(id) ? nodesById[id] : null;
    }

    // small helper to export Graphviz DOT
    public static class GraphDotExporter
    {
        public static string Export(Graph graph)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("digraph G {");
            sb.AppendLine("  rankdir=LR;");
            sb.AppendLine("  node [shape=circle, style=filled, fillcolor=lightblue];");
            foreach (var n in graph.GetNodes())
            {
                foreach (var e in n.OutgoingEdges)
                {
                    sb.AppendLine($"  \"{e.From.Id}\" -> \"{e.To.Id}\" [label=\"R$ {e.Value}\"];");
                }
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
