namespace FraudGraphAnalyzer.Models
{
    public class Edge
    {
        public Node From { get; }
        public Node To { get; }
        public double Value { get; }

        public Edge(Node from, Node to, double value)
        {
            From = from;
            To = to;
            Value = value;
        }

        public override string ToString() => $"{From.Id} -> {To.Id} (R$ {Value})";
    }
}
