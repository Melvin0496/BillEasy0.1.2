namespace BillEasy0._1._0
{
    partial class VentanaReporteCliente
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
            this.ClienteCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ClienteCrystalReportViewer
            // 
            this.ClienteCrystalReportViewer.ActiveViewIndex = -1;
            this.ClienteCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClienteCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClienteCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClienteCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ClienteCrystalReportViewer.Name = "ClienteCrystalReportViewer";
            this.ClienteCrystalReportViewer.Size = new System.Drawing.Size(825, 486);
            this.ClienteCrystalReportViewer.TabIndex = 0;
            // 
            // VentanaReporteCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 486);
            this.Controls.Add(this.ClienteCrystalReportViewer);
            this.Name = "VentanaReporteCliente";
            this.Text = "VentanaReporteCliente";
            this.Load += new System.EventHandler(this.VentanaReporteCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer ClienteCrystalReportViewer;
    }
}