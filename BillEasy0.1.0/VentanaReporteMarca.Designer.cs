namespace BillEasy0._1._0
{
    partial class VentanaReporteMarca
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
            this.ReporteCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReporteCrystalReportViewer
            // 
            this.ReporteCrystalReportViewer.ActiveViewIndex = -1;
            this.ReporteCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReporteCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReporteCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReporteCrystalReportViewer.Name = "ReporteCrystalReportViewer";
            this.ReporteCrystalReportViewer.Size = new System.Drawing.Size(733, 449);
            this.ReporteCrystalReportViewer.TabIndex = 0;
            // 
            // VentanaReporteMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 449);
            this.Controls.Add(this.ReporteCrystalReportViewer);
            this.Name = "VentanaReporteMarca";
            this.Text = "VentanaReporteMarca";
            this.Load += new System.EventHandler(this.VentanaReporteMarca_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer ReporteCrystalReportViewer;
    }
}