using System;

namespace LabIPO.Dominio
{
    public class Padrino
    {
        public string nombre { set; get; }
        public string apellidos { set; get; }
        public string email { set; get; }
        public string dni { set; get; }
        public string domicilio { set; get; }
        public string telefono { set; get; }
        public int aportacionMensual { set; get; }
        public string formaPago { set; get; }
        public string numeroCuenta { set; get; }
        public DateTime fechaComienzoApadri { set; get; }
        public Uri foto { set; get; }

        public Padrino(string nombre, string apellidos, string email, string dni, string domicilio, string telefono, int aportacionMensual, string formaPago, string numeroCuenta, DateTime fechaComienzoApadri, Uri foto)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.dni = dni;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.aportacionMensual = aportacionMensual;
            this.formaPago = formaPago;
            this.numeroCuenta = numeroCuenta;
            this.fechaComienzoApadri = fechaComienzoApadri;
            this.foto = foto;
        }
    }
}
