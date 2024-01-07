using System;

namespace LabIPO.Dominio
{
    internal class Voluntario
    {
        public string nombre { set; get; }
        public string apellidos { set; get; }
        public string email { set; get; }
        public string dni { set; get; }
        public string domicilio { set; get; }
        public string telefono { set; get; }
        public string horarioDisponibilidad { set; get; }
        public string zonaDisponibilidad { set; get; }
        public string conocimientosVeterinarios { set; get; }
        public Uri foto { set; get; }

        public Voluntario(string nombre, string apellidos, string email, string dni, string domicilio, string telefono, string horarioDisponibilidad, string zonaDisponibilidad, string conocimientosVeterinarios, Uri foto)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.dni = dni;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.horarioDisponibilidad = horarioDisponibilidad;
            this.zonaDisponibilidad = zonaDisponibilidad;
            this.conocimientosVeterinarios = conocimientosVeterinarios;
            this.foto = foto;
        }
    }
}
