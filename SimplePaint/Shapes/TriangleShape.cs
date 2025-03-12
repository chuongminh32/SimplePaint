using SimplePaint.Shapes;
using System.Net;

namespace SimplePaint.Shapes
{
    public class TriangleShape : ShapeBase
    {
        public override void Draw(Graphics g)
        {
            Point[] points = {
                new Point((StartPoint.X + EndPoint.X) / 2, StartPoint.Y),
                new Point(StartPoint.X, EndPoint.Y),
                new Point(EndPoint.X, EndPoint.Y)
            };

            g.DrawPolygon(ShapePen, points);
            g.FillPolygon(ShapeBrush, points);
            DrawSelection(g);

        }
    }
}
