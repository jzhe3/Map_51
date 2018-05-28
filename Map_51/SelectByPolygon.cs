using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;

namespace Map_51
{
    public class SelectByPolygon : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        public SelectByPolygon()
        {
        }

        protected override void OnUpdate()
        {

        }

        protected override void OnMouseDown(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs e)
        {
            IScreenDisplay screenDisplay = ArcMap.Document.ActiveView.ScreenDisplay;

            //创建选取多边形
            IRubberBand pRubberPolygon = new RubberPolygonClass();
            IPolygon pPolygon = pRubberPolygon.TrackNew(screenDisplay, null) as IPolygon;

            //构建选取环境；选取对象颜色为红色；选取方法为累加
            SelectionEnvironment se = new SelectionEnvironmentClass();
            se.DefaultColor = getRGB(255, 0, 0);
            se.CombinationMethod = esriSelectionResultEnum.esriSelectionResultAdd;

            //选取要素
            IMap map = ArcMap.Document.FocusMap;
            map.SelectByShape(pPolygon, se, false);

            //刷新屏幕
            ArcMap.Document.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }

        public IColor getRGB(int yourRed, int yourGreen, int yourBlue)
        {
            IRgbColor pRGB = new RgbColorClass();
            pRGB.Red = yourRed;
            pRGB.Green = yourGreen;
            pRGB.Blue = yourBlue;
            pRGB.UseWindowsDithering = true;
            return pRGB;
        }
    }

}
