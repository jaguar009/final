using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entidades;
using Negocio;
namespace Presentacion
{
    /// <summary>
    /// Interaction logic for frmPais.xaml
    /// </summary>
    public partial class frmPais : Window
    {
        nPais gp = new nPais();
        ePais paisseleccionado = null;
        int codpais;
        public frmPais()
        {
            InitializeComponent();
            MostrarPaises();
        }
        private void MostrarPaises()
        {
            dgpaises.ItemsSource = gp.Listarpais();
        }

        private void btnregistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text != "")
            {
                MessageBox.Show(gp.RegistrarPais(txtnombre.Text));
                MostrarPaises();
            }
            else
                MessageBox.Show("Por favor debe ingresar un nombre");
            txtnombre.Clear();
            txtnombre.Focus();
        }

        private void dgpaises_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paisseleccionado = dgpaises.SelectedItem as ePais;
            if(paisseleccionado!=null)
            {
                codpais = paisseleccionado.Idpais;
                txtnombre.Text = paisseleccionado.Nombrepais;
            }
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            if (paisseleccionado != null)
            {
                if (txtnombre.Text != "")
                {
                    MessageBox.Show(gp.Modificarpais(codpais, txtnombre.Text));
                    MostrarPaises();
                }
                else
                    MessageBox.Show("Por favor debe ingresar un nombre");
            }
            else
                MessageBox.Show("Por favor debe seleccionar un pais");
            txtnombre.Clear();
            txtnombre.Focus();
        }

        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            if (paisseleccionado != null)
            {
                MessageBox.Show(gp.Eliminarpais(codpais));
                MostrarPaises();
            }
            else
                MessageBox.Show("Por favor debe seleccionar un pais");
            txtnombre.Focus();
        }
    }
}
