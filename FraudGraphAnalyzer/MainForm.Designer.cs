namespace FraudGraphAnalyzer.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variables
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.ListBox lstTransactions;
        private System.Windows.Forms.ListBox lstNodes;
        private System.Windows.Forms.Button btnDetectCycles;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnCentrality;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnExportDot;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblTransactions;
        private System.Windows.Forms.Label lblNodes;

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.lstTransactions = new System.Windows.Forms.ListBox();
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.btnDetectCycles = new System.Windows.Forms.Button();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnCentrality = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnExportDot = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblTransactions = new System.Windows.Forms.Label();
            this.lblNodes = new System.Windows.Forms.Label();

            // 
            // MainForm
            // 
            this.Text = "FraudGraphAnalyzer — Detecção de Fraudes com Grafos";
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            lblTitle.Location = new System.Drawing.Point(18, 12);
            lblTitle.Text = "Detecção e Rastreamento de Fraudes em Transações Financeiras (Grafos)";
            this.Controls.Add(lblTitle);

            // Credits / resumo
            lblCredits = new System.Windows.Forms.Label();
            lblCredits.AutoSize = false;
            lblCredits.Size = new System.Drawing.Size(420, 80);
            lblCredits.Location = new System.Drawing.Point(18, 44);
            lblCredits.Text = "Equipe: Mateus Botelho, Victor Alves, Daniel Heringer, Lucas Borges, Vitor Mendonça\r\n\r\nResumo: Aplicação da teoria dos grafos na detecção e rastreamento de fraudes em transações financeiras.";
            lblCredits.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Controls.Add(lblCredits);

            // Graph panel
            panelGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelGraph.Location = new System.Drawing.Point(18, 130);
            panelGraph.Size = new System.Drawing.Size(700, 450);
            panelGraph.BackColor = System.Drawing.Color.White;
            panelGraph.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom);
            this.Controls.Add(panelGraph);

            // Transactions label
            lblTransactions = new System.Windows.Forms.Label();
            lblTransactions.Text = "Transações";
            lblTransactions.Location = new System.Drawing.Point(740, 12);
            lblTransactions.AutoSize = true;
            lblTransactions.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.Controls.Add(lblTransactions);

            // Nodes label
            lblNodes = new System.Windows.Forms.Label();
            lblNodes.Text = "Contas (nós)";
            lblNodes.Location = new System.Drawing.Point(900, 12);
            lblNodes.AutoSize = true;
            lblNodes.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.Controls.Add(lblNodes);

            // Transactions listbox
            lstTransactions.Location = new System.Drawing.Point(740, 36);
            lstTransactions.Size = new System.Drawing.Size(340, 250);
            lstTransactions.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            lstTransactions.Font = new System.Drawing.Font("Consolas", 9F);
            lstTransactions.DoubleClick += new System.EventHandler(this.lstTransactions_DoubleClick);
            this.Controls.Add(lstTransactions);

            // Nodes listbox
            lstNodes.Location = new System.Drawing.Point(900, 36);
            lstNodes.Size = new System.Drawing.Size(180, 250);
            lstNodes.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            lstNodes.Font = new System.Drawing.Font("Consolas", 9F);
            lstNodes.SelectedIndexChanged += new System.EventHandler(this.lstNodes_SelectedIndexChanged);
            this.Controls.Add(lstNodes);

            // Start label & textbox
            lblStart.Location = new System.Drawing.Point(740, 300);
            lblStart.Text = "Origem (ID)";
            lblStart.AutoSize = true;
            this.Controls.Add(lblStart);

            txtStart.Location = new System.Drawing.Point(740, 320);
            txtStart.Size = new System.Drawing.Size(160, 23);
            this.Controls.Add(txtStart);

            // End label & textbox
            lblEnd.Location = new System.Drawing.Point(910, 300);
            lblEnd.Text = "Destino (ID)";
            lblEnd.AutoSize = true;
            this.Controls.Add(lblEnd);

            txtEnd.Location = new System.Drawing.Point(910, 320);
            txtEnd.Size = new System.Drawing.Size(170, 23);
            this.Controls.Add(txtEnd);

            // Find Path button
            btnFindPath.Location = new System.Drawing.Point(740, 355);
            btnFindPath.Size = new System.Drawing.Size(170, 32);
            btnFindPath.Text = "Rastrear caminho (BFS)";
            btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            this.Controls.Add(btnFindPath);

            // Detect cycles button
            btnDetectCycles.Location = new System.Drawing.Point(920, 355);
            btnDetectCycles.Size = new System.Drawing.Size(160, 32);
            btnDetectCycles.Text = "Detectar ciclos (DFS)";
            btnDetectCycles.Click += new System.EventHandler(this.btnDetectCycles_Click);
            this.Controls.Add(btnDetectCycles);

            // Centrality button
            btnCentrality.Location = new System.Drawing.Point(740, 400);
            btnCentrality.Size = new System.Drawing.Size(170, 32);
            btnCentrality.Text = "Grau de centralidade";
            btnCentrality.Click += new System.EventHandler(this.btnCentrality_Click);
            this.Controls.Add(btnCentrality);

            // Reload sample data
            btnReload.Location = new System.Drawing.Point(920, 400);
            btnReload.Size = new System.Drawing.Size(160, 32);
            btnReload.Text = "Recarregar dados";
            btnReload.Click += new System.EventHandler(this.btnReload_Click);
            this.Controls.Add(btnReload);

            // Export DOT
            btnExportDot.Location = new System.Drawing.Point(740, 445);
            btnExportDot.Size = new System.Drawing.Size(340, 32);
            btnExportDot.Text = "Exportar grafo (DOT) para visualização (Graphviz)";
            btnExportDot.Click += new System.EventHandler(this.btnExportDot_Click);
            this.Controls.Add(btnExportDot);

            // Log textbox
            txtLog.Location = new System.Drawing.Point(18, 590);
            txtLog.Size = new System.Drawing.Size(1062, 95);
            txtLog.ReadOnly = true;
            txtLog.BackColor = System.Drawing.Color.White;
            txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            txtLog.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.Controls.Add(txtLog);

            // Form finishing touches
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        #endregion
    }
}
