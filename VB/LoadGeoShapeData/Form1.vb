Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraMap

Namespace LoadGeoShapeData
    Partial Public Class Form1
        Inherits Form

        Private data As New List(Of MapData)()
        Private adapter As New ShapefileDataAdapter()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Dim baseUri As New Uri(System.Reflection.Assembly.GetEntryAssembly().Location)
'            #Region "#AutomaticallyLoaded"
            data.Add(New MapData() With {.Name = "Automatically loaded coordinate system", .FileUri = New Uri(baseUri, "../../Shapefiles/Albers/switzerland.shp")})
'            #End Region ' #AutomaticallyLoaded
'            #Region "#LoadPrjFile"
            data.Add(New MapData() With {.Name = "LoadPrjFile( ) calling loaded coordinate system", .FileUri = New Uri(baseUri, "../../Shapefiles/Lambert/Belize.shp"), .CoordinateSystem = ShapefileDataAdapter.LoadPrjFile(New Uri(baseUri, "../../Shapefiles/Lambert/Projection.prj"))})
'            #End Region ' #LoadPrjFile
'            #Region "#ManuallyCreated"
            data.Add(New MapData() With { _
                .Name = "Manually created coordinate system", .FileUri = New Uri(baseUri, "../../Shapefiles/TransverseMercator/israel.shp"), .CoordinateSystem = New CartesianSourceCoordinateSystem() With { _
                    .CoordinateConverter = New UTMCartesianToGeoConverter() With {.Hemisphere = Hemisphere.Northern, .UtmZone = 36} _
                } _
            })
'            #End Region ' #ManuallyCreated

            cbCoordinateSystem.DataSource = data
            cbCoordinateSystem.DisplayMember = "Name"

            Dim layer As New VectorItemsLayer() With {.Data = adapter}
            layer.ItemStyle.Fill = Color.FromArgb(60, 255, 128, 0)
            AddHandler layer.DataLoaded, AddressOf layer_DataLoaded

            mapControl1.Layers.Add(layer)
        End Sub

        Private Sub layer_DataLoaded(ByVal sender As Object, ByVal e As DataLoadedEventArgs)
            mapControl1.ZoomToFitLayerItems(0.4)
        End Sub

        Private Sub cbCoordinateSystem_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbCoordinateSystem.SelectedIndexChanged
            Dim mapData As MapData = TryCast(cbCoordinateSystem.SelectedValue, MapData)
            If mapData Is Nothing Then
                Return
            End If

            adapter.FileUri = mapData.FileUri
            If mapData.CoordinateSystem IsNot Nothing Then
                adapter.SourceCoordinateSystem = mapData.CoordinateSystem
            End If
        End Sub
    End Class

    Public Class MapData
        Public Property Name() As String
        Public Property FileUri() As Uri
        Public Property CoordinateSystem() As SourceCoordinateSystem
    End Class
End Namespace