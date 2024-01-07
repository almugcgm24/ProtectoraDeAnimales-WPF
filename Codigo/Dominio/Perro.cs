using System;

namespace LabIPO.Dominio
{
    public class Perro
    {
        public string nombre { set; get; }
        public string sexo { set; get; }
        public string raza { set; get; }
        public String tamanio { set; get; }
        public int peso { set; get; }
        public int edad { set; get; }
        public DateTime fechaEntradaProt { set; get; }
        public Boolean apadrinado { set; get; }
        public string nombrePadrino { set; get; }
        public Uri foto { set; get; }

        public Boolean cachorro { set; get; }
        public Boolean ppp { set; get; }
        public Boolean vacunado { set; get; }
        public Boolean esterilizado { set; get; }
        public Boolean leishmaniosis { set; get; }
        public string descripcionPerro { set; get; }
        public Boolean sociableConPerros { set; get; }
        public Boolean sociableConNinios { set; get; }
        public Boolean sociableConGatos { set; get; }
        public Boolean sociableCualquierAnimal { set; get; }
        public String estadoPerro { set; get; }

        public Perro(string nombre, string sexo, string raza, string tamanio, int peso, int edad, DateTime fechaEntradaProt, bool apadrinado, string nombrePadrino, Uri foto, bool cachorro, bool ppp, bool vacunado, bool esterilizado, bool leishmaniosis, string descripcionPerro, bool sociableConPerros, bool sociableConNinios, bool sociableConGatos, bool sociableCualquierAnimal, String estadoPerro)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.raza = raza;
            this.tamanio = tamanio;
            this.peso = peso;
            this.edad = edad;
            this.fechaEntradaProt = fechaEntradaProt;
            this.apadrinado = apadrinado;
            this.nombrePadrino = nombrePadrino;
            this.foto = foto;

            this.cachorro = cachorro;
            this.ppp = ppp;
            this.vacunado = vacunado;
            this.esterilizado = esterilizado;
            this.leishmaniosis = leishmaniosis;
            this.descripcionPerro = descripcionPerro;
            this.sociableConPerros = sociableConPerros;
            this.sociableConNinios = sociableConNinios;
            this.sociableConGatos = sociableConGatos;
            this.sociableCualquierAnimal = sociableCualquierAnimal;
            this.estadoPerro = estadoPerro;
        }
    }
}

