using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Taller_GMaps
{
    public partial class Gráfico_Barras : Form
    {
        public Gráfico_Barras()
        {
            InitializeComponent();
        }

        private void Chart1_Click(object sender, EventArgs e)
        {
            // los vectores con los datos
            string[] series = {"PM10","PM2.5","SO2","NO2","O3","CO"};

            
 
            int[] puntos = {,10,70 };


            // cambiar la combinanción de colores.
            chart1.Palette = ChartColorPalette.Fire;

            for(int i=0; i<series.Length; i++)
            {
                //titulos
                Series serie = chart1.Series.Add(series[i]);

                // cantidades
                serie.Label = puntos[i].ToString();

                serie.Points.Add(puntos[i]);

            }


        }
    }
}
