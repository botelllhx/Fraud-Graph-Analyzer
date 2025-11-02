using FraudGraphAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FraudGraphAnalyzer.WinForms
{
    /// <summary>
    /// Simple renderer for small graphs: circular layout + edge arrows.
    /// Maintains double-buffering and supports highlighting a path.
    /// </summary>
    public class GraphRenderer
    {
        private readonly Panel panel;
        private Dictionary<Node, PointF> positions = new();
        private const int NodeRadius = 22;
        public List<Node> HighlightedPath { get; set; } = null;

        public GraphRenderer(Panel panel)
        {
            this.panel = panel;
            panel.Paint += Panel_Paint;
            panel.Resize += Panel_Resize;
            panel.DoubleBuffered(true);
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            panel.Invalidate();
        }

        public void Render(Graph.Graph graph)
        {
            Layout(graph);
            panel.Invalidate();
        }

        public void Invalidate()
        {
            panel.Invalidate();
        }

        private void Layout(Graph.Graph graph)
        {
            positions.Clear();
            var nodes = graph.GetNodes().ToList();
            int n = nodes.Count;
            if (n == 0) return;

            var w = panel.ClientSize.Width;
            var h = panel.ClientSize.Height;
            var cx = w / 2f;
            var cy = h / 2f;
            var radius = Math.Min(w, h) / 2f - 60;
            if (radius < 50) radius = Math.Min(w, h) / 2f - 30;

            for (int i = 0; i < n; i++)
            {
                var angle = 2 * Math.PI * i / n - Math.PI / 2;
                var x = cx + radius * (float)Math.Cos(angle);
                var y = cy + radius * (float)Math.Sin(angle);
                positions[nodes[i]] = new PointF(x, y);
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(panel.BackColor);

            if (positions.Count == 0) return;

            // draw edges
            foreach (var kv in positions)
            {
                var node = kv.Key;
                var from = kv.Value;
                if (node == null) continue;
                foreach (var edge in node.OutgoingEdges)
                {
                    if (!positions.TryGetValue(edge.To, out var to)) continue;
                    bool highlight = IsEdgeInHighlightedPath(edge);
                    DrawArrow(g, from, to, highlight);
                }
            }

            // draw nodes
            foreach (var kv in positions)
            {
                var node = kv.Key;
                var pt = kv.Value;
                DrawNode(g, node, pt, HighlightedPath != null && HighlightedPath.Contains(node));
            }
        }

        private bool IsEdgeInHighlightedPath(Edge edge)
        {
            if (HighlightedPath == null || HighlightedPath.Count < 2) return false;
            for (int i = 0; i < HighlightedPath.Count - 1; i++)
            {
                if (HighlightedPath[i] == edge.From && HighlightedPath[i + 1] == edge.To)
                    return true;
            }
            return false;
        }

        private void DrawNode(Graphics g, Node node, PointF pt, bool highlighted)
        {
            var rect = new RectangleF(pt.X - NodeRadius, pt.Y - NodeRadius, NodeRadius * 2, NodeRadius * 2);
            var fill = highlighted ? Brushes.Orange : Brushes.LightBlue;
            var border = highlighted ? Pens.OrangeRed : Pens.DodgerBlue;

            g.FillEllipse(fill, rect);
            g.DrawEllipse(border, rect);

            // text
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            var font = new Font("Segoe UI", 9, FontStyle.Bold);
            g.DrawString(node.Id, font, Brushes.Black, pt, sf);
        }

        private void DrawArrow(Graphics g, PointF from, PointF to, bool highlight)
        {
            var pen = new Pen(highlight ? Color.OrangeRed : Color.Gray, highlight ? 2.5f : 1.4f);
            var dir = new PointF(to.X - from.X, to.Y - from.Y);
            var len = Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y);
            if (len < 0.0001) return;
            var ux = dir.X / (float)len;
            var uy = dir.Y / (float)len;

            var start = new PointF(from.X + ux * NodeRadius, from.Y + uy * NodeRadius);
            var end = new PointF(to.X - ux * NodeRadius, to.Y - uy * NodeRadius);

            g.DrawLine(pen, start, end);

            // arrow head
            var arrowSize = 8;
            var left = new PointF(
                end.X - ux * arrowSize - uy * arrowSize / 1.5f,
                end.Y - uy * arrowSize + ux * arrowSize / 1.5f);
            var right = new PointF(
                end.X - ux * arrowSize + uy * arrowSize / 1.5f,
                end.Y - uy * arrowSize - ux * arrowSize / 1.5f);
            g.FillPolygon(highlight ? Brushes.OrangeRed : Brushes.Gray, new[] { end, left, right });
        }
    }

    // extension to enable double buffering on Panel
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control c, bool enable)
        {
            var property = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            property.SetValue(c, enable, null);
        }
    }
}
