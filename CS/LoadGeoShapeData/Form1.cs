using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraMap;

namespace LoadGeoShapeData {
    public partial class Form1 : Form {
        List<MapData> data = new List<MapData>();
        ShapefileDataAdapter adapter = new ShapefileDataAdapter();
        
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Uri baseUri = new Uri(System.Reflection.Assembly.GetEntryAssembly().Location);
            #region #AutomaticallyLoaded
            data.Add(new MapData() {
                Name = "Automatically loaded coordinate system",
                FileUri = new Uri(baseUri, "../../Shapefiles/Albers/switzerland.shp")
            });
            #endregion #AutomaticallyLoaded
            #region #LoadPrjFile
            data.Add(new MapData() {
                Name = "LoadPrjFile( ) calling loaded coordinate system",
                FileUri = new Uri(baseUri, "../../Shapefiles/Lambert/Belize.shp"),
                CoordinateSystem = ShapefileDataAdapter.LoadPrjFile(new Uri(
                    baseUri,
                    "../../Shapefiles/Lambert/Projection.prj"))
            });
            #endregion #LoadPrjFile
            #region #ManuallyCreated
            data.Add(new MapData() {
                Name = "Manually created coordinate system",
                FileUri = new Uri(baseUri, "../../Shapefiles/TransverseMercator/israel.shp"),
                CoordinateSystem = new CartesianSourceCoordinateSystem() {
                    CoordinateConverter = new UTMCartesianToGeoConverter() {
                        Hemisphere = Hemisphere.Northern, 
                        UtmZone = 36
                    }
                }
            });
            #endregion #ManuallyCreated

            cbCoordinateSystem.DataSource = data;
            cbCoordinateSystem.DisplayMember = "Name";
            
            VectorItemsLayer layer = new VectorItemsLayer() { Data = adapter };
            layer.ItemStyle.Fill = Color.FromArgb(60, 255, 128, 0);
            layer.DataLoaded += layer_DataLoaded;

            mapControl1.Layers.Add(layer);
        }

        void layer_DataLoaded(object sender, DataLoadedEventArgs e) {
            mapControl1.ZoomToFitLayerItems(0.4);
        }

        private void cbCoordinateSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            MapData mapData = cbCoordinateSystem.SelectedValue as MapData;
            if (mapData == null) return;

            adapter.FileUri = mapData.FileUri;
            if (mapData.CoordinateSystem != null)
                adapter.SourceCoordinateSystem = mapData.CoordinateSystem;
        }
    }

    public class MapData {
        public String Name { get; set; }
        public Uri FileUri { get; set; }
        public SourceCoordinateSystem CoordinateSystem { get; set; }
    }
}