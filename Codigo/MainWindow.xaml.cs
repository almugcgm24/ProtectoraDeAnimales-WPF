using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace LabIPO
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dominio.Persona usuarioConectado;
        public MainWindow()
        {
            InitializeComponent();
        }

        /*Boton Conectar*/
        private void btnConectar_Click(object sender, RoutedEventArgs e)
        {
            String usuario = txtUsuario.Text;
            String contrasenia = txtContrasena.Password;

            Boolean pasar = comprobarUsCon(usuario, contrasenia);


            if (pasar == true)
            {
                Presentación.menuPrincipal ventana = new Presentación.menuPrincipal(usuarioConectado);

                ventana.Show();
                this.Close();
            }
        }

        private Boolean comprobarUsCon(String us, String con)
        {
            List<Dominio.Persona> listadoPersonas = cargarPersonas();
            int posicion = listadoPersonas.FindIndex(x => x.usuario == us);
            if (posicion == -1)
            {
                MessageBox.Show("No existe el usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsuario.Background = Brushes.Red;
                txtContrasena.Background = Brushes.White;
                txtUsuario.Clear();
                txtContrasena.Clear();
                return false;
            }
            else if (listadoPersonas[posicion].contrasenia != con)
            {
                MessageBox.Show("La contraseña es incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsuario.Background = Brushes.Green;
                txtContrasena.Background = Brushes.Red;
                txtContrasena.Clear();
                return false;
            }
            else
                this.usuarioConectado = listadoPersonas[posicion];
            return true;
        }

        private List<Dominio.Persona> cargarPersonas()
        {
            List<Dominio.Persona> listadoPersonas = new List<Dominio.Persona>();

            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("texto/personas.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                Dominio.Persona nuevaPersona = new Dominio.Persona("", "", "", "", "", "", null);

                nuevaPersona.usuario = node.Attributes["usuario"].Value;
                nuevaPersona.apellidos = node.Attributes["apellidos"].Value;
                nuevaPersona.contrasenia = node.Attributes["contrasenia"].Value;
                nuevaPersona.dni = node.Attributes["telefono"].Value;
                nuevaPersona.telefono = node.Attributes["telefono"].Value;
                nuevaPersona.ultimoAcceso = node.Attributes["ultimoAcceso"].Value;
                nuevaPersona.foto = new Uri(node.Attributes["foto"].Value, UriKind.Absolute);

                listadoPersonas.Add(nuevaPersona);
            }

            return listadoPersonas;

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnEspanol_Click(object sender, RoutedEventArgs e)
        {
            lblUsuario.Content = "Usuario";
            lblContrasena.Content = "Contraseña";
            btnConectar.Content = "CONECTAR";
        }
        private void btnIngles_Click(object sender, RoutedEventArgs e)
        {
            lblUsuario.Content = "User";
            lblContrasena.Content = "Password";
            btnConectar.Content = "CONNECT";
        }


    }
}
