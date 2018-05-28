using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace Map_51
{
    public class Zoom2SelectedLayer : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public Zoom2SelectedLayer()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            ILayer lyr = ArcMap.Document.SelectedLayer;

            IGeoDataset gl = lyr as IGeoDataset;

            if (gl != null)
                ArcMap.Document.ActiveView.Extent = gl.Extent;
            else
                MessageBox.Show("Please select featurelyaer");

            ArcMap.Document.ActiveView.Refresh();

            ArcMap.Application.CurrentTool = null;
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
