using System;

namespace LabIPO.Dominio
{
    public class Persona
    {
        public string usuario { set; get; }
        public string apellidos { set; get; }
        public string contrasenia { set; get; }
        public string dni { set; get; }
        public string telefono { set; get; }
        public string ultimoAcceso { set; get; }
        public Uri foto { set; get; }

        public Persona(string usuario, string apellidos, string contrasenia, string dni, string telefono, string ultimoAcceso, Uri foto)
        {
            this.usuario = usuario;
            this.apellidos = apellidos;
            this.contrasenia = contrasenia;
            this.dni = dni;
            this.telefono = telefono;
            this.ultimoAcceso = ultimoAcceso;
            this.foto = foto;
        }
    }
}
