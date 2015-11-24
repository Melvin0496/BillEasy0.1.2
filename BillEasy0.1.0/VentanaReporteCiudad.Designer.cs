namespace BillEasy0._1._0
{
    partial class VentanaReporteCiudad
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
            this.CiudadCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CiudadCrystalReportViewer
            // 
            this.CiudadCrystalReportViewer.ActiveViewIndex = -1;
            this.CiudadCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CiudadCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CiudadCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CiudadCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CiudadCrystalReportViewer.Name = "CiudadCrystalReportViewer";
            this.CiudadCrystalReportViewer.Size = new System.Drawing.Size(586, 376);
            this.CiudadCrystalReportViewer.TabIndex = 0;
            // 
            // VentanaReporteCiudad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 376);
            this.Controls.Add(this.CiudadCrystalReportViewer);
            this.Name = "VentanaReporteCiudad";
            this.Text = "VentanaReporteCiudad";
            this.Load += new System.EventHandler(this.VentanaReporteCiudad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CiudadCrystalReportViewer;
    }
}