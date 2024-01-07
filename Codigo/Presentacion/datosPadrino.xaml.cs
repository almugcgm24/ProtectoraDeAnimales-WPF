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

namespace LabIPO.Presentacion
{
    /// <summary>
    /// Lógica de interacción para datosPadrino.xaml
    /// </summary>
    public partial class datosPadrino : Window
    {
        Dominio.Padrino padrino;
        public datosPadrino(Dominio.Padrino pd)
        {
            InitializeComponent();
            this.padrino = pd;
            mostrarDatos();
        }

        public void mostrarDatos()
        {
            DataContext = this.padrino;
            nombrePadrino.Text = padrino.nombre;
            apellidosPadrino.Text = padrino.apellidos;
            emailPadrino.Text = padrino.email;
            dniPadrino.Text = padrino.dni;
            domicilioPadrino.Text = padrino.domicilio;
            telefonoPadrino.Text = padrino.telefono;
            aportacionPadrino.Text = Convert.ToString(padrino.aportacionMensual);
            pagoPadrino.Text = padrino.formaPago;
            cuentaPadrino.Text = padrino.numeroCuenta;
            fechaPadrino.Text = Convert.ToString(padrino.fechaComienzoApadri);
        }
    }
}
