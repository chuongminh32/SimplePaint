using SimplePaint.Shapes;
using System.Net;
using System.Drawing;
using System;

namespace SimplePaint.Shapes
{
    public class CurveShape : ShapeBase 
    {
           public override void Draw(Graphics g)
        {
            Point[] points = new Point[3]; // Tạo mảng chứa 3 điểm
            points[0] = new Point(StartPoint.X, EndPoint.Y); // Điểm 1
            points[1] = new Point(EndPoint.X, EndPoint.Y); // Điểm 2
            points[2] = new Point(StartPoint.X + (EndPoint.X - StartPoint.X) / 2, StartPoint.Y); // Điểm 3
            g.DrawCurve(ShapePen, points); // Vẽ đường cong
            g.FillPolygon(ShapeBrush, points);
            DrawSelection(g);
         }
    }
}
