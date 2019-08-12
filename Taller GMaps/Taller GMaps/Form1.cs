using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Diagnostics;
using System.Security;
using System.IO;


namespace Taller_GMaps
{

    public partial class Form1 : Form
    {

        GMarkerGoogle marker;
        GMapOverlay marketOverlay;
        int totalDatos;
        public int PM10{get; set;}
        public int PM25 { get; set; }
        public int SO2 { get; set; }
        public int NO2 { get; set; }
        public int O3 { get; set; }
        public int CO { get; set; }



        public Form1()
        {
            InitializeComponent();
            totalDatos = 0;
            PM10 = 0;
            PM25 = 0;
            SO2 = 0;
            O3 = 0;
            CO = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;


           try
            {
                
                var filePath = "Data.txt";
                using (FileStream fs = File.Open(filePath, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);

                    totalDatos = 608;
                    for(int i =0; i<totalDatos; i++)
                    {
                        String data = sr.ReadLine();

                        String[] datos = new string[20];

                        datos = data.Split(',');

                        Registro regis = new Registro(datos[0], datos[1], datos[2], datos[3], datos[4], datos[6], datos[7], datos[8],
                            datos[9], datos[10],  datos[11], datos[12], datos[13], datos[14], datos[15], datos[16], datos[17],datos[18],datos[19]);


                        regis.organizarLatitud();
                        regis.organizarLongitud();

                        //MessageBox.Show(regis.latAlterna + ""   );

                        gMapControl1.Position = new PointLatLng(regis.latAlterna, regis.longAlterna);

                        marketOverlay = new GMapOverlay("Marcador");
                        marker = new GMarkerGoogle(new PointLatLng(regis.latAlterna, regis.longAlterna), GMarkerGoogleType.red);
                       marketOverlay.Markers.Add(marker);

                        marker.ToolTipMode = MarkerTooltipMode.Always;
                      //  marker.ToolTipText = String.Format("Dpto : {0} \n Municipio : {1}", regis.departamento, regis.municipio);

                        gMapControl1.Overlays.Add(marketOverlay);

                        if (regis.variableGas.Equals("PM10"))
                        {
                            PM10++;
                        }else if (regis.variableGas.Equals("PM2.5"))
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
                    }
                    fs.Close();
                }
                
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
                
        }

        private void BtnMirar_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void Atras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal princi = new Principal();
            princi.Show();

        }
    }
}
