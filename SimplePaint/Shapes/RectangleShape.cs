using SimplePaint.Shapes;
using System.Drawing.Drawing2D;
using System.Net;

namespace SimplePaint.Shapes
{
    public class RectangleShape : ShapeBase
    {
        public override void Draw(Graphics g)
        {
            int width = EndPoint.X - StartPoint.X;
            int height = EndPoint.Y - StartPoint.Y;

            g.DrawRectangle(ShapePen, StartPoint.X, StartPoint.Y, width, height);
            g.FillRectangle(ShapeBrush, StartPoint.X, StartPoint.Y, width, height);
            DrawSelection(g);
        }

    }
}
