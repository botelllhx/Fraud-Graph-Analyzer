using FraudGraphAnalyzer.Graph;

namespace FraudGraphAnalyzer.Data
{
    public static class SampleData
    {
        public static Graph.Graph CreateSampleGraph()
        {
            var graph = new Graph.Graph();

            // Nodes (contas)
            graph.AddNode(new Models.Node("A"));
            graph.AddNode(new Models.Node("B"));
            graph.AddNode(new Models.Node("C"));
            graph.AddNode(new Models.Node("D"));
            graph.AddNode(new Models.Node("E"));
            graph.AddNode(new Models.Node("F"));
            graph.AddNode(new Models.Node("G"));

            // Example transactions (directed, value in R$)
            graph.AddEdge("A", "B", 5000);
            graph.AddEdge("B", "C", 2000);
            graph.AddEdge("C", "D", 1000);
            graph.AddEdge("D", "A", 500);   // cycle A->B->C->D->A (suspect)

            graph.AddEdge("E", "F", 8000);  // isolated
            graph.AddEdge("B", "G", 1200);  // branching

            return graph;
        }
    }
}
