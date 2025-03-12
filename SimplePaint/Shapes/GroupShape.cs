using System.Drawing.Drawing2D;

namespace SimplePaint.Shapes
{
    public class GroupShape : ShapeBase
    {
        public List<ShapeBase> Shapes { get; private set; }

        public GroupShape(List<ShapeBase> s)
        {
            Shapes = s;
        }

        public override void SetPen(Color penColor, int penWidth, DashStyle dashStyle)
        {
            for(int i=0;i<Shapes.Count;i++)
            {
                Shapes[i].SetPen(penColor, penWidth, dashStyle);
            }
        }

        public override void SetBrush(Color color)
        {
            for (int i = 0; i < Shapes.Count; i++)
            {
                Shapes[i].SetBrush(color);
            }
        }

        //public void AddShape(ShapeBase shape)
        //{
        //    Shapes.Add(shape);
        //    UpdateBounds();
        //}

        //public void RemoveShape(ShapeBase shape)
        //{
        //    Shapes.Remove(shape);
        //    UpdateBounds();
        //}

        // cap nhat lai toa do khung hcn bao quanh group hinh 
        private void UpdateBounds()
        {

            if(Shapes.Count == 0)
            {
                StartPoint = EndPoint = Point.Empty;
                return;
            }

            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;

            for (int i=0;i<Shapes.Count;i++)
            {
                // khung hcn tung hinh con trong group
                Rectangle b = Shapes[i].GetBounds();

                minX = Math.Min(b.X, minX);
                minY = Math.Min(b.Y, minY);
                maxX = Math.Max(b.X + b.Width, maxX);
                maxY = Math.Max(b.Y + b.Height, maxY);

            }

            StartPoint = new Point(minX, minY);
            EndPoint = new Point(maxX, maxY);

        }

        public override Rectangle GetBounds()
        {
            return new Rectangle(StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
        }

        // kiem tra mot diem co nam trong group (bang cach kiem tra no nam trong 1 trong cac hinh con trong group)
        public override bool Contains(Point p)
        {
            // Kiểm tra nếu danh sách Shapes rỗng thì không thể chứa điểm nào
            if (Shapes.Count == 0)
            {
                return false;
            }

            // Kiểm tra từng hình trong nhóm xem có chứa điểm `p` không
            for (int i=0; i<Shapes.Count;i++)
            {
                ShapeBase shape = Shapes[i];
                if (shape.Contains(p)) // Nếu bất kỳ hình nào chứa `p`, trả về true ngay lập tức
                {
                    return true;
                }
            }

            // Nếu không có hình nào chứa `p`, trả về false
            return false;
        }


        // di chuyen tung hinh con ben trong group
        public override void Move(int dx, int dy)
        {
            for (int i=0;i<Shapes.Count;i++)
            {
                ShapeBase shape = Shapes[i];
                shape.Move(dx, dy);
            }
            UpdateBounds(); // cap nhat khung hcn
        }

        // resize tung hinh con ben trong group
        public override void Resize(ShapeBase s, int handleIndex, int dx, int dy)
        {
            for (int i=0;i<Shapes.Count;i++)
            {
                ShapeBase shape = Shapes[i];
                shape.Resize(shape, handleIndex, dx, dy);
            }
            UpdateBounds(); // cap nhat khung hcn 
        }

        public override void Draw(Graphics g)
        {
            for (int i=0;i<Shapes.Count;i++)
            {
                ShapeBase shape = Shapes[i];
                shape.Draw(g);
            }

            // neu group dc chon -> ve khung va diem resize
            if (isSelected)
            {
                DrawSelection(g);
            }
        }

        // ve khung hcn bao quanh group
        public override void DrawSelection(Graphics g)
        {
            Rectangle bounds = GetBounds(); // khung hcn group 
            Pen p = new Pen(Color.Blue, 2);
            p.DashStyle = DashStyle.Dash;
            g.DrawRectangle(p, bounds); // ve khung hcn
            DrawResizeHandles(g); // ve resize handles
        }

        // ve 8 diem resize group 
        public void DrawResizeHandles(Graphics g)
        {
            // lay ds 8 diem resize ke thua tu shapebase
            List<Rectangle> handles = GetResizeHandles();
            for (int i=0;i<handles.Count;i++)
            {
                g.FillRectangle(Brushes.Blue, handles[i]);
                g.DrawRectangle(Pens.Red, handles[i]);
            }
        }

    }
}
