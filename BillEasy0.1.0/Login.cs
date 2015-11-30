using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace BillEasy0._1._0
{
    public partial class Login : Form
    {
        ErrorProvider miError;
        public Login()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        public void Limpiar()
        {
            UsuarioTextBox.Clear();
            ContrasenaTextBox.Clear();
        }

        private void AccederButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            

            usuarios.NombreUsuario = UsuarioTextBox.Text;
            usuarios.Contrasena = ContrasenaTextBox.Text;

            if (UsuarioTextBox.TextLength == 0 || ContrasenaTextBox.TextLength == 0)
            {
                miError.Clear();
                miError.SetError(UsuarioTextBox, "Debe llenar este Campo");
            }
            else
            {
                if (usuarios.VerificarUsuario() == UsuarioTextBox.Text && usuarios.VerificarContrasena() == ContrasenaTextBox.Text)
                {

                    usuarios.Area = usuarios.GetArea(UsuarioTextBox.Text).ToString();
                   
                    if(usuarios.Area != "Aministracion")
                    {
                        this.Visible = false;
                        this.Hide();
                        BillEasy billEasy = new BillEasy();
                        billEasy.nuevoToolStripMenuItem.Visible = true;
                       billEasy.ShowDialog();

                        
                        

                    }else
                    {
                        this.Visible = false;
                        this.Hide();
                        BillEasy billEasy = new BillEasy();
                        billEasy.nuevoToolStripMenuItem.Visible = true;
                        billEasy.ShowDialog();
                       
                    }

                }
                else
                {
                    MessageBox.Show("Nombre de Usuario o Contraseña Incorrecta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
