using FraudGraphAnalyzer.Graph;
using FraudGraphAnalyzer.Models;
using FraudGraphAnalyzer.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FraudGraphAnalyzer.WinForms
{
    public partial class MainForm : Form
    {
        private Graph.Graph graph;
        private GraphRenderer renderer;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            graph = SampleData.CreateSampleGraph();
            renderer = new GraphRenderer(panelGraph);
            RefreshUI();
        }

        private void RefreshUI()
        {
            // Populate transactions list
            lstTransactions.Items.Clear();
            foreach (var n in graph.GetNodes())
            {
                foreach (var e in graph.GetEdges(n))
                {
                    lstTransactions.Items.Add($"{e.From.Id} -> {e.To.Id} (R$ {e.Value})");
                }
            }

            // Populate nodes list
            lstNodes.Items.Clear();
            foreach (var n in graph.GetNodes())
                lstNodes.Items.Add(n.Id);

            // draw
            renderer.Render(graph);
        }

        private void btnDetectCycles_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            bool hasCycle = Algorithms.HasCycle(graph, txtLog);
            if (hasCycle)
            {
                txtLog.AppendText("\r\n🚨 Fraude potencial detectada!\r\n");
            }
            else
            {
                txtLog.AppendText("\r\n✅ Nenhuma anomalia encontrada.\r\n");
            }
            renderer.HighlightedPath = null;
            renderer.Invalidate();
        }

        private void btnCentrality_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            var degrees = graph.GetNodes()
                .Select(n => new { Node = n, Grau = graph.GetEdges(n).Count() })
                .OrderByDescending(x => x.Grau);

            txtLog.AppendText("=== Grau de Centralidade ===\r\n");
            foreach (var d in degrees)
                txtLog.AppendText($"{d.Node.Id}: {d.Grau} conexões\r\n");
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            var startId = txtStart.Text.Trim().ToUpper();
            var endId = txtEnd.Text.Trim().ToUpper();
            var start = graph.FindNode(startId);
            var end = graph.FindNode(endId);

            if (start == null || end == null)
            {
                MessageBox.Show("Conta(s) inválida(s). Verifique os IDs.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var path = Algorithms.ShortestPath(graph, start, end);
            if (path == null || path.Count == 0 || path.Count == 1 && path[0] != start)
            {
                txtLog.AppendText("Nenhum caminho encontrado entre as contas.\r\n");
            }
            else
            {
                txtLog.AppendText("Caminho encontrado: " + string.Join(" → ", path.Select(p => p.Id)) + "\r\n");
                renderer.HighlightedPath = path;
                renderer.Invalidate();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            graph = SampleData.CreateSampleGraph();
            renderer.HighlightedPath = null;
            RefreshUI();
            txtLog.Clear();
            txtLog.AppendText("Dados recarregados com sample padrão.\r\n");
        }

        private void lstNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNodes.SelectedItem != null)
            {
                txtStart.Text = lstNodes.SelectedItem.ToString();
            }
        }

        private void lstTransactions_DoubleClick(object sender, EventArgs e)
        {
            if (lstTransactions.SelectedItem == null) return;
            var s = lstTransactions.SelectedItem.ToString();
            // form: A -> B (R$ 5000)
            if (string.IsNullOrEmpty(s)) return;
            var parts = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                txtStart.Text = parts[0];
                txtEnd.Text = parts[2];
            }
        }

        private void btnExportDot_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "DOT file|*.dot|Text file|*.txt";
                    sfd.FileName = "graph.dot";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(sfd.FileName, GraphDotExporter.Export(graph));
                        MessageBox.Show("Arquivo DOT exportado com sucesso.", "Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar DOT: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
