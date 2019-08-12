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
using System.Security;
using System.IO;

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
            int PM10 = 0;
            int PM25 = 0;
            int CO = 0;
            int O3 = 0;
            int NO2 = 0;
            int SO2 = 0;

            try
            {

                var filePath = "Data.txt";
                using (FileStream fs = File.Open(filePath, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);

                    int totalDatos = 608;

                    for (int i = 0; i < totalDatos; i++)
                    {
                        String data = sr.ReadLine();

                        String[] datos = new string[20];

                        datos = data.Split(',');

                        Registro regis = new Registro(datos[0], datos[1], datos[2], datos[3], datos[4], datos[6], datos[7], datos[8],
                            datos[9], datos[10], datos[11], datos[12], datos[13], datos[14], datos[15], datos[16], datos[17], datos[18], datos[19]);


                        if (regis.variableGas.Equals("PM10"))
                        {
                            PM10++;
                        }
                        else if (regis.variableGas.Equals("PM2.5"))
                        {
                            PM25++;
                        }
                        else if (regis.variableGas.Equals("CO2"))
                        {
                            CO++;
                        }
                        else if (regis.variableGas.Equals("NO2"))
                        {
                            NO2++;
                        }
                        else if (regis.variableGas.Equals("SO2"))
                        {
                            SO2++;
                        }
                        else
                        {
                            O3++;
                        }

                        fs.Close();

                    }
                }
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }

            int[] puntos = {PM10,PM25,SO2,NO2,O3,CO };


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
