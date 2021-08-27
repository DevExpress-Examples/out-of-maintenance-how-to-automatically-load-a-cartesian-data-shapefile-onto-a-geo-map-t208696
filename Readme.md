<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128575986/14.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T208696)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/LoadGeoShapeData/Form1.cs) (VB: [Form1.vb](./VB/LoadGeoShapeData/Form1.vb))**
<!-- default file list end -->
# How to: automatically load a Cartesian data shapefile onto a geo map


This example demonstrates how to automatically load a Cartesian data shapefile onto a Geo map.


<h3>Description</h3>

<p>To automatically load Cartesian map data from a shapefile onto a Geo map do the following.</p>
<p>- If the shapefile data contains a <em>*.PRJ</em> file with the same name and path as a <em>*.SHP</em> file, specify the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapShapefileDataAdapter_FileUritopic">ShapefileDataAdapter.FileUri</a> property. The data will be loaded automatically.</p>
<p>- Otherwise, to load coordinate system information if the file names or paths&nbsp;are different. Use the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapShapefileDataAdapter_LoadPrjFiletopic">ShapefileDataAdapter.LoadPrjFile</a> method to initialize the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapSourceCoordinateSystemtopic">SourceCoordinateSystem</a> class descendant object, which should be assigned to the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapCoordinateSystemDataAdapterBase_SourceCoordinateSystemtopic">CoordinateSystemDataAdapterBase.SourceCoordinateSystem</a> property of the data adapter.</p>

<br/>


