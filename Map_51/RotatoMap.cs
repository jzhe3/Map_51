using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Map_51
{
    public class RotatoMap : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        public RotatoMap()
        {
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }

        protected override void OnMouseDown(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs e)
        {
            ArcMap.Document.ActiveView.ScreenDisplay.TrackRotate(); ;
        }
    }

}
