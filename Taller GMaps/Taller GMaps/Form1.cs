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


namespace Taller_GMaps
{

    public partial class Form1 : Form
    {



        GMarkerGoogle marker;
        GMapOverlay marketOverlay;

        double latInicial = 3.451792;
        double longInicial = -76.532494;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {




            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(latInicial, longInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            marketOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(latInicial, longInicial),GMarkerGoogleType.red);
            marketOverlay.Markers.Add(marker);

            marker.ToolTipMode= MarkerTooltipMode.Always;
            marker.ToolTipText = String.Format("Ubicacion : \n Latitud : {0} \n Longitud : {1}",latInicial,longInicial);

            gMapControl1.Overlays.Add(marketOverlay);
                
        }

        private void BtnMirar_Click(object sender, EventArgs e)
        {

        }
    }
}
