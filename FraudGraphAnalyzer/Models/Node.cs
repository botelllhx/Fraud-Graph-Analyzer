using System.Collections.Generic;

namespace FraudGraphAnalyzer.Models
{
    public class Node
    {
        public string Id { get; set; }
        public List<Edge> OutgoingEdges { get; } = new List<Edge>();

        public Node(string id)
        {
            Id = id;
        }

        public override string ToString() => Id;
    }
}
