using System;
using System.Drawing;

namespace SimplePaint.Shapes
{
    public class VietNamFlag : ShapeBase
    {
        public override void Draw(Graphics g)
        {
            int width = EndPoint.X - StartPoint.X;
            int height = EndPoint.Y - StartPoint.Y;

            // 1. Vẽ nền cờ màu đỏ
            Rectangle flag = new Rectangle(StartPoint.X, StartPoint.Y, width, height);
            g.FillRectangle(Brushes.Red, flag);
            g.DrawRectangle(ShapePen, flag);

            // 2. Vẽ ngôi sao vàng ở giữa
            PointF[] starPoints = CalculateStarPoints(
                StartPoint.X + width / 2,
                StartPoint.Y + height / 2,
                width / 5,
                width / 10
            );

            g.FillPolygon(Brushes.Yellow, starPoints);
            g.DrawPolygon(ShapePen, starPoints);

            DrawSelection(g);
        }

        private PointF[] CalculateStarPoints(float centerX, float centerY, float outerRadius, float innerRadius)
        {
            PointF[] points = new PointF[10];
            double angle = -Math.PI / 2; // Bắt đầu từ đỉnh trên cùng

            for (int i = 0; i < 10; i++)
            {
                float radius = (i % 2 == 0) ? outerRadius : innerRadius;
                points[i] = new PointF(
                    centerX + (float)(Math.Cos(angle) * radius),
                    centerY + (float)(Math.Sin(angle) * radius)
                );
                angle += Math.PI / 5;
            }

            return points;
        }
    }
}
