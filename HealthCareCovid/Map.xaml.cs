using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GMap.NET.WindowsForms.Markers;

namespace HealthCareCovid
{
    /// <summary>
    /// Logique d'interaction pour Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public GMapControl gmapControl;

        public Map(double latitude, double longitude)
        {
            InitializeComponent();
            gmapControl = new GMapControl();
            myMap.Child = gmapControl;
            gmapControl.MapProvider = GMapProviders.GoogleMap;
            GMarkerGoogle marqueur = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red);
            GMapOverlay coucheOverlay = new GMapOverlay("marqueurOverlay");
            coucheOverlay.Markers.Add(marqueur);
            gmapControl.Overlays.Add(coucheOverlay);
            gmapControl.Position = new PointLatLng(latitude, longitude);
            gmapControl.Refresh();

            gmapControl.MinZoom = 2;
            gmapControl.MaxZoom = 20;
            gmapControl.Zoom = 16;
        }
    }
}
