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
            this.ComprasComboBox = new System.Windows.Forms.ComboBox();
            this.ComprasTextBox = new System.Windows.Forms.TextBox();
            this.ImprimirButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.ComprasDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ComprasDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ComprasComboBox
            // 
            this.ComprasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComprasComboBox.FormattingEnabled = true;
            this.ComprasComboBox.Items.AddRange(new object[] {
            "CompraId"});
            this.ComprasComboBox.Location = new System.Drawing.Point(12, 77);
            this.ComprasComboBox.Name = "ComprasComboBox";
            this.ComprasComboBox.Size = new System.Drawing.Size(121, 21);
            this.ComprasComboBox.TabIndex = 0;
            // 
            // ComprasTextBox
            // 
            this.ComprasTextBox.Location = new System.Drawing.Point(139, 77);
            this.ComprasTextBox.Name = "ComprasTextBox";
            this.ComprasTextBox.Size = new System.Drawing.Size(434, 20);
            this.ComprasTextBox.TabIndex = 1;
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Image = global::BillEasy0._1._0.Properties.Resources._1446228633_kde_folder_print;
            this.ImprimirButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImprimirButton.Location = new System.Drawing.Point(574, 317);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(80, 39);
            this.ImprimirButton.TabIndex = 2;
            this.ImprimirButton.Text = "Imprimir";
            this.ImprimirButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ImprimirButton.UseVisualStyleBackColor = true;
            this.ImprimirButton.Click += new System.EventHandler(this.ImprimirButton_Click);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::BillEasy0._1._0.Properties.Resources._1443839488_file_search;
            this.BuscarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuscarButton.Location = new System.Drawing.Point(579, 66);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 40);
            this.BuscarButton.TabIndex = 3;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // ComprasDataGridView
            // 
            this.ComprasDataGridView.AllowUserToAddRows = false;
            this.ComprasDataGridView.AllowUserToDeleteRows = false;
            this.ComprasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComprasDataGridView.Location = new System.Drawing.Point(12, 112);
            this.ComprasDataGridView.Name = "ComprasDataGridView";
            this.ComprasDataGridView.ReadOnly = true;
            this.ComprasDataGridView.Size = new System.Drawing.Size(642, 199);
            this.ComprasDataGridView.TabIndex = 4;
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
            this.Controls.Add(this.ComprasDataGridView);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.ComprasTextBox);
            this.Controls.Add(this.ComprasComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaCompras";
            ((System.ComponentModel.ISupportInitialize)(this.ComprasDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComprasComboBox;
        private System.Windows.Forms.TextBox ComprasTextBox;
        private System.Windows.Forms.Button ImprimirButton;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridView ComprasDataGridView;
        private System.Windows.Forms.Label label1;
    }
}