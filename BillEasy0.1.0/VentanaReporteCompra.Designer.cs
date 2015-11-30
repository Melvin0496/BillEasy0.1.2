namespace BillEasy0._1._0
{
    partial class VentanaReporteCompra
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
            this.CompraCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CompraCrystalReportViewer
            // 
            this.CompraCrystalReportViewer.ActiveViewIndex = -1;
            this.CompraCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompraCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CompraCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompraCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CompraCrystalReportViewer.Name = "CompraCrystalReportViewer";
            this.CompraCrystalReportViewer.Size = new System.Drawing.Size(679, 540);
            this.CompraCrystalReportViewer.TabIndex = 0;
            // 
            // VentanaReporteCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 540);
            this.Controls.Add(this.CompraCrystalReportViewer);
            this.Name = "VentanaReporteCompra";
            this.Text = "VentanaReporteCompra";
            this.Load += new System.EventHandler(this.VentanaReporteCompra_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CompraCrystalReportViewer;
    }
}