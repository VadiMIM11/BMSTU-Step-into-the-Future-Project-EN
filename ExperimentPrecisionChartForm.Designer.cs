
namespace MyGraphProjectCSS
{
    partial class ExperimentPrecisionChartForm
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
            this.components = new System.ComponentModel.Container();
            this.MainPlot = new OxyPlot.WindowsForms.PlotView();
            this.PleaseWaitLabel = new System.Windows.Forms.Label();
            this.CalculationProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressBarRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MainPlot
            // 
            this.MainPlot.BackColor = System.Drawing.Color.White;
            this.MainPlot.Location = new System.Drawing.Point(12, 12);
            this.MainPlot.Name = "MainPlot";
            this.MainPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.MainPlot.Size = new System.Drawing.Size(776, 409);
            this.MainPlot.TabIndex = 0;
            this.MainPlot.Text = "plotView1";
            this.MainPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.MainPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.MainPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // PleaseWaitLabel
            // 
            this.PleaseWaitLabel.AutoSize = true;
            this.PleaseWaitLabel.BackColor = System.Drawing.Color.White;
            this.PleaseWaitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PleaseWaitLabel.Location = new System.Drawing.Point(326, 196);
            this.PleaseWaitLabel.Name = "PleaseWaitLabel";
            this.PleaseWaitLabel.Size = new System.Drawing.Size(124, 24);
            this.PleaseWaitLabel.TabIndex = 1;
            this.PleaseWaitLabel.Text = "Please, wait...";
            this.PleaseWaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalculationProgressBar
            // 
            this.CalculationProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CalculationProgressBar.Location = new System.Drawing.Point(12, 427);
            this.CalculationProgressBar.Name = "CalculationProgressBar";
            this.CalculationProgressBar.Size = new System.Drawing.Size(776, 23);
            this.CalculationProgressBar.TabIndex = 2;
            // 
            // ProgressBarRefreshTimer
            // 
            this.ProgressBarRefreshTimer.Enabled = true;
            this.ProgressBarRefreshTimer.Interval = 500;
            this.ProgressBarRefreshTimer.Tick += new System.EventHandler(this.ProgressBarRefreshTimer_Tick);
            // 
            // ExperimentPrecisionChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.CalculationProgressBar);
            this.Controls.Add(this.PleaseWaitLabel);
            this.Controls.Add(this.MainPlot);
            this.Name = "ExperimentPrecisionChartForm";
            this.Text = "Relative error of experimental method";
            this.Load += new System.EventHandler(this.ExperimentPrecisionChartForm_Load);
            this.ResizeEnd += new System.EventHandler(this.ExperimentPrecisionChartForm_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView MainPlot;
        private System.Windows.Forms.Label PleaseWaitLabel;
        private System.Windows.Forms.ProgressBar CalculationProgressBar;
        private System.Windows.Forms.Timer ProgressBarRefreshTimer;
    }
}