using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_GMaps
{
    class Registro
    {

        public String autoridadAmbiental { get; set; }
        public String nombreEstacion { get; set; }
        public String latitud { get; set; }
        public String longitud { get; set; }
        public String ubicación { get; set; } 
        public String departamento { get; set; }
        public String municipio { get; set; }
        public String tipoEstacion { get; set; }
        public String variableGas { get; set; }
        public String unidades { get; set; }
        public String tiempoPromedio { get; set; }
        public String numExcedencias { get; set; }
        public String representatividad { get; set; }
        public String porcentajeExcedencias { get; set; }
        public String mediana { get; set; }
        public String percentil98 { get; set; }
        public String maximo { get; set; }
        public String minimo { get; set; }
        public String numDias { get; set; }

        public Double latAlterna { get; set; }

        public Double longAlterna { get; set; }

        public Registro(string autoridadAmbiental, string nombreEstacion, String latitud, String longitud, string ubicación, string departamento, string municipio, string tipoEstacion, string variableGas, string unidades, string tiempoPromedio, string numExcedencias, string representatividad, string porcentajeExcedencias, string mediana, string percentil98, string maximo, string minimo, string numDias)
        {
            this.autoridadAmbiental = autoridadAmbiental;
            this.nombreEstacion = nombreEstacion;
            this.latitud = latitud;
            this.longitud = longitud;
            this.ubicación = latitud + ", " + longitud;
            this.departamento = departamento;
            this.municipio = municipio;
            this.tipoEstacion = tipoEstacion;
            this.variableGas = variableGas;
            this.unidades = unidades;
            this.tiempoPromedio = tiempoPromedio;
            this.numExcedencias = numExcedencias;
            this.representatividad = representatividad;
            this.porcentajeExcedencias = porcentajeExcedencias;
            this.mediana = mediana;
            this.percentil98 = percentil98;
            this.maximo = maximo;
            this.minimo = minimo;
            this.numDias = numDias;
            latAlterna = 0;

        }

       public void organizarLatitud()
        {
            int posicion = latitud.IndexOf(".");

            String segunda = latitud.Substring(posicion);

            int cantidad = segunda.Length;

            double miles = Math.Pow(10,cantidad-1);

             latAlterna = double.Parse(latitud) / (miles);

        }

        public void organizarLongitud()
        {
            int posicion = longitud.IndexOf(".");

            String segunda = longitud.Substring(posicion);

            int cantidad = segunda.Length;

            double miles = Math.Pow(10, cantidad-1);

            longAlterna = double.Parse(longitud) / (miles);
        }
    }
}
