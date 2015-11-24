namespace BillEasy0._1._0
{
    partial class VentanaReporteVenta
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
            this.VentaCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // VentaCrystalReportViewer
            // 
            this.VentaCrystalReportViewer.ActiveViewIndex = -1;
            this.VentaCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VentaCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.VentaCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VentaCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.VentaCrystalReportViewer.Name = "VentaCrystalReportViewer";
            this.VentaCrystalReportViewer.Size = new System.Drawing.Size(968, 482);
            this.VentaCrystalReportViewer.TabIndex = 0;
            // 
            // VentanaReporteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 482);
            this.Controls.Add(this.VentaCrystalReportViewer);
            this.MinimizeBox = false;
            this.Name = "VentanaReporteVenta";
            this.Text = "VentanReporteVenta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VentanReporteVenta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer VentaCrystalReportViewer;
    }
}