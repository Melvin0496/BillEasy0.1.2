namespace BillEasy0._1._0
{
    partial class ConsultaVentas
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
            this.VentascomboBox = new System.Windows.Forms.ComboBox();
            this.VentastextBox = new System.Windows.Forms.TextBox();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.VentasdataGridView = new System.Windows.Forms.DataGridView();
            this.Imprimirbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VentasdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VentascomboBox
            // 
            this.VentascomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VentascomboBox.FormattingEnabled = true;
            this.VentascomboBox.Items.AddRange(new object[] {
            "VentaId"});
            this.VentascomboBox.Location = new System.Drawing.Point(12, 75);
            this.VentascomboBox.Name = "VentascomboBox";
            this.VentascomboBox.Size = new System.Drawing.Size(122, 21);
            this.VentascomboBox.TabIndex = 0;
            // 
            // VentastextBox
            // 
            this.VentastextBox.Location = new System.Drawing.Point(140, 75);
            this.VentastextBox.Name = "VentastextBox";
            this.VentastextBox.Size = new System.Drawing.Size(434, 20);
            this.VentastextBox.TabIndex = 1;
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::BillEasy0._1._0.Properties.Resources._1443839488_file_search;
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(580, 63);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(74, 42);
            this.Buscarbutton.TabIndex = 2;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // VentasdataGridView
            // 
            this.VentasdataGridView.AllowUserToAddRows = false;
            this.VentasdataGridView.AllowUserToDeleteRows = false;
            this.VentasdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VentasdataGridView.Location = new System.Drawing.Point(12, 111);
            this.VentasdataGridView.Name = "VentasdataGridView";
            this.VentasdataGridView.ReadOnly = true;
            this.VentasdataGridView.Size = new System.Drawing.Size(642, 210);
            this.VentasdataGridView.TabIndex = 3;
            // 
            // Imprimirbutton
            // 
            this.Imprimirbutton.Image = global::BillEasy0._1._0.Properties.Resources._1446228633_kde_folder_print;
            this.Imprimirbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Imprimirbutton.Location = new System.Drawing.Point(571, 327);
            this.Imprimirbutton.Name = "Imprimirbutton";
            this.Imprimirbutton.Size = new System.Drawing.Size(83, 39);
            this.Imprimirbutton.TabIndex = 4;
            this.Imprimirbutton.Text = "Imprimir";
            this.Imprimirbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Imprimirbutton.UseVisualStyleBackColor = true;
            this.Imprimirbutton.Click += new System.EventHandler(this.Imprimirbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Consulta de Ventas";
            // 
            // ConsultaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 368);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Imprimirbutton);
            this.Controls.Add(this.VentasdataGridView);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.VentastextBox);
            this.Controls.Add(this.VentascomboBox);
            this.Name = "ConsultaVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaVentas";
            ((System.ComponentModel.ISupportInitialize)(this.VentasdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox VentascomboBox;
        private System.Windows.Forms.TextBox VentastextBox;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.DataGridView VentasdataGridView;
        private System.Windows.Forms.Button Imprimirbutton;
        private System.Windows.Forms.Label label1;
    }
}