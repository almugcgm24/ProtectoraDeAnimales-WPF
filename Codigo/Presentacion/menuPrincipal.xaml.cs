using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace LabIPO.Presentación
{
    /// <summary>
    /// Lógica de interacción para menuPrincipal.xaml
    /// </summary>
    public partial class menuPrincipal : Window
    {
        Dominio.Persona usCon;

        List<Dominio.Perro> listadoPerros = new List<Dominio.Perro>();
        List<Dominio.Perro> listadoPerrosApadrinados = new List<Dominio.Perro>();
        List<Dominio.Perro> listadoPerrosNoApadrinados = new List<Dominio.Perro>();

        List<Dominio.Padrino> listadoPadrinos = new List<Dominio.Padrino>();

        List<Dominio.Voluntario> listadoVoluntarios = new List<Dominio.Voluntario>();
        List<Dominio.Socio> listadoSocios = new List<Dominio.Socio>();
        List<Dominio.Aviso> listadoAvisos = new List<Dominio.Aviso>();

        public menuPrincipal(Dominio.Persona usuarioConectado)
        {
            InitializeComponent();
            this.usCon = usuarioConectado;
            DataContext = this.usCon;
            mostrarDatosBasicos();
            inicializarListas();

        }
        //INICIAR INTERFAZ
        public void inicializarListas()
        {
            cargarListaPerros();
            ListPerros.DataContext = listadoPerros;

            cargarListaPadrinos();
            ListPadrinos.DataContext = listadoPadrinos;

            cargarListaVoluntarios();
            ListVoluntarios.DataContext = listadoVoluntarios;

            cargarListaSocios();
            ListSocios.DataContext = listadoSocios;

            cargarListaAvisos();
            ListAvisos.DataContext = listadoAvisos;
        }

        public void mostrarDatosBasicos()
        {
            TxtNombreInicio.Text = this.usCon.usuario;
            TxtApellidosInicio.Text = this.usCon.apellidos;
            TxtDniInicio.Text = this.usCon.dni;
            TxtUltimoAccesoInicio.Text = DateTime.Now.ToString("dd-MM-yyyy");
            TxtTelefonoInicio.Text = this.usCon.telefono;

        }

        private void btnSalirPrincipal_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //PERROS
        public void cargarListaPerros()
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("texto/perros.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                DateTime dt = new DateTime(2000, 10, 10);
                Dominio.Perro nuevoPerro = new Dominio.Perro("", "", "", "", 0, 0, dt, false, "", null, false, false, false, false, false, "", false, false, false, false, "");

                nuevoPerro.nombre = node.Attributes["nombre"].Value;
                nuevoPerro.sexo = node.Attributes["sexo"].Value;
                nuevoPerro.raza = node.Attributes["raza"].Value;
                nuevoPerro.tamanio = node.Attributes["tamanio"].Value;
                nuevoPerro.peso = Convert.ToInt32(node.Attributes["peso"].Value);
                nuevoPerro.edad = Convert.ToInt32(node.Attributes["edad"].Value);
                nuevoPerro.fechaEntradaProt = Convert.ToDateTime(node.Attributes["fechaEntradaProt"].Value);
                nuevoPerro.apadrinado = Convert.ToBoolean(node.Attributes["apadrinado"].Value);
                nuevoPerro.nombrePadrino = node.Attributes["nombreApadrinado"].Value;
                nuevoPerro.foto = new Uri(node.Attributes["foto"].Value, UriKind.Absolute);

                nuevoPerro.cachorro = Convert.ToBoolean(node.Attributes["cachorro"].Value);
                nuevoPerro.ppp = Convert.ToBoolean(node.Attributes["ppp"].Value);
                nuevoPerro.vacunado = Convert.ToBoolean(node.Attributes["vacunado"].Value);
                nuevoPerro.esterilizado = Convert.ToBoolean(node.Attributes["esterilizado"].Value);
                nuevoPerro.leishmaniosis = Convert.ToBoolean(node.Attributes["leishmaniosis"].Value);
                
                nuevoPerro.descripcionPerro = node.Attributes["descripcionPerro"].Value;
                nuevoPerro.sociableConPerros = Convert.ToBoolean(node.Attributes["sociableConPerros"].Value);
                nuevoPerro.sociableConNinios = Convert.ToBoolean(node.Attributes["sociableConNinios"].Value);
                nuevoPerro.sociableConGatos = Convert.ToBoolean(node.Attributes["sociableConGatos"].Value);
                nuevoPerro.sociableCualquierAnimal = Convert.ToBoolean(node.Attributes["sociableCualquierAnimal"].Value);
                nuevoPerro.estadoPerro = node.Attributes["estadoPerro"].Value;

                listadoPerros.Add(nuevoPerro);

            }

            cargarListaApadrinados(listadoPerros);
            
        }

        private void cargarListaApadrinados(List<Dominio.Perro> perros) 
        {
            listadoPerrosApadrinados = null;
            listadoPerrosApadrinados = new List<Dominio.Perro>();

            listadoPerrosNoApadrinados = null;
            listadoPerrosNoApadrinados = new List<Dominio.Perro>();

            for (int i = 0; i < perros.Count; i++)
            {

                if (listadoPerros[i].apadrinado == true)
                {
                    listadoPerrosApadrinados.Add(listadoPerros[i]);
                }
                else listadoPerrosNoApadrinados.Add(listadoPerros[i]);
            }
        }

        private void btnApadrinado_Click(object sender, RoutedEventArgs e)
        {
            ListPerros.DataContext = listadoPerrosApadrinados;
        }

        private void btnNoApadrinado_Click(object sender, RoutedEventArgs e)
        {
            ListPerros.DataContext = listadoPerrosNoApadrinados;
        }

        private void btnTodos_Click(object sender, RoutedEventArgs e)
        {
            ListPerros.DataContext = listadoPerros;
        }

        
        private void lblInfoPerro_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Dominio.Perro infoPerro;
            List<Dominio.Perro> listaPerros = (List<Dominio.Perro>)ListPerros.DataContext;
            int indice = ListPerros.SelectedIndex;
            if (indice >= 0)
            {
                infoPerro = listaPerros[indice];

                Presentacion.infoExtraPerro ventana = new Presentacion.infoExtraPerro(infoPerro);
                ventana.Show();
            }
            else
                MessageBox.Show("No ha seleccionado un perro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void btnAnadirPerro_Click(object sender, RoutedEventArgs e)
        {
            ListPerros.SelectedIndex = -1;
            limpiarTextBoxPerro();
            habilitarTextBoxPerro();
            btnAceptarAnadirPerro.Visibility = Visibility.Visible;
            ListPadrinos.DataContext = null;
            ListPadrinos.DataContext = listadoPadrinos;
        }

        private void limpiarTextBoxPerro()
        {
            nombrePerro.Clear();
            sexoPerro.Clear();
            razaPerro.Clear();
            tamanioPerro.Clear();
            pesoPerro.Clear();
            edadPerro.Clear();
            apdrinadoPerro.IsChecked = false;
            imgPerro.Visibility = Visibility.Hidden;
        }

        private void habilitarTextBoxPerro()
        {
            nombrePerro.IsEnabled = true;
            sexoPerro.IsEnabled = true;
            razaPerro.IsEnabled = true;
            tamanioPerro.IsEnabled = true;
            pesoPerro.IsEnabled = true;
            edadPerro.IsEnabled = true;
            fechaPerro.IsEnabled=true;

            ListPadrinos.Visibility = Visibility.Visible;
            padrinoPerro.Visibility = Visibility.Hidden;
        }

        private void deshabilitarTextBoxPerro()
        {
            nombrePerro.IsEnabled = false;
            sexoPerro.IsEnabled = false;
            razaPerro.IsEnabled = false;
            tamanioPerro.IsEnabled = false;
            pesoPerro.IsEnabled = false;
            edadPerro.IsEnabled = false;
            apdrinadoPerro.IsEnabled = false;
            fechaPerro.IsEnabled = false;

            ListPadrinos.Visibility = Visibility.Hidden;
            padrinoPerro.Visibility = Visibility.Visible;
        }

        private void btnEliminarPerro_Click(object sender, RoutedEventArgs e)
        {
            if (ListPerros.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado un perro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Dominio.Perro buscarPerro = (Dominio.Perro)ListPerros.SelectedItem;
                Object dataContext = ListPerros.DataContext;

                listadoPerros.Remove(buscarPerro);
                listadoPerrosNoApadrinados.Remove(buscarPerro);
                listadoPerrosApadrinados.Remove(buscarPerro);

                ListPerros.DataContext = null;
                ListPerros.DataContext = dataContext;

                MessageBox.Show("Se ha eliminado correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnModificarPerro_Click(object sender, RoutedEventArgs e)
        {
            if (ListPerros.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un perro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                habilitarTextBoxPerro();
                Dominio.Padrino infoPadrino = null;
                Dominio.Perro infoPerro;
                List<Dominio.Perro> listaPerros = (List<Dominio.Perro>)ListPerros.DataContext;
                int indice = ListPerros.SelectedIndex;
                if (indice >= 0)
                {
                    infoPerro = listaPerros[indice];
                    for (int i = 0; i < listadoPadrinos.Count; i++)
                    {
                        if (listadoPadrinos[i].nombre == infoPerro.nombrePadrino)
                        {
                            infoPadrino = listadoPadrinos[i];
                            break;
                        }
                        else
                            infoPadrino = null;
                    }
                }
               ListPadrinos.SelectedItem = infoPadrino;
               btnAceptarCambiarPerro.Visibility = Visibility.Visible;

            }
        }

        private void btnAceptarAnadirPerro_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            Boolean comprobar1 = int.TryParse(pesoPerro.Text, out i);
            Boolean comprobar2 = int.TryParse(edadPerro.Text, out i);
            if (comprobar1 == false || comprobar2 == false)
            {
                pesoPerro.Background = Brushes.Red;
                edadPerro.Background = Brushes.Red;
                MessageBox.Show("El dato de peso o de edad no es número", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                Boolean apadrinado = false;
                Dominio.Padrino auxPadrino;
                String nombrePadrino = "-";
                if (ListPadrinos.SelectedIndex > -1)
                {
                    apadrinado = true;
                    apdrinadoPerro.IsChecked = true;
                    auxPadrino = ListPadrinos.SelectedItem as Dominio.Padrino;
                    nombrePadrino = auxPadrino.nombre;
                    
                }

                Dominio.Perro nuevoPerro = new Dominio.Perro(nombrePerro.Text, sexoPerro.Text, razaPerro.Text, tamanioPerro.Text, Convert.ToInt32(pesoPerro.Text), Convert.ToInt32(edadPerro.Text), Convert.ToDateTime(fechaPerro.SelectedDate), apadrinado, nombrePadrino, null, false, false, false, false, false, "", false, false, false, false, "");
                listadoPerros.Add(nuevoPerro);
                if (nuevoPerro.apadrinado)
                    listadoPerrosApadrinados.Add(nuevoPerro);
                else
                    listadoPerrosNoApadrinados.Add(nuevoPerro);

                btnAceptarAnadirPerro.Visibility = Visibility.Hidden;
                deshabilitarTextBoxPerro();
                ListPerros.DataContext = null;
                ListPerros.DataContext = listadoPerros;

                imgPerro.Visibility = Visibility.Visible;
                pesoPerro.Background = Brushes.White;
                edadPerro.Background = Brushes.White;

                MessageBox.Show("Se ha añadido correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAceptarCambiarPerro_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            Boolean comprobar1 = int.TryParse(pesoPerro.Text, out i);
            Boolean comprobar2 = int.TryParse(edadPerro.Text, out i);
            if (comprobar1 == false || comprobar2 == false)
            {
                pesoPerro.Background = Brushes.Red;
                edadPerro.Background = Brushes.Red;
                MessageBox.Show("El dato de peso o de edad no es número", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ListPadrinos.SelectedIndex > -1)
                    apdrinadoPerro.IsChecked = true;

                Boolean apadrinado = false;
                Dominio.Padrino auxPadrino;
                String nombrePadrino = "-";
                if (ListPadrinos.SelectedIndex > -1)
                {
                    apadrinado = true;
                    auxPadrino = ListPadrinos.SelectedItem as Dominio.Padrino;
                    nombrePadrino = auxPadrino.nombre;
                   
                }

                List<Dominio.Perro> listaPerros = (List<Dominio.Perro>)ListPerros.DataContext;
                int index = ListPerros.SelectedIndex;
                listaPerros[index].nombrePadrino = nombrePadrino;

                listadoPerros = listaPerros;
                
                cargarListaApadrinados(listadoPerros);

                ListPerros.DataContext = null;
                ListPerros.DataContext = listadoPerros;

                btnAceptarCambiarPerro.Visibility = Visibility.Hidden;
                deshabilitarTextBoxPerro();

                pesoPerro.Background = Brushes.White;
                edadPerro.Background = Brushes.White;

                MessageBox.Show("Se ha modificado correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //PADRINO
        private void cargarListaPadrinos()
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("texto/padrinos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                DateTime dt = new DateTime(2000, 10, 10);
                Dominio.Padrino nuevoPadrino = new Dominio.Padrino("", "", "", "", "", "", 0, "", "", dt, null);

                nuevoPadrino.nombre = node.Attributes["nombre"].Value;
                nuevoPadrino.apellidos = node.Attributes["apellidos"].Value;
                nuevoPadrino.dni = node.Attributes["dni"].Value;
                nuevoPadrino.domicilio = node.Attributes["domicilio"].Value;
                nuevoPadrino.telefono = node.Attributes["telefono"].Value;
                nuevoPadrino.email = node.Attributes["email"].Value;
                nuevoPadrino.aportacionMensual = Convert.ToInt32(node.Attributes["aportacionMensual"].Value);
                nuevoPadrino.formaPago = node.Attributes["formaPago"].Value;
                nuevoPadrino.numeroCuenta = node.Attributes["numeroCuenta"].Value;
                nuevoPadrino.fechaComienzoApadri = Convert.ToDateTime(node.Attributes["fechaComienzoApadri"].Value);
                nuevoPadrino.foto = new Uri(node.Attributes["foto"].Value, UriKind.Absolute);

                listadoPadrinos.Add(nuevoPadrino);

            }
        }

        private void masInfoPadrino_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Dominio.Padrino infoPadrino = null;
            Dominio.Perro infoPerro;
            List<Dominio.Perro> listaPerros = (List<Dominio.Perro>)ListPerros.DataContext;
            int indice = ListPerros.SelectedIndex;
            if (indice >= 0)
            {
                infoPerro = listaPerros[indice];
                for (int i = 0; i < listadoPadrinos.Count; i++)
                {
                    if (listadoPadrinos[i].nombre == infoPerro.nombrePadrino)
                    {
                        infoPadrino = listadoPadrinos[i];
                        break;
                    }
                    else
                        infoPadrino = null;
                        
                }
                if(infoPadrino != null)
                {
                    Presentacion.datosPadrino ventana = new Presentacion.datosPadrino(infoPadrino);
                    ventana.Show();
                } else
                    MessageBox.Show("No existe datos del padrino", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


            } else
                MessageBox.Show("No ha seleccionado un perro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }


        //VOLUNTARIOS
        public void cargarListaVoluntarios()
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("texto/voluntarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                Dominio.Voluntario nuevoVoluntario = new Dominio.Voluntario("", "", "", "", "", "", "", "", "", null);

                nuevoVoluntario.nombre = node.Attributes["nombre"].Value;
                nuevoVoluntario.apellidos = node.Attributes["apellidos"].Value;
                nuevoVoluntario.email = node.Attributes["email"].Value;
                nuevoVoluntario.dni = node.Attributes["dni"].Value;
                nuevoVoluntario.domicilio = node.Attributes["domicilio"].Value;
                nuevoVoluntario.telefono = node.Attributes["telefono"].Value;
                nuevoVoluntario.horarioDisponibilidad = node.Attributes["horarioDisponibilidad"].Value;
                nuevoVoluntario.zonaDisponibilidad = node.Attributes["zonaDisponibilidad"].Value;
                nuevoVoluntario.conocimientosVeterinarios = node.Attributes["conocimientosVeterinarios"].Value;
                nuevoVoluntario.foto = new Uri(node.Attributes["foto"].Value, UriKind.Absolute);

                listadoVoluntarios.Add(nuevoVoluntario);
            }
        }

        private void btnAnadirVol_Click(object sender, RoutedEventArgs e)
        {
            ListVoluntarios.SelectedIndex = -1;
            limpiarTextBoxVoluntario();
            habilitarTextBoxvoluntario();
            btnAceptarAnadirVoluntario.Visibility = Visibility.Visible;
        }

        private void limpiarTextBoxVoluntario()
        {
            nombreVoluntario.Clear();
            apellidosVoluntario.Clear();
            dniVoluntario.Clear();
            domicilioVoluntario.Clear();
            emailVoluntario.Clear();
            telefonoVoluntario.Clear();
            horaVoluntario.Clear();
            zonaVoluntario.Clear();
            conocimientosVoluntario.Clear();
            imgVoluntario.Visibility = Visibility.Hidden;
        }

        private void habilitarTextBoxvoluntario()
        {
            nombreVoluntario.IsEnabled = true;
            apellidosVoluntario.IsEnabled = true;
            dniVoluntario.IsEnabled = true;
            domicilioVoluntario.IsEnabled = true;
            emailVoluntario.IsEnabled = true;
            telefonoVoluntario.IsEnabled = true;
            horaVoluntario.IsEnabled = true;
            zonaVoluntario.IsEnabled = true;
            conocimientosVoluntario.IsEnabled = true;

        }

        private void deshabilitarTextBoxVoluntario()
        {
            nombreVoluntario.IsEnabled = false;
            apellidosVoluntario.IsEnabled = false;
            dniVoluntario.IsEnabled = false;
            domicilioVoluntario.IsEnabled = false;
            emailVoluntario.IsEnabled = false;
            telefonoVoluntario.IsEnabled = false;
            horaVoluntario.IsEnabled = false;
            zonaVoluntario.IsEnabled = false;
            conocimientosVoluntario.IsEnabled = false;
        }

        private void btnEliminarVol_Click(object sender, RoutedEventArgs e)
        {
            if (ListVoluntarios.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado un voluntario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                listadoVoluntarios.RemoveAt(ListVoluntarios.SelectedIndex);
                ListVoluntarios.DataContext = null;
                ListVoluntarios.DataContext = listadoVoluntarios;

                MessageBox.Show("Se ha eliminado correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnModificarVol_Click(object sender, RoutedEventArgs e)
        {
            if (ListVoluntarios.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un voluntario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                habilitarTextBoxvoluntario();
                btnAceptarCambiarVoluntario.Visibility = Visibility.Visible;
            }
        }

        private void btnAceptarAnadirVoluntario_Click(object sender, RoutedEventArgs e)
        {
            Dominio.Voluntario nuevoVoluntario = new Dominio.Voluntario(nombreVoluntario.Text, apellidosVoluntario.Text, emailVoluntario.Text, dniVoluntario.Text, domicilioVoluntario.Text, telefonoVoluntario.Text, horaVoluntario.Text, zonaVoluntario.Text, conocimientosVoluntario.Text, null);
            listadoVoluntarios.Add(nuevoVoluntario);

            btnAceptarAnadirVoluntario.Visibility = Visibility.Hidden;
            deshabilitarTextBoxVoluntario();

            ListVoluntarios.DataContext = null;
            ListVoluntarios.DataContext = listadoVoluntarios;
            imgVoluntario.Visibility = Visibility.Visible;

            MessageBox.Show("Se ha añadido correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAceptarCambiarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            btnAceptarCambiarAvisos.Visibility = Visibility.Hidden;
            deshabilitarTextBoxVoluntario();
            
            MessageBox.Show("Se ha modificado correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }

        //SOCIOS
        public void cargarListaSocios()
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("texto/socios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                Dominio.Socio nuevoSocio = new Dominio.Socio("", "", "", "", "", "", "", "", "", "", null);

                nuevoSocio.nombre = node.Attributes["nombre"].Value;
                nuevoSocio.apellidos = node.Attributes["apellidos"].Value;
                nuevoSocio.email = node.Attributes["email"].Value;
                nuevoSocio.dni = node.Attributes["dni"].Value;
                nuevoSocio.domicilio = node.Attributes["domicilio"].Value;
                nuevoSocio.telefono = node.Attributes["telefono"].Value;
                nuevoSocio.nombreBanco = node.Attributes["nombreBanco"].Value;
                nuevoSocio.numeroCuenta = node.Attributes["numeroCuenta"].Value;
                nuevoSocio.cuantiaAyuda = node.Attributes["cuantiaAyuda"].Value;
                nuevoSocio.formaPagado = node.Attributes["formaPagado"].Value;
                nuevoSocio.foto = new Uri(node.Attributes["fotoSocio"].Value, UriKind.Absolute);

                listadoSocios.Add(nuevoSocio);
            }
        }

        private void btnAnadirSocio_Click(object sender, RoutedEventArgs e)
        {
            ListSocios.SelectedIndex = -1;
            limpiarTextBoxSocio();
            habilitarTextBoxSocio();
            btnAceptarAnadirSocios.Visibility = Visibility.Visible;
        }

        private void limpiarTextBoxSocio()
        {
            nombreSocio.Clear();
            apellidosSocio.Clear();
            dniSocio.Clear();
            domicilioSocio.Clear();
            emailSocio.Clear();
            telefonoSocio.Clear();
            bancoSocio.Clear();
            cuentaSocio.Clear();
            cuantiaSocio.Clear();
            pagoSocio.Clear();
        }
        
        private void habilitarTextBoxSocio()
        {
            nombreSocio.IsEnabled = true;
            apellidosSocio.IsEnabled = true;
            dniSocio.IsEnabled = true;
            domicilioSocio.IsEnabled = true;
            emailSocio.IsEnabled = true;
            telefonoSocio.IsEnabled = true;
            bancoSocio.IsEnabled = true;
            cuentaSocio.IsEnabled = true;
            cuantiaSocio.IsEnabled = true;
            pagoSocio.IsEnabled = true;
        }
        
        private void deshabilitarTextBoxSocio()
        {
            nombreSocio.IsEnabled = false;
            apellidosSocio.IsEnabled = false;
            dniSocio.IsEnabled = false;
            domicilioSocio.IsEnabled = false;
            emailSocio.IsEnabled = false;
            telefonoSocio.IsEnabled = false;
            bancoSocio.IsEnabled = false;
            cuentaSocio.IsEnabled = false;
            cuantiaSocio.IsEnabled = false;
            pagoSocio.IsEnabled = false;
        }

        private void btnEliminarSocio_Click(object sender, RoutedEventArgs e)
        {
            if (ListSocios.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado un socio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                listadoSocios.RemoveAt(ListSocios.SelectedIndex);
                ListSocios.DataContext = null;
                ListSocios.DataContext = listadoSocios;

                MessageBox.Show("Se ha eliminado correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void btnModificarSocio_Click(object sender, RoutedEventArgs e)
        {
            if (ListSocios.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un socio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                habilitarTextBoxSocio();
                btnAceptarCambiarSocios.Visibility = Visibility.Visible;
            }
        }

        private void btnAceptarAnadirSocios_Click(object sender, RoutedEventArgs e)
        {
            Dominio.Socio nuevoSocio = new Dominio.Socio(nombreSocio.Text, apellidosSocio.Text, emailSocio.Text, dniSocio.Text, domicilioSocio.Text, telefonoSocio.Text, bancoSocio.Text, cuentaSocio.Text, cuantiaSocio.Text,pagoSocio.Text, null);
            listadoSocios.Add(nuevoSocio);

            btnAceptarAnadirSocios.Visibility = Visibility.Hidden;
            deshabilitarTextBoxSocio();

            ListSocios.DataContext = null;
            ListSocios.DataContext = listadoSocios;
            imgSocio.Visibility = Visibility.Visible;

            MessageBox.Show("Se ha añadido correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAceptarCambiarSocios_Click(object sender, RoutedEventArgs e)
        {
            btnAceptarCambiarSocios.Visibility = Visibility.Hidden;
            deshabilitarTextBoxSocio();

            MessageBox.Show("Se ha modificado correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        //AVISOS
        public void cargarListaAvisos()
        {
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("texto/avisos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                DateTime dt = new DateTime(2000, 10, 10);
                Dominio.Aviso nuevoAviso = new Dominio.Aviso("", "", "", 0, "", "", null, dt, "", "");

                nuevoAviso.nombre = node.Attributes["nombre"].Value;
                nuevoAviso.sexo = node.Attributes["sexo"].Value;
                nuevoAviso.raza = node.Attributes["raza"].Value;
                nuevoAviso.tamano = Convert.ToInt32(node.Attributes["tamano"].Value);
                nuevoAviso.descripcionPerro = node.Attributes["descripcionPerro"].Value;
                nuevoAviso.datosAdicionales = node.Attributes["datosAdicionales"].Value;
                nuevoAviso.foto = new Uri(node.Attributes["foto"].Value, UriKind.Absolute);
                nuevoAviso.fechaPerdida = Convert.ToDateTime(node.Attributes["fechaPerdida"].Value);
                nuevoAviso.zonaPerdida = node.Attributes["zonaPerdida"].Value;
                nuevoAviso.datosContacto = node.Attributes["datosContacto"].Value;

                listadoAvisos.Add(nuevoAviso);

            }
        }

        private void btnAnadirAviso_Click(object sender, RoutedEventArgs e)
        {
            ListAvisos.SelectedIndex = -1;
            limpiarTextBoxAviso();
            habilitarTextBoxAviso();
            btnAceptarAnadirAvisos.Visibility = Visibility.Visible;

        }

        private void limpiarTextBoxAviso()
        {
            nombreAviso.Clear();
            sexoAviso.Clear();
            razaAviso.Clear();
            tamanioAviso.Clear();
            datosAviso.Clear();
            zonaAviso.Clear();
            contactoAviso.Clear();
            imgAviso.Visibility = Visibility.Hidden;
        }

        private void habilitarTextBoxAviso()
        {
            nombreAviso.IsEnabled = true;
            sexoAviso.IsEnabled = true;
            razaAviso.IsEnabled = true;
            tamanioAviso.IsEnabled = true;
            datosAviso.IsEnabled = true;
            descripcionAviso.IsEnabled = true;
            fechaAviso.IsEnabled = true;
            zonaAviso.IsEnabled = true;
            contactoAviso.IsEnabled = true;
        }

        private void deshabilitarTextBoxAviso()
        {
            nombreAviso.IsEnabled = false;
            sexoAviso.IsEnabled = false;
            razaAviso.IsEnabled = false;
            tamanioAviso.IsEnabled = false;
            datosAviso.IsEnabled = false;
            descripcionAviso.IsEnabled = false;
            fechaAviso.IsEnabled = false;
            zonaAviso.IsEnabled = false;
            contactoAviso.IsEnabled = false;
        }

        private void btnEliminarAviso_Click(object sender, RoutedEventArgs e)
        {
            if (ListAvisos.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado un aviso", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                listadoAvisos.RemoveAt(ListAvisos.SelectedIndex);
                ListAvisos.DataContext = null;
                ListAvisos.DataContext = listadoAvisos;

                MessageBox.Show("Se ha eliminado correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            }        
        }

        private void btnModificarAviso_Click(object sender, RoutedEventArgs e)
        {
            if(ListAvisos.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un aviso", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                habilitarTextBoxAviso();
                btnAceptarCambiarAvisos.Visibility = Visibility.Visible;
            }
            
        }

        private void btnAceptarAnadirAvisos_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            Boolean comprobar = int.TryParse(tamanioAviso.Text, out i);
            if (comprobar == false)
            {
                tamanioAviso.Background = Brushes.Red;
                MessageBox.Show("El dato de tamaño no es número", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Dominio.Aviso nuevoAviso = new Dominio.Aviso(nombreAviso.Text, sexoAviso.Text, razaAviso.Text, Convert.ToInt32(tamanioAviso.Text), descripcionAviso.Text, datosAviso.Text, null, Convert.ToDateTime(fechaAviso.SelectedDate), zonaAviso.Text, contactoAviso.Text);
                listadoAvisos.Add(nuevoAviso);

                btnAceptarAnadirAvisos.Visibility = Visibility.Hidden;
                deshabilitarTextBoxAviso();

                ListAvisos.DataContext = null;
                ListAvisos.DataContext = listadoAvisos;
                imgAviso.Visibility = Visibility.Visible;
                tamanioAviso.Background = Brushes.White;

                MessageBox.Show("Se ha añadido correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAceptarCambiarAvisos_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            Boolean comprobar = int.TryParse(tamanioAviso.Text, out i);
            if (comprobar == false)
            {
                tamanioAviso.Background = Brushes.Red;
                MessageBox.Show("El dato de tamaño no es número", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {     
                btnAceptarAnadirAvisos.Visibility = Visibility.Hidden;
                deshabilitarTextBoxAviso();

                tamanioAviso.Background = Brushes.White;

                MessageBox.Show("Se ha modificado correctamente", "Operación realizada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //VENTANA AYUDA
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            Presentacion.Ayuda ventana = new Presentacion.Ayuda();
            ventana.Show();
        }
    }

}

