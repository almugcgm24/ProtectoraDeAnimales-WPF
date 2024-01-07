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
    /// Lógica de interacción para infoExtraPerro.xaml
    /// </summary>
    public partial class infoExtraPerro : Window
    {
        Dominio.Perro perro;
        public infoExtraPerro(Dominio.Perro p)
        {
            InitializeComponent();
            this.perro = p;
            DataContext = this.perro;
            mostrarDatos();
        }

        public void mostrarDatos()
        {
            cachorroPerro.IsChecked = perro.cachorro;
            pppPerro.IsChecked = perro.ppp;
            vacunadoPerro.IsChecked = perro.vacunado;
            leishmaniosisPerro.IsChecked = perro.leishmaniosis;
            sociPerroPerro.IsChecked = perro.sociableConPerros;
            sociNinosPerro.IsChecked = perro.sociableConNinios;
            sociGatosPerro.IsChecked = perro.sociableConGatos;
            sociAnimalesPerro.IsChecked = perro.sociableCualquierAnimal;
            estadoPerro.Text = perro.estadoPerro;
            descripcionPerro.Text = perro.descripcionPerro;
            

        }
    }
}
