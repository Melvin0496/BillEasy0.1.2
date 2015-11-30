using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace BillEasy0._1._0
{
    public partial class ConsultaMarca : Form
    {
        public ConsultaMarca()
        {
            InitializeComponent();
            BuscarComboBox.SelectedIndex = 0;
        }

        private void BuscarButton_Click(object sender, System.EventArgs e)
        {
            Marcas marca = new Marcas();
            string condicion;

            if (BuscarComboBox.SelectedIndex == 0)
            {
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    condicion = "1=1";
                }
                else
                {
                    int id;
                    int.TryParse(DatosTextBox.Text, out id);
                    condicion = "MarcaId = " + id.ToString();
                }
                DatosDataGridView.DataSource = marca.Listado(" MarcaId, Nombre", condicion, "");
            }
            if (BuscarComboBox.SelectedIndex == 1)
            {
                if (DatosTextBox.Text.Trim().Length == 1)
                {
                    condicion = "2=2";
                }
                else
                {
                    condicion = string.Format("Nombre like '{0}%' ", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = marca.Listado(" MarcaId, Nombre", condicion, "");
            }
        }

        private void ImprimirButton_Click(object sender, System.EventArgs e)
        {
            VentanaReporteMarca marca = new VentanaReporteMarca();
            marca.Show();
        }
    }
}