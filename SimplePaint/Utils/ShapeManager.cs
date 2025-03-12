using SimplePaint.Shapes;
using System.Drawing.Drawing2D;

namespace SimplePaint.Utils
{
    public class ShapeManager
    {
        public List<ShapeBase> Shapes { get; private set; } 
        public List<ShapeBase> SelectedShapes { get; private set; } 

        public ShapeManager()
        {
            SelectedShapes = new List<ShapeBase>();
            Shapes = new List<ShapeBase>();
        }


        // ham nhom hinh 
        public void GroupShapes()
        {

            GroupShape group = new GroupShape(new List<ShapeBase>(SelectedShapes));

            for (int i=0;i< SelectedShapes.Count;i++)
            {
                ShapeBase shape = SelectedShapes[i];
                Shapes.Remove(shape);
                shape.isSelected = false;
            }

            Shapes.Add(group);
            SelectedShapes.Clear();
            SelectedShapes.Add(group);
        }

        // ham bo nhom hinh
        public void UnGroupShapes()
        {
            List<ShapeBase> l = new List<ShapeBase>(); // danh sach tam de luu lai cac phan tu trong group vao selected va shape list 

            for (int i=Shapes.Count - 1; i>=0;i--)
            {
                GroupShape gr = Shapes[i] as GroupShape; // ep kieu GroupShape (neu khac null -> do la 1 group hinh)
                if(gr != null)
                {
                   for(int j = 0; j < gr.Shapes.Count;j++)
                    {
                        l.Add(gr.Shapes[j]);
                    }
                    // xoa group hinh trong shape list
                    Shapes.Remove(gr);
                }
            }
            // xoa group hinh trong danh sach selected
            SelectedShapes.Clear();
            // them lai vao selected va shapes
            for (int i=0;i<l.Count; i++)
            {
                Shapes.Add(l[i]);
                SelectedShapes.Add(l[i]);
            }

        }

        // ham ve lai tat ca cac hinh trong danh sach
        public void DrawAllShapes(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias; // Kích hoạt khử răng cưa
            foreach (var shape in Shapes)
            {
                shape.Draw(g); // ve tung hinh trong danh sach 
            }
        }


        // ham xoa tat ca cac hinh 
        public void ClearShapes()
        {
            Shapes.Clear();
        }
    }
}
