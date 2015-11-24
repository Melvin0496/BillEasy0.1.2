namespace BillEasy0._1._0
{
    partial class VentanaReporteProveedor
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
            this.ProveedorCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ProveedorCrystalReportViewer
            // 
            this.ProveedorCrystalReportViewer.ActiveViewIndex = -1;
            this.ProveedorCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProveedorCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProveedorCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProveedorCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ProveedorCrystalReportViewer.Name = "ProveedorCrystalReportViewer";
            this.ProveedorCrystalReportViewer.Size = new System.Drawing.Size(782, 470);
            this.ProveedorCrystalReportViewer.TabIndex = 0;
            // 
            // VentanaReporteProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 470);
            this.Controls.Add(this.ProveedorCrystalReportViewer);
            this.Name = "VentanaReporteProveedor";
            this.Text = "VentanaReporteProveedor";
            this.Load += new System.EventHandler(this.VentanaReporteProveedor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer ProveedorCrystalReportViewer;
    }
}