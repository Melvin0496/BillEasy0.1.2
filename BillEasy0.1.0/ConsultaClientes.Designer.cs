namespace BillEasy0._1._0
{
    partial class ConsultaClientes
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
            this.label1 = new System.Windows.Forms.Label();
            this.BuscarClientesComboBox = new System.Windows.Forms.ComboBox();
            this.ClientesTextBox = new System.Windows.Forms.TextBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.ClientesDataGridView = new System.Windows.Forms.DataGridView();
            this.Imprimirbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consulta de clientes";
            // 
            // BuscarClientesComboBox
            // 
            this.BuscarClientesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuscarClientesComboBox.FormattingEnabled = true;
            this.BuscarClientesComboBox.Items.AddRange(new object[] {
            "ClienteId",
            "Nombres",
            "Apellidos",
            "Telefono",
            "Celular",
            "Cedula"});
            this.BuscarClientesComboBox.Location = new System.Drawing.Point(12, 57);
            this.BuscarClientesComboBox.Name = "BuscarClientesComboBox";
            this.BuscarClientesComboBox.Size = new System.Drawing.Size(121, 21);
            this.BuscarClientesComboBox.TabIndex = 1;
            // 
            // ClientesTextBox
            // 
            this.ClientesTextBox.Location = new System.Drawing.Point(139, 58);
            this.ClientesTextBox.Name = "ClientesTextBox";
            this.ClientesTextBox.Size = new System.Drawing.Size(434, 20);
            this.ClientesTextBox.TabIndex = 2;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::BillEasy0._1._0.Properties.Resources._1443839488_file_search;
            this.BuscarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuscarButton.Location = new System.Drawing.Point(579, 47);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 40);
            this.BuscarButton.TabIndex = 3;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // ClientesDataGridView
            // 
            this.ClientesDataGridView.AllowUserToAddRows = false;
            this.ClientesDataGridView.AllowUserToDeleteRows = false;
            this.ClientesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientesDataGridView.Location = new System.Drawing.Point(12, 92);
            this.ClientesDataGridView.Name = "ClientesDataGridView";
            this.ClientesDataGridView.ReadOnly = true;
            this.ClientesDataGridView.Size = new System.Drawing.Size(642, 202);
            this.ClientesDataGridView.TabIndex = 4;
            // 
            // Imprimirbutton
            // 
            this.Imprimirbutton.Image = global::BillEasy0._1._0.Properties.Resources._1446228633_kde_folder_print;
            this.Imprimirbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Imprimirbutton.Location = new System.Drawing.Point(572, 300);
            this.Imprimirbutton.Name = "Imprimirbutton";
            this.Imprimirbutton.Size = new System.Drawing.Size(82, 36);
            this.Imprimirbutton.TabIndex = 6;
            this.Imprimirbutton.Text = "Imprimir";
            this.Imprimirbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Imprimirbutton.UseVisualStyleBackColor = true;
            this.Imprimirbutton.Click += new System.EventHandler(this.ImprimirButton_Click);
            // 
            // ConsultaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 368);
            this.Controls.Add(this.Imprimirbutton);
            this.Controls.Add(this.ClientesDataGridView);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.ClientesTextBox);
            this.Controls.Add(this.BuscarClientesComboBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de clientes";
            ((System.ComponentModel.ISupportInitialize)(this.ClientesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BuscarClientesComboBox;
        private System.Windows.Forms.TextBox ClientesTextBox;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridView ClientesDataGridView;
        private System.Windows.Forms.Button Imprimirbutton;
    }
}