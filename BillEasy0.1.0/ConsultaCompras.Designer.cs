namespace BillEasy0._1._0
{
    partial class ConsultaCompras
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
            this.ComprascomboBox = new System.Windows.Forms.ComboBox();
            this.ComprastextBox = new System.Windows.Forms.TextBox();
            this.Imprimirbutton = new System.Windows.Forms.Button();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.ComprasdataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ComprasdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ComprascomboBox
            // 
            this.ComprascomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComprascomboBox.FormattingEnabled = true;
            this.ComprascomboBox.Items.AddRange(new object[] {
            "CompraId"});
            this.ComprascomboBox.Location = new System.Drawing.Point(12, 77);
            this.ComprascomboBox.Name = "ComprascomboBox";
            this.ComprascomboBox.Size = new System.Drawing.Size(121, 21);
            this.ComprascomboBox.TabIndex = 0;
            // 
            // ComprastextBox
            // 
            this.ComprastextBox.Location = new System.Drawing.Point(139, 77);
            this.ComprastextBox.Name = "ComprastextBox";
            this.ComprastextBox.Size = new System.Drawing.Size(434, 20);
            this.ComprastextBox.TabIndex = 1;
            // 
            // Imprimirbutton
            // 
            this.Imprimirbutton.Image = global::BillEasy0._1._0.Properties.Resources._1446228633_kde_folder_print;
            this.Imprimirbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Imprimirbutton.Location = new System.Drawing.Point(574, 317);
            this.Imprimirbutton.Name = "Imprimirbutton";
            this.Imprimirbutton.Size = new System.Drawing.Size(80, 39);
            this.Imprimirbutton.TabIndex = 2;
            this.Imprimirbutton.Text = "Imprimir";
            this.Imprimirbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Imprimirbutton.UseVisualStyleBackColor = true;
            this.Imprimirbutton.Click += new System.EventHandler(this.Imprimirbutton_Click);
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::BillEasy0._1._0.Properties.Resources._1443839488_file_search;
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(579, 66);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(75, 40);
            this.Buscarbutton.TabIndex = 3;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // ComprasdataGridView
            // 
            this.ComprasdataGridView.AllowUserToAddRows = false;
            this.ComprasdataGridView.AllowUserToDeleteRows = false;
            this.ComprasdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComprasdataGridView.Location = new System.Drawing.Point(12, 112);
            this.ComprasdataGridView.Name = "ComprasdataGridView";
            this.ComprasdataGridView.ReadOnly = true;
            this.ComprasdataGridView.Size = new System.Drawing.Size(642, 199);
            this.ComprasdataGridView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Consulta de Compras";
            // 
            // ConsultaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 368);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComprasdataGridView);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.Imprimirbutton);
            this.Controls.Add(this.ComprastextBox);
            this.Controls.Add(this.ComprascomboBox);
            this.Name = "ConsultaCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaCompras";
            ((System.ComponentModel.ISupportInitialize)(this.ComprasdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComprascomboBox;
        private System.Windows.Forms.TextBox ComprastextBox;
        private System.Windows.Forms.Button Imprimirbutton;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.DataGridView ComprasdataGridView;
        private System.Windows.Forms.Label label1;
    }
}