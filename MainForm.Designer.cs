namespace MyGraphProjectCSS
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPB = new System.Windows.Forms.PictureBox();
            this.saveButt = new System.Windows.Forms.Button();
            this.chanceTB = new System.Windows.Forms.TextBox();
            this.coordsLabel = new System.Windows.Forms.Label();
            this.deleteButt = new System.Windows.Forms.Button();
            this.redrawButt = new System.Windows.Forms.Button();
            this.setStartButt = new System.Windows.Forms.Button();
            this.setEndButt = new System.Windows.Forms.Button();
            this.AltConnectingCB = new System.Windows.Forms.CheckBox();
            this.FindButt = new System.Windows.Forms.Button();
            this.startExpButt = new System.Windows.Forms.Button();
            this.pathsTB = new System.Windows.Forms.RichTextBox();
            this.calculateButt = new System.Windows.Forms.Button();
            this.getNodesRatingButt = new System.Windows.Forms.Button();
            this.expAmountTB = new System.Windows.Forms.TextBox();
            this.reliabilityLB = new System.Windows.Forms.Label();
            this.expNumLB = new System.Windows.Forms.Label();
            this.ExperimentPrecisionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainPB)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPB
            // 
            this.MainPB.BackColor = System.Drawing.Color.White;
            this.MainPB.Location = new System.Drawing.Point(12, 13);
            this.MainPB.Name = "MainPB";
            this.MainPB.Size = new System.Drawing.Size(650, 413);
            this.MainPB.TabIndex = 0;
            this.MainPB.TabStop = false;
            this.MainPB.Click += new System.EventHandler(this.PictureBox_Click);
            this.MainPB.DoubleClick += new System.EventHandler(this.PictureBox_DoubleClick);
            // 
            // saveButt
            // 
            this.saveButt.Location = new System.Drawing.Point(670, 306);
            this.saveButt.Name = "saveButt";
            this.saveButt.Size = new System.Drawing.Size(84, 23);
            this.saveButt.TabIndex = 1;
            this.saveButt.Text = "Save Changes";
            this.saveButt.UseVisualStyleBackColor = true;
            this.saveButt.Click += new System.EventHandler(this.SaveButt_Click);
            // 
            // chanceTB
            // 
            this.chanceTB.Location = new System.Drawing.Point(669, 280);
            this.chanceTB.Name = "chanceTB";
            this.chanceTB.Size = new System.Drawing.Size(169, 20);
            this.chanceTB.TabIndex = 2;
            // 
            // coordsLabel
            // 
            this.coordsLabel.AutoSize = true;
            this.coordsLabel.Location = new System.Drawing.Point(12, 429);
            this.coordsLabel.Name = "coordsLabel";
            this.coordsLabel.Size = new System.Drawing.Size(36, 13);
            this.coordsLabel.TabIndex = 3;
            this.coordsLabel.Text = "X:  Y: ";
            // 
            // deleteButt
            // 
            this.deleteButt.Location = new System.Drawing.Point(760, 306);
            this.deleteButt.Name = "deleteButt";
            this.deleteButt.Size = new System.Drawing.Size(80, 23);
            this.deleteButt.TabIndex = 4;
            this.deleteButt.Text = "Delete Node";
            this.deleteButt.UseVisualStyleBackColor = true;
            this.deleteButt.Visible = false;
            this.deleteButt.Click += new System.EventHandler(this.DeleteButt_Click);
            // 
            // redrawButt
            // 
            this.redrawButt.Location = new System.Drawing.Point(669, 12);
            this.redrawButt.Name = "redrawButt";
            this.redrawButt.Size = new System.Drawing.Size(171, 23);
            this.redrawButt.TabIndex = 5;
            this.redrawButt.Text = "Redraw Graph";
            this.redrawButt.UseVisualStyleBackColor = true;
            this.redrawButt.Click += new System.EventHandler(this.RedrawButt_Click);
            // 
            // setStartButt
            // 
            this.setStartButt.Location = new System.Drawing.Point(669, 238);
            this.setStartButt.Name = "setStartButt";
            this.setStartButt.Size = new System.Drawing.Size(85, 23);
            this.setStartButt.TabIndex = 6;
            this.setStartButt.Text = "Set Start";
            this.setStartButt.UseVisualStyleBackColor = true;
            this.setStartButt.Click += new System.EventHandler(this.SetStartButt_Click);
            // 
            // setEndButt
            // 
            this.setEndButt.Location = new System.Drawing.Point(760, 238);
            this.setEndButt.Name = "setEndButt";
            this.setEndButt.Size = new System.Drawing.Size(80, 23);
            this.setEndButt.TabIndex = 6;
            this.setEndButt.Text = "Set End";
            this.setEndButt.UseVisualStyleBackColor = true;
            this.setEndButt.Click += new System.EventHandler(this.SetEndButt_Click);
            // 
            // AltConnectingCB
            // 
            this.AltConnectingCB.AutoSize = true;
            this.AltConnectingCB.Checked = true;
            this.AltConnectingCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AltConnectingCB.Location = new System.Drawing.Point(671, 215);
            this.AltConnectingCB.Name = "AltConnectingCB";
            this.AltConnectingCB.Size = new System.Drawing.Size(125, 17);
            this.AltConnectingCB.TabIndex = 7;
            this.AltConnectingCB.Text = "Alt Connecting Mode";
            this.AltConnectingCB.UseVisualStyleBackColor = true;
            // 
            // FindButt
            // 
            this.FindButt.Location = new System.Drawing.Point(668, 181);
            this.FindButt.Name = "FindButt";
            this.FindButt.Size = new System.Drawing.Size(172, 23);
            this.FindButt.TabIndex = 8;
            this.FindButt.Text = "Find Path";
            this.FindButt.UseVisualStyleBackColor = true;
            this.FindButt.Visible = false;
            this.FindButt.Click += new System.EventHandler(this.FindButt_Click);
            // 
            // startExpButt
            // 
            this.startExpButt.Location = new System.Drawing.Point(669, 403);
            this.startExpButt.Name = "startExpButt";
            this.startExpButt.Size = new System.Drawing.Size(171, 23);
            this.startExpButt.TabIndex = 9;
            this.startExpButt.Text = "Experiment";
            this.startExpButt.UseVisualStyleBackColor = true;
            this.startExpButt.Click += new System.EventHandler(this.StartExpButt_Click);
            // 
            // pathsTB
            // 
            this.pathsTB.Location = new System.Drawing.Point(667, 98);
            this.pathsTB.Name = "pathsTB";
            this.pathsTB.Size = new System.Drawing.Size(173, 77);
            this.pathsTB.TabIndex = 10;
            this.pathsTB.Text = "";
            this.pathsTB.Visible = false;
            // 
            // calculateButt
            // 
            this.calculateButt.Location = new System.Drawing.Point(669, 335);
            this.calculateButt.Name = "calculateButt";
            this.calculateButt.Size = new System.Drawing.Size(171, 23);
            this.calculateButt.TabIndex = 11;
            this.calculateButt.Text = "Calculate";
            this.calculateButt.UseVisualStyleBackColor = true;
            this.calculateButt.Click += new System.EventHandler(this.CalculateButt_Click);
            // 
            // getNodesRatingButt
            // 
            this.getNodesRatingButt.Location = new System.Drawing.Point(669, 41);
            this.getNodesRatingButt.Name = "getNodesRatingButt";
            this.getNodesRatingButt.Size = new System.Drawing.Size(171, 23);
            this.getNodesRatingButt.TabIndex = 12;
            this.getNodesRatingButt.Text = "Get Rating";
            this.getNodesRatingButt.UseVisualStyleBackColor = true;
            this.getNodesRatingButt.Click += new System.EventHandler(this.GetNodesRatingButt_Click);
            // 
            // expAmountTB
            // 
            this.expAmountTB.Location = new System.Drawing.Point(668, 377);
            this.expAmountTB.Name = "expAmountTB";
            this.expAmountTB.Size = new System.Drawing.Size(172, 20);
            this.expAmountTB.TabIndex = 13;
            this.expAmountTB.Text = "10000";
            // 
            // reliabilityLB
            // 
            this.reliabilityLB.AutoSize = true;
            this.reliabilityLB.Location = new System.Drawing.Point(668, 264);
            this.reliabilityLB.Name = "reliabilityLB";
            this.reliabilityLB.Size = new System.Drawing.Size(51, 13);
            this.reliabilityLB.TabIndex = 14;
            this.reliabilityLB.Text = "Reliability";
            // 
            // expNumLB
            // 
            this.expNumLB.AutoSize = true;
            this.expNumLB.Location = new System.Drawing.Point(668, 361);
            this.expNumLB.Name = "expNumLB";
            this.expNumLB.Size = new System.Drawing.Size(116, 13);
            this.expNumLB.TabIndex = 14;
            this.expNumLB.Text = "Number of Experiments";
            // 
            // ExperimentPrecisionButton
            // 
            this.ExperimentPrecisionButton.Location = new System.Drawing.Point(668, 69);
            this.ExperimentPrecisionButton.Name = "ExperimentPrecisionButton";
            this.ExperimentPrecisionButton.Size = new System.Drawing.Size(172, 23);
            this.ExperimentPrecisionButton.TabIndex = 15;
            this.ExperimentPrecisionButton.Text = "Show experiment precision";
            this.ExperimentPrecisionButton.UseVisualStyleBackColor = true;
            this.ExperimentPrecisionButton.Click += new System.EventHandler(this.ExperimentPrecisionButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.ExperimentPrecisionButton);
            this.Controls.Add(this.expNumLB);
            this.Controls.Add(this.reliabilityLB);
            this.Controls.Add(this.expAmountTB);
            this.Controls.Add(this.getNodesRatingButt);
            this.Controls.Add(this.calculateButt);
            this.Controls.Add(this.pathsTB);
            this.Controls.Add(this.startExpButt);
            this.Controls.Add(this.FindButt);
            this.Controls.Add(this.AltConnectingCB);
            this.Controls.Add(this.setEndButt);
            this.Controls.Add(this.setStartButt);
            this.Controls.Add(this.redrawButt);
            this.Controls.Add(this.deleteButt);
            this.Controls.Add(this.coordsLabel);
            this.Controls.Add(this.chanceTB);
            this.Controls.Add(this.saveButt);
            this.Controls.Add(this.MainPB);
            this.Name = "MainForm";
            this.Text = "GraphDraw";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.MainPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPB;
        private System.Windows.Forms.Button saveButt;
        private System.Windows.Forms.TextBox chanceTB;
        private System.Windows.Forms.Label coordsLabel;
        private System.Windows.Forms.Button deleteButt;
        private System.Windows.Forms.Button redrawButt;
        private System.Windows.Forms.Button setStartButt;
        private System.Windows.Forms.Button setEndButt;
        private System.Windows.Forms.CheckBox AltConnectingCB;
        private System.Windows.Forms.Button FindButt;
        private System.Windows.Forms.Button startExpButt;
        private System.Windows.Forms.RichTextBox pathsTB;
        private System.Windows.Forms.Button calculateButt;
        private System.Windows.Forms.Button getNodesRatingButt;
        private System.Windows.Forms.TextBox expAmountTB;
        private System.Windows.Forms.Label reliabilityLB;
        private System.Windows.Forms.Label expNumLB;
        private System.Windows.Forms.Button ExperimentPrecisionButton;
    }
}

