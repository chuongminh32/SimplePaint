using SimplePaint.Shapes;
using System.Net;

namespace SimplePaint.Shapes
{
    public class EllipseShape : ShapeBase
    {
        public override void Draw(Graphics g)
        {
            int width = EndPoint.X - StartPoint.X;
            int height = EndPoint.Y - StartPoint.Y;

            g.DrawEllipse(ShapePen, StartPoint.X, StartPoint.Y, width, height);
            g.FillEllipse(ShapeBrush, StartPoint.X, StartPoint.Y, width, height);
            DrawSelection(g);
        }
    }
}
