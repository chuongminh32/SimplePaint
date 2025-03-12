using System;
using System.Drawing;

namespace SimplePaint.Shapes
{
    public class AWM : ShapeBase
    {
        public override void Draw(Graphics g)
        {
            int width = EndPoint.X - StartPoint.X;
            int height = EndPoint.Y - StartPoint.Y;

            // 1. Vẽ nòng súng dài (Barrel)
            Rectangle barrel = new Rectangle(
                StartPoint.X + width / 3,
                StartPoint.Y + height / 4,
                width * 2 / 3,
                height / 20);
            g.FillRectangle(Brushes.Gray, barrel);
            g.DrawRectangle(ShapePen, barrel);

            // 2. Vẽ ống ngắm (Scope)
            Rectangle scopeBase = new Rectangle(
                StartPoint.X + width / 2,
                StartPoint.Y + height / 6,
                width / 4,
                height / 15);
            g.FillRectangle(Brushes.Black, scopeBase);
            g.DrawRectangle(ShapePen, scopeBase);

            Rectangle scopeMain = new Rectangle(
                StartPoint.X + width / 2 - width / 10,
                StartPoint.Y + height / 7,
                width / 3,
                height / 10);
            g.FillEllipse(Brushes.Black, scopeMain);
            g.DrawEllipse(ShapePen, scopeMain);

            // 3. Vẽ thân súng (Receiver)
            Rectangle receiver = new Rectangle(
                StartPoint.X + width / 6,
                StartPoint.Y + height / 3,
                width / 2,
                height / 10);
            g.FillRectangle(Brushes.DarkGreen, receiver);
            g.DrawRectangle(ShapePen, receiver);

            // 4. Vẽ tay cầm (Grip)
            Rectangle grip = new Rectangle(
                StartPoint.X + width / 3,
                StartPoint.Y + height / 2,
                width / 10,
                height / 6);
            g.FillRectangle(Brushes.DarkGreen, grip);
            g.DrawRectangle(ShapePen, grip);

            // 5. Vẽ báng súng (Stock)
            Point[] stockPoints = new Point[]
            {
                new Point(StartPoint.X, StartPoint.Y + height / 3),
                new Point(StartPoint.X + width / 6, StartPoint.Y + height / 3),
                new Point(StartPoint.X + width / 6, StartPoint.Y + height * 2 / 3),
                new Point(StartPoint.X, StartPoint.Y + height * 3 / 4)
            };
            g.FillPolygon(Brushes.DarkGreen, stockPoints);
            g.DrawPolygon(ShapePen, stockPoints);

            // 6. Vẽ băng đạn (Magazine)
            Point[] magazinePoints = new Point[]
            {
                new Point(StartPoint.X + width / 2, StartPoint.Y + height / 2),
                new Point(StartPoint.X + width * 5 / 9, StartPoint.Y + height / 2),
                new Point(StartPoint.X + width * 5 / 9, StartPoint.Y + height * 2 / 3),
                new Point(StartPoint.X + width / 2, StartPoint.Y + height * 3 / 5)
            };
            g.FillPolygon(Brushes.Black, magazinePoints);
            g.DrawPolygon(ShapePen, magazinePoints);

            DrawSelection(g);
        }
    }
}
