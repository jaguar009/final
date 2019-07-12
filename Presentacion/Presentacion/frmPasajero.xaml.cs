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
    /// Interaction logic for frmPasajero.xaml
    /// </summary>
    public partial class frmPasajero : Window
    {
        private nPasajero gpasajero = new nPasajero();//Para las operaciones Crear,Actualizar,Eliminar, Buscar y Listar Pasajeros
        private nPais gpais = new nPais(); // Necesito el GestorPais, para listar los paises 

        ePais pais = null;
        ePasajero pasajero = null;
        int idpasajero;

        public frmPasajero()
        {
            InitializeComponent();
            MostrarPasajeros();
            MostrarPais();
        }

        private void MostrarPais()
        {
            cbopais.ItemsSource = gpais.Listarpais();
        }
        private void MostrarPasajeros()
        {
            dgpasajeros.ItemsSource = gpasajero.Listarpasajero();
        }

        private void btnregistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text != "" && txtapellido.Text != "" && cbopais.SelectedIndex != -1)
            {
                MessageBox.Show(gpasajero.Registrarpasajero(txtnombre.Text, txtapellido.Text, pais.Idpais));
                MostrarPasajeros();
                txtnombre.Clear();
                txtapellido.Clear();
                cbopais.SelectedIndex = -1;
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            if (pasajero != null)
            {
                if (txtnombre.Text != "" && txtapellido.Text != "" && cbopais.SelectedIndex != -1)
                {
                    MessageBox.Show(gpasajero.Modificarpasajero(pasajero.Idpasajero, txtnombre.Text, txtapellido.Text, pais.Idpais));
                    MostrarPasajeros();
                    txtnombre.Clear();
                    txtapellido.Clear();
                    cbopais.SelectedIndex = -1;
                }
                else
                    MessageBox.Show("Por favor debe completar todos los datos");
            }
            else
                MessageBox.Show("Por favor debe seleccionar un pasajero de la lista");
            txtnombre.Focus();
        }

        private void cbopais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pais = cbopais.SelectedItem as ePais;
        }

        private void dgpasajeros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Recupero el objeto pasajero, al momento de seleccionar un registro del Datagrid
            pasajero = dgpasajeros.SelectedItem as ePasajero;

            if (pasajero != null)
            {
                idpasajero = pasajero.Idpasajero;
                cbopais.Text = pasajero.pais.Nombrepais;
                txtnombre.Text = pasajero.Nombre;
                txtapellido.Text = pasajero.Apellido;
            }
        }

        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            if (pasajero != null)
            {
                MessageBox.Show(gpasajero.Eliminarpasajero(pasajero.Idpasajero));
                MostrarPasajeros();
            }
            else
                MessageBox.Show("Por favor debe seleccionar un pasajero de la lista");
            txtnombre.Focus();
        }
    }
}
