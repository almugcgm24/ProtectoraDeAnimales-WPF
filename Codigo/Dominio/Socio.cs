using System;

namespace LabIPO.Dominio
{
    internal class Socio
    {
        public string nombre { set; get; }
        public string apellidos { set; get; }
        public string email { set; get; }
        public string dni { set; get; }
        public string domicilio { set; get; }
        public string telefono { set; get; }
        public string nombreBanco { set; get; }
        public string numeroCuenta { set; get; }
        public string cuantiaAyuda { set; get; }
        public string formaPagado { set; get; }
        public Uri foto { set; get; }

        public Socio(string nombre, string apellidos, string email, string dni, string domicilio, string telefono, string nombreBanco, string numeroCuenta, string cuantiaAyuda, string formaPagado, Uri foto)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.dni = dni;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.nombreBanco = nombreBanco;
            this.numeroCuenta = numeroCuenta;
            this.cuantiaAyuda = cuantiaAyuda;
            this.formaPagado = formaPagado;
            this.foto = foto;
        }
    }
}
