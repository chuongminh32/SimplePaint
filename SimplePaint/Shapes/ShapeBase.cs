using System.Drawing.Drawing2D;

namespace SimplePaint.Shapes
{
    public abstract class ShapeBase
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Pen ShapePen { get; set; }

        public Brush ShapeBrush { get; set; }
        public bool isSelected { get; set; }

        private const int HandleSize = 10; // Kích thước của handle (8 ô xung quanh)

        public ShapeBase()
        {
            ShapePen = new Pen(Color.Black, 1);
            ShapeBrush = new SolidBrush(Color.Transparent); // Khởi tạo mặc định
            isSelected = false;
        }

        public virtual void SetBrush(Color color)
        {
            ShapeBrush = new SolidBrush(color);
        }

        public virtual void SetPen(Color penColor, int penWidth, DashStyle dashStyle)
        {
            if (ShapePen == null)
            {
                ShapePen = new Pen(Color.Black, 1); // Khởi tạo mặc định
            }

            ShapePen.Color = penColor;
            ShapePen.Width = penWidth;
            ShapePen.DashStyle = dashStyle;
        }


        // Ham tra ve khung hcn bao quanh hinh 
        public virtual Rectangle GetBounds()
        {
          
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            int width = Math.Abs(EndPoint.X - StartPoint.X);
            int height = Math.Abs(EndPoint.Y - StartPoint.Y);

            return new Rectangle(x, y, width, height);
        }

    

        // Kiểm tra một điểm có nằm trong khung hcn ?
        public virtual bool Contains(Point p)
        {
            Rectangle bounds = GetBounds();
            return bounds.Contains(p);
        }

        // Di chuyển hình
        public virtual void Move(int dx, int dy)
        {
            StartPoint = new Point(StartPoint.X + dx, StartPoint.Y + dy);
            EndPoint = new Point(EndPoint.X + dx, EndPoint.Y + dy);
        }

        // Lấy danh sách các điểm điều khiển (resize handles)
        public List<Rectangle> GetResizeHandles()
        {
            List<Rectangle> handles = new List<Rectangle>();
            Rectangle bounds = GetBounds(); // Lấy khung hình
            int x = bounds.X;
            int y = bounds.Y;
            int w = bounds.Width;
            int h = bounds.Height;
            int hs = HandleSize / 2; //  dich o vuong theo dung goc o giua 


            // 4 góc
            handles.Add(new Rectangle(x - hs, y - hs, HandleSize, HandleSize)); // Trên trái
            handles.Add(new Rectangle(x + w - hs, y - hs, HandleSize, HandleSize)); // Trên phải
            handles.Add(new Rectangle(x - hs, y + h - hs, HandleSize, HandleSize)); // Dưới trái
            handles.Add(new Rectangle(x + w - hs, y + h - hs, HandleSize, HandleSize)); // Dưới phải

            // 4 cạnh
            handles.Add(new Rectangle(x + w / 2 - hs, y - hs, HandleSize, HandleSize)); // Trên giữa
            handles.Add(new Rectangle(x + w / 2 - hs, y + h - hs, HandleSize, HandleSize)); // Dưới giữa
            handles.Add(new Rectangle(x - hs, y + h / 2 - hs, HandleSize, HandleSize)); // Trái giữa
            handles.Add(new Rectangle(x + w - hs, y + h / 2 - hs, HandleSize, HandleSize)); // Phải giữa

            return handles;
            
        }

        // resize shape 
        public virtual void Resize(ShapeBase s,int handleIndex, int dx, int dy) 
        {
            switch(handleIndex)
            {
                case 0: // Trên trái
                    s.StartPoint = new Point(s.StartPoint.X + dx, s.StartPoint.Y + dy);
                    break;
                case 1: // Trên phai
                    s.StartPoint = new Point(s.StartPoint.X, s.StartPoint.Y + dy);
                    s.EndPoint = new Point(s.EndPoint.X + dx, s.EndPoint.Y);
                    break;
                case 2: // Duoi trái
                    s.StartPoint = new Point(s.StartPoint.X + dx, s.StartPoint.Y);
                    s.EndPoint = new Point(s.EndPoint.X, s.EndPoint.Y + dy);
                    break;
                case 3: // Duoi phai
                    s.EndPoint = new Point(s.EndPoint.X + dx, s.EndPoint.Y + dy);
                    break;
                case 4: // Trên giua
                    s.StartPoint = new Point(s.StartPoint.X, s.StartPoint.Y + dy);
                    break;
                case 5: // Duoi giua
                    s.EndPoint = new Point(s.EndPoint.X, s.EndPoint.Y + dy);
                    break;
                case 6: // Trái giua
                    s.StartPoint = new Point(s.StartPoint.X + dx, s.StartPoint.Y);
                    break;
                case 7: // Phai giua
                    s.EndPoint = new Point(s.EndPoint.X + dx, s.EndPoint.Y);
                    break;

            }
        }

        // Xác định vị trí click có thuộc vào handle nào không
        public int ContainMiniRect(Point p)
        {
            List<Rectangle> handles = GetResizeHandles();
            for (int i = 0; i < handles.Count; i++)
            {
                if (handles[i].Contains(p))
                {
                    return i; // Trả về index của handle
                }
            }
            return -1; // Không click vào handle nào
        }

        // Vẽ khung và điểm điều khiển khi hình được chọn
        public virtual void DrawSelection(Graphics g)
        {
            if (isSelected == false) // Nếu không được chọn -> Không vẽ khung
                return;

            // ve khung hcn
            Rectangle b = GetBounds();
            Pen p = new Pen(Color.Blue, 1);
            p.DashStyle = DashStyle.Dash;
            g.DrawRectangle(p, b);

            // Vẽ điểm điều khiển (resize handles)
            List<Rectangle> miniRect = GetResizeHandles();
            for (int i=0;i< miniRect.Count; i++)
            {
                g.FillRectangle(Brushes.Blue, miniRect[i]);
                g.DrawRectangle(Pens.Black, miniRect[i]);

            }
        }

        // Phương thức vẽ hình (phải được override bởi lớp con)
        public abstract void Draw(Graphics g);
    }
}
