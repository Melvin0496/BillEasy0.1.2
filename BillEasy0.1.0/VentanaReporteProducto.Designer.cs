namespace BillEasy0._1._0
{
    partial class VentanaReporteProducto
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
            this.ProductoCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ProductoCrystalReportViewer
            // 
            this.ProductoCrystalReportViewer.ActiveViewIndex = -1;
            this.ProductoCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductoCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProductoCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductoCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ProductoCrystalReportViewer.Name = "ProductoCrystalReportViewer";
            this.ProductoCrystalReportViewer.Size = new System.Drawing.Size(644, 426);
            this.ProductoCrystalReportViewer.TabIndex = 0;
            // 
            // VentanaReporteProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 426);
            this.Controls.Add(this.ProductoCrystalReportViewer);
            this.Name = "VentanaReporteProducto";
            this.Text = "VentanaReporteProducto";
            this.Load += new System.EventHandler(this.VentanaReporteProducto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ProductoCrystalReportViewer;
    }
}