using SimplePaint.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaint.Shapes
{
    public class LineShape : ShapeBase
    {
        public override void Draw(Graphics g)
        {
            g.DrawLine(ShapePen, StartPoint, EndPoint);
            DrawSelection(g);

        }
    }
}
