using System;

namespace LabIPO.Dominio
{
    internal class Aviso
    {
        public string nombre { set; get; }
        public string sexo { set; get; }
        public string raza { set; get; }
        public int tamano { set; get; }
        public string descripcionPerro { set; get; }
        public string datosAdicionales { set; get; }
        public Uri foto { set; get; }
        public DateTime fechaPerdida { set; get; }
        public string zonaPerdida { set; get; }
        public string datosContacto { set; get; }

        public Aviso(string nombre, string sexo, string raza, int tamano, string descripcionPerro, string datosAdicionales, Uri foto, DateTime fechaPerdida, string zonaPerdida, string datosContacto)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.raza = raza;
            this.tamano = tamano;
            this.descripcionPerro = descripcionPerro;
            this.datosAdicionales = datosAdicionales;
            this.foto = foto;
            this.fechaPerdida = fechaPerdida;
            this.zonaPerdida = zonaPerdida;
            this.datosContacto = datosContacto;
        }
    }
}
