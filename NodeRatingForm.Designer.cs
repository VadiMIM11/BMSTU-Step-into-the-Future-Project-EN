namespace MyGraphProjectCSS
{
    partial class NodeRatingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nodeRatingTable = new System.Windows.Forms.DataGridView();
            this.nodeIndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathEntriesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReliabilityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeRatingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nodeRatingTable)).BeginInit();
            this.SuspendLayout();
            // 
            // nodeRatingTable
            // 
            this.nodeRatingTable.AllowUserToAddRows = false;
            this.nodeRatingTable.AllowUserToDeleteRows = false;
            this.nodeRatingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nodeRatingTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nodeIndexColumn,
            this.PathEntriesColumn,
            this.ReliabilityColumn,
            this.NodeRatingColumn});
            this.nodeRatingTable.Location = new System.Drawing.Point(12, 12);
            this.nodeRatingTable.Name = "nodeRatingTable";
            this.nodeRatingTable.ReadOnly = true;
            this.nodeRatingTable.Size = new System.Drawing.Size(776, 426);
            this.nodeRatingTable.TabIndex = 0;
            // 
            // nodeIndexColumn
            // 
            this.nodeIndexColumn.HeaderText = "Node Index";
            this.nodeIndexColumn.Name = "nodeIndexColumn";
            this.nodeIndexColumn.ReadOnly = true;
            // 
            // PathEntriesColumn
            // 
            this.PathEntriesColumn.HeaderText = "Path Entries";
            this.PathEntriesColumn.Name = "PathEntriesColumn";
            this.PathEntriesColumn.ReadOnly = true;
            // 
            // ReliabilityColumn
            // 
            this.ReliabilityColumn.HeaderText = "Reliability";
            this.ReliabilityColumn.Name = "ReliabilityColumn";
            this.ReliabilityColumn.ReadOnly = true;
            // 
            // NodeRatingColumn
            // 
            this.NodeRatingColumn.HeaderText = "Rating";
            this.NodeRatingColumn.Name = "NodeRatingColumn";
            this.NodeRatingColumn.ReadOnly = true;
            // 
            // NodeRatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nodeRatingTable);
            this.Name = "NodeRatingForm";
            this.Text = "NodeRatingForm";
            this.Load += new System.EventHandler(this.NodeRatingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nodeRatingTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView nodeRatingTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeIndexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathEntriesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReliabilityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeRatingColumn;
    }
}