namespace BillEasy0._1._0
{
    partial class ConsultaProveedores
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
            this.button1 = new System.Windows.Forms.Button();
            this.DatosDataGridView = new System.Windows.Forms.DataGridView();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.DatosTextBox = new System.Windows.Forms.TextBox();
            this.BuscarComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::BillEasy0._1._0.Properties.Resources._1446228633_kde_folder_print;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(573, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "Imprimir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DatosDataGridView
            // 
            this.DatosDataGridView.AllowUserToAddRows = false;
            this.DatosDataGridView.AllowUserToDeleteRows = false;
            this.DatosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDataGridView.Location = new System.Drawing.Point(12, 102);
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.Size = new System.Drawing.Size(642, 217);
            this.DatosDataGridView.TabIndex = 15;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::BillEasy0._1._0.Properties.Resources._1443839488_file_search;
            this.BuscarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuscarButton.Location = new System.Drawing.Point(579, 53);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 43);
            this.BuscarButton.TabIndex = 14;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // DatosTextBox
            // 
            this.DatosTextBox.Location = new System.Drawing.Point(139, 65);
            this.DatosTextBox.Name = "DatosTextBox";
            this.DatosTextBox.Size = new System.Drawing.Size(434, 20);
            this.DatosTextBox.TabIndex = 13;
            // 
            // BuscarComboBox
            // 
            this.BuscarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuscarComboBox.FormattingEnabled = true;
            this.BuscarComboBox.Items.AddRange(new object[] {
            "Proveedor Id ",
            "Nombre Empresa ",
            " RNC",
            "Nombre Representante "});
            this.BuscarComboBox.Location = new System.Drawing.Point(12, 65);
            this.BuscarComboBox.Name = "BuscarComboBox";
            this.BuscarComboBox.Size = new System.Drawing.Size(121, 21);
            this.BuscarComboBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 36);
            this.label1.TabIndex = 17;
            this.label1.Text = "Consulta de Proveedores";
            // 
            // ConsultaProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 368);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DatosDataGridView);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.DatosTextBox);
            this.Controls.Add(this.BuscarComboBox);
            this.Name = "ConsultaProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.TextBox DatosTextBox;
        private System.Windows.Forms.ComboBox BuscarComboBox;
        private System.Windows.Forms.Label label1;
    }
}