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
            this.VentasComboBox = new System.Windows.Forms.ComboBox();
            this.VentasTextBox = new System.Windows.Forms.TextBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.VentasDataGridView = new System.Windows.Forms.DataGridView();
            this.ImprimirButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VentasDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VentasComboBox
            // 
            this.VentasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VentasComboBox.FormattingEnabled = true;
            this.VentasComboBox.Items.AddRange(new object[] {
            "VentaId"});
            this.VentasComboBox.Location = new System.Drawing.Point(12, 75);
            this.VentasComboBox.Name = "VentasComboBox";
            this.VentasComboBox.Size = new System.Drawing.Size(122, 21);
            this.VentasComboBox.TabIndex = 0;
            // 
            // VentasTextBox
            // 
            this.VentasTextBox.Location = new System.Drawing.Point(140, 75);
            this.VentasTextBox.Name = "VentasTextBox";
            this.VentasTextBox.Size = new System.Drawing.Size(434, 20);
            this.VentasTextBox.TabIndex = 1;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::BillEasy0._1._0.Properties.Resources._1443839488_file_search;
            this.BuscarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuscarButton.Location = new System.Drawing.Point(580, 63);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(74, 42);
            this.BuscarButton.TabIndex = 2;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // VentasDataGridView
            // 
            this.VentasDataGridView.AllowUserToAddRows = false;
            this.VentasDataGridView.AllowUserToDeleteRows = false;
            this.VentasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VentasDataGridView.Location = new System.Drawing.Point(12, 111);
            this.VentasDataGridView.Name = "VentasDataGridView";
            this.VentasDataGridView.ReadOnly = true;
            this.VentasDataGridView.Size = new System.Drawing.Size(642, 210);
            this.VentasDataGridView.TabIndex = 3;
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Image = global::BillEasy0._1._0.Properties.Resources._1446228633_kde_folder_print;
            this.ImprimirButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImprimirButton.Location = new System.Drawing.Point(571, 327);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(83, 39);
            this.ImprimirButton.TabIndex = 4;
            this.ImprimirButton.Text = "Imprimir";
            this.ImprimirButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ImprimirButton.UseVisualStyleBackColor = true;
            this.ImprimirButton.Click += new System.EventHandler(this.ImprimirButton_Click);
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
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.VentasDataGridView);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.VentasTextBox);
            this.Controls.Add(this.VentasComboBox);
            this.Name = "ConsultaVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaVentas";
            ((System.ComponentModel.ISupportInitialize)(this.VentasDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox VentasComboBox;
        private System.Windows.Forms.TextBox VentasTextBox;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridView VentasDataGridView;
        private System.Windows.Forms.Button ImprimirButton;
        private System.Windows.Forms.Label label1;
    }
}