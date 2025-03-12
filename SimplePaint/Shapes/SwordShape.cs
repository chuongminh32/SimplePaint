using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaint.Shapes
{
    public class SwordShape : ShapeBase
    {
        public override void Draw(Graphics g)
        {
            // Vẽ lưỡi kiếm (phần dài)
            Rectangle blade = new Rectangle(
                StartPoint.X + (EndPoint.X - StartPoint.X) / 2 - 5,
                StartPoint.Y,
                10,
                (EndPoint.Y - StartPoint.Y) * 2 / 3);
            g.FillRectangle(Brushes.Silver, blade);
            g.DrawRectangle(ShapePen, blade);

            // Vẽ chuôi kiếm (phần tay cầm)
            Rectangle hilt = new Rectangle(
                StartPoint.X + (EndPoint.X - StartPoint.X) / 2 - 3,
                StartPoint.Y + (EndPoint.Y - StartPoint.Y) * 2 / 3,
                6,
                (EndPoint.Y - StartPoint.Y) / 3);
            g.FillRectangle(Brushes.Brown, hilt);
            g.DrawRectangle(ShapePen, hilt);

            // Vẽ bảo kiếm (phần bảo vệ tay)
            Rectangle guard = new Rectangle(
                StartPoint.X + (EndPoint.X - StartPoint.X) / 2 - 15,
                StartPoint.Y + (EndPoint.Y - StartPoint.Y) * 2 / 3 - 5,
                30,
                10);
            g.FillRectangle(Brushes.Goldenrod, guard);
            g.DrawRectangle(ShapePen, guard);

            DrawSelection(g);
        }
    }
}