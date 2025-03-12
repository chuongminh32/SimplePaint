using System.Drawing;

namespace SimplePaint.Shapes
{
    public class PolygonShape : ShapeBase
    {
        public override void Draw(Graphics g)
        {
            Point[] points = new Point[5]; // Tạo mảng chứa 5 điểm
            int width = EndPoint.X - StartPoint.X;   // Chiều rộng
            int height = EndPoint.Y - StartPoint.Y;  // Chiều cao
            int centerX = StartPoint.X + width / 2;  // Trung điểm theo trục X
            int topY = StartPoint.Y;  // Điểm cao nhất của ngũ giác

            // Xác định 5 điểm của ngũ giác
            points[0] = new Point(centerX, topY); // Đỉnh trên cùng
            points[1] = new Point(StartPoint.X, StartPoint.Y + height / 3); // Góc trái trên
            points[2] = new Point(StartPoint.X + width / 4, EndPoint.Y); // Góc trái dưới
            points[3] = new Point(StartPoint.X + (3 * width) / 4, EndPoint.Y); // Góc phải dưới
            points[4] = new Point(EndPoint.X, StartPoint.Y + height / 3); // Góc phải trên
            g.DrawPolygon(ShapePen, points); // Vẽ đa giác
            g.FillPolygon(ShapeBrush, points); // Tô màu đa giác
            DrawSelection(g);

        }
    }
}