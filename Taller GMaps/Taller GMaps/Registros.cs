using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_GMaps
{
    public partial class Registros : Form
    {
        public Registros()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal princi = new Principal();
            princi.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            String atoridad = this.AutoridadA.Text;
            String nombreEstacion = this.nombreEsta.Text;
            String Longitud = this.longitud.Text;
            String latitud = this.latitud.Text;
            String ubicacion = this.ubicacion.Text;
            String departamento = this.depto.Text;
            String municipio = this.municipio.Text;
            String tipoEstacion = this.tipoEsta.Text;
            String variable = this.variable.Text;
            String tiempoProm = this.tiempoProm.Text;
            String unidades = this.Unidades.Text;
            String representatividadTem = this.RepresentTemp.Text;
            String porcentajeExce = this.porcenExce.Text;
            String mediana = this.Mediana.Text;
            String percentil = this.Percentil.Text;
            String maximo = this.Max.Text;
            String minimo = this.min.Text;
            String diasExcedencia = this.DiasExceden.Text;

            var filePath = "Data.txt";
            StreamWriter escribir = new StreamWriter(filePath);
            StreamReader leer = new StreamReader(filePath);
            String linea = null;

            if(atoridad.Equals("")&& nombreEstacion.Equals("")&& Longitud.Equals("")&& latitud.Equals("")&&
                ubicacion.Equals("")&& departamento.Equals("")&& municipio.Equals("")&& tipoEstacion.Equals("")&&
                variable.Equals("")&& tiempoProm.Equals("")&& unidades.Equals("")&& representatividadTem.Equals("")&&
                porcentajeExce.Equals("")&& mediana.Equals("")&& percentil.Equals("")&& maximo.Equals("") && minimo.Equals("")&&
                diasExcedencia.Equals("")) {

                MessageBox.Show("Debe llenar todos los datos para guardar");

            }else{
                try
                {
                    linea = leer.ReadLine();
                    while (linea!=null)
                    {
                        linea = leer.ReadLine();
                    }
                    
                    escribir.WriteLine(atoridad + "," + nombreEstacion + "," + Longitud + "," + latitud + "," + ubicacion + "," +
                                       departamento + "," + municipio + "," + tipoEstacion + "," + variable + "," + tiempoProm + "," +
                                       unidades + "," + representatividadTem + "," + porcentajeExce + "," + mediana + "," + percentil + "," +
                                       maximo + "," + minimo + "," + diasExcedencia);

                    MessageBox.Show("Se ha guardado con exito");
                }
                catch
                {
                    MessageBox.Show("ERROR, POR FAVOR INTENTE DE NUEVO");
                }
                escribir.Close();
            }
            
        }
    }
}
