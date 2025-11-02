using FraudGraphAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudGraphAnalyzer.Graph
{
    public static class Algorithms
    {
        // DFS cycle detection (directed graph)
        public static bool HasCycle(Graph graph, System.Windows.Forms.RichTextBox log = null)
        {
            var visited = new HashSet<Node>();
            var recStack = new HashSet<Node>();
            foreach (var node in graph.GetNodes())
            {
                if (!visited.Contains(node))
                {
                    if (DetectCycleDFS(graph, node, visited, recStack, log))
                        return true;
                }
            }
            return false;
        }

        private static bool DetectCycleDFS(Graph graph, Node node, HashSet<Node> visited, HashSet<Node> stack, System.Windows.Forms.RichTextBox log)
        {
            visited.Add(node);
            stack.Add(node);

            foreach (var edge in node.OutgoingEdges)
            {
                if (!visited.Contains(edge.To))
                {
                    if (DetectCycleDFS(graph, edge.To, visited, stack, log))
                        return true;
                }
                else if (stack.Contains(edge.To))
                {
                    // Found a cycle: edge.From -> edge.To
                    log?.AppendText($"\r\n🔴 Ciclo detectado: {edge.From.Id} → {edge.To.Id}\r\n");
                    return true;
                }
            }

            stack.Remove(node);
            return false;
        }

        // BFS shortest path (unweighted)
        public static List<Node> ShortestPath(Graph graph, Node start, Node end)
        {
            var queue = new Queue<Node>();
            var parent = new Dictionary<Node, Node>();
            var visited = new HashSet<Node>();

            queue.Enqueue(start);
            visited.Add(start);
            parent[start] = null;

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                if (cur == end) break;

                foreach (var e in cur.OutgoingEdges)
                {
                    if (!visited.Contains(e.To))
                    {
                        visited.Add(e.To);
                        parent[e.To] = cur;
                        queue.Enqueue(e.To);
                    }
                }
            }

            if (!parent.ContainsKey(end)) return new List<Node>(); // no path

            var path = new List<Node>();
            var at = end;
            while (at != null)
            {
                path.Insert(0, at);
                parent.TryGetValue(at, out at);
            }
            return path;
        }
    }
}
