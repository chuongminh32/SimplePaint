using SimplePaint.Shapes;
using SimplePaint.Utils;
using System.Drawing.Drawing2D;

namespace SimplePaint
{
    public partial class MainForm : Form
    {
        // dich chuyen hình 
        private ShapeBase selectedShape = null;
        private bool isDragging = false;
        private Point lastMousePosition;
        private int selectedHandleIndex = -1;
        private bool isDrawing = false;

        // chon nhieu hinh 
        private bool isCtrlPressed = false;


        private ShapeBase currentShape;
        private ShapeManager shapeManager;

        //pen
        private Color selectedColor = Color.Black;
        private DashStyle selectedDashStyle = DashStyle.Solid;
        private int selectedPenWidth = 2;

        // shape flag 
        private bool bLine = false;
        private bool bEclippse = false;
        private bool bRect = false;
        private bool bPolygon = false;
        private bool bCurve = false;
        private bool bTri = false;
        private bool AWM = false;
        private bool bSword = false;
        private bool bVietNamFlag = false;

        public MainForm()
        {
            InitializeComponent();
            numPenWidth.Minimum = 1;
            shapeManager = new ShapeManager();
            //Đăng ký sự kiện KeyDown
            this.KeyPreview = true; // Đảm bảo form nhận sự kiện phím trước khi điều khiển con
            this.KeyDown += MainForm_KeyDown;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteShape();
            }
            else if (e.KeyCode == Keys.A && e.Control)
            {
                for (int i = 0; i < shapeManager.Shapes.Count; i++)
                {
                    ShapeBase s = shapeManager.Shapes[i];
                    s.isSelected = true;
                    shapeManager.SelectedShapes.Add(s);
                }
                pnlMain.Refresh();
            }
        }

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            isCtrlPressed = Control.ModifierKeys == Keys.Control;
            bool found = false;


            // Kiểm tra nếu click chuột phải 
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < shapeManager.Shapes.Count; i++)
                {
                    ShapeBase s = shapeManager.Shapes[i];
                    if (s.Contains(e.Location))
                    {
                        contextMenuStrip1.Show(Cursor.Position);
                        return;
                    }
                }
            }

            // Kiểm tra xem có click vào 1 trong 8 ô resize của hình đơn lẻ không'
            for (int i = 0; i < shapeManager.Shapes.Count; i++)
            {
                ShapeBase shape = shapeManager.Shapes[i];
                int idx = shape.ContainMiniRect(e.Location); // ham tra ve index khi click vao 1 trong 8 o vuong
                if (idx != -1)
                {
                    selectedHandleIndex = idx;
                    selectedShape = shape;
                    lastMousePosition = e.Location;
                    isDragging = true;
                    found = true;
                    break;
                }

            }

            // Kiểm tra nếu click vào một hình , ctrl để chọn nhiều hình
            for (int i=0;i<shapeManager.Shapes.Count;i++)
            {
                ShapeBase shape = shapeManager.Shapes[i];
                if (shape.Contains(e.Location))
                {
                    found = true;
                    if (isCtrlPressed)
                    {
                        shape.isSelected = !shape.isSelected;
                        if (shape.isSelected)
                            shapeManager.SelectedShapes.Add(shape);
                        else
                            shapeManager.SelectedShapes.Remove(shape);
                    }
                    else
                    {
                        // Bỏ chọn tất cả nếu không giữ Ctrl
                        for (int j=0;j<shapeManager.Shapes.Count;j++)
                        {
                            shapeManager.Shapes[j].isSelected = false;
                        }
                        shapeManager.SelectedShapes.Clear();
                        shape.isSelected = true;
                        shapeManager.SelectedShapes.Add(shape);
                    }

                    selectedShape = shape;
                    lastMousePosition = e.Location;
                    isDragging = true;
                    pnlMain.Refresh();
                    break;
                }
            }

            // Nếu không chọn được hình nào, bỏ hết lựa chọn
            if (found == false && isCtrlPressed == false)
            {
                // Bỏ chọn tất cả nếu không giữ Ctrl
                for (int j = 0; j < shapeManager.Shapes.Count; j++)
                {
                    shapeManager.Shapes[j].isSelected = false;
                }
                shapeManager.SelectedShapes.Clear();
                pnlMain.Refresh();
            }


            // Nếu không có hình nào được chọn, tiến hành vẽ hình mới
            if (found == false)
            {
                isDrawing = true;
                currentShape = null;

                if (bLine)
                    currentShape = new LineShape();
                else if (bRect)
                    currentShape = new RectangleShape();
                else if (bEclippse)
                    currentShape = new EllipseShape();
                else if (bTri)
                    currentShape = new TriangleShape();
                else if (bPolygon)
                    currentShape = new PolygonShape();
                else if (bCurve)
                    currentShape = new CurveShape();
                else if (AWM)
                    currentShape = new AWM();
                else if (bSword)
                    currentShape = new SwordShape();
                else if (bVietNamFlag)
                    currentShape = new VietNamFlag();
                if (currentShape != null)
                {
                    currentShape.StartPoint = e.Location;
                    currentShape.EndPoint = e.Location;
                    currentShape.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
                    shapeManager.Shapes.Add(currentShape);
                    pnlMain.Refresh();
                }
            }
        }


        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            int dx = e.X - lastMousePosition.X;
            int dy = e.Y - lastMousePosition.Y;
            // Nếu đang kéo một hình riêng lẻ
            if (isDragging && selectedShape != null)
            {
                // resize hinh
                if (selectedHandleIndex != -1)
                {
                    selectedShape.Resize(selectedShape, selectedHandleIndex, dx, dy);
                }
                // di chuyen hinh
                else
                {
                    selectedShape.Move(dx, dy);
                }
                lastMousePosition = e.Location;
                pnlMain.Invalidate();
            }
            // cap nhat cac duong ve lien tuc neu dang ve
            else if (isDrawing && currentShape != null)
            {
                currentShape.EndPoint = e.Location;
                pnlMain.Invalidate();
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            shapeManager.DrawAllShapes(e.Graphics);
        }


        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shapeManager.SelectedShapes.Count < 2)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 2 hình để nhóm !");
            }
            else
            {
                shapeManager.GroupShapes();
                pnlMain.Refresh();
            }
        }


        private void unGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeManager.UnGroupShapes();
            pnlMain.Refresh();
        }
        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            selectedHandleIndex = -1;
            isDragging = false;
            isDrawing = false;
            isCtrlPressed = false;

            if (currentShape != null)
            {
                currentShape.EndPoint = e.Location;
                pnlMain.Refresh();
            }
            currentShape = null; // Reset để vẽ hình mới
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            shapeManager.ClearShapes();
            pnlMain.Refresh();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (shapeManager.SelectedShapes.Count > 0)
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = colorDialog.Color;
                    btnChangeColor.BackColor = selectedColor;

                    for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
                    {
                        ShapeBase s = shapeManager.SelectedShapes[i];
                        s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hình để thay đổi màu bút!");
            }

            pnlMain.Refresh();
            colorDialog.Dispose();
        }


        private void cmbDashStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xác định kiểu đường viền từ ComboBox
            switch (cmbDashStyle.SelectedIndex)
            {
                case 0:
                    selectedDashStyle = DashStyle.Solid;
                    break;
                case 1:
                    selectedDashStyle = DashStyle.Dash;
                    break;
                case 2:
                    selectedDashStyle = DashStyle.Dot;
                    break;
                case 3:
                    selectedDashStyle = DashStyle.DashDot;
                    break;
                case 4:
                    selectedDashStyle = DashStyle.DashDotDot;
                    break;
            }

            if (shapeManager.Shapes.Count > 0)
            {
                for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
                {
                    ShapeBase s = shapeManager.SelectedShapes[i];
                    s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hình để thay đổi kiểu đường viền ! ");
            }
            pnlMain.Refresh();
        }


        private void btnLine_Click(object sender, EventArgs e)
        {
            refreshShape();
            bLine = true;
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            refreshShape();
            bRect = true;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            refreshShape();
            bEclippse = true;
        }

        private void btnTri_Click(object sender, EventArgs e)
        {
            refreshShape();
            bTri = true;
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            refreshShape();
            bPolygon = true;
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            refreshShape();
            bCurve = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshShape();
            this.bSword = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshShape();
            this.AWM = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refreshShape();
            this.bVietNamFlag = true;
        }

        public void refreshShape()
        {
            bLine = bEclippse = bRect = bPolygon = bCurve = bTri = AWM = bSword = bVietNamFlag = false;
        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (shapeManager.SelectedShapes.Count > 0)
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color color = colorDialog.Color;
                    btnFillColor.BackColor = color; // doi mau nen cua button
                    // thay doi tat ca hinh duoc chon luu trong danh sach chon
                    for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
                    {
                        ShapeBase s = shapeManager.SelectedShapes[i];
                        s.SetBrush(color);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hình để tô !");
            }
            pnlMain.Refresh();
            colorDialog.Dispose();
        }

        private void numPenWidth_ValueChanged(object sender, EventArgs e)
        {
            if (shapeManager.SelectedShapes.Count > 0)
            {
                selectedPenWidth = (int)numPenWidth.Value;
                for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
                {
                    ShapeBase shapeBase = shapeManager.SelectedShapes[i];
                    shapeBase.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hình để thay đổi độ dày bút !");
            }
            pnlMain.Refresh();
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteShape();
        }



        // ham xoa tat ca hinh trong danh sach xoa
        private void DeleteShape()
        {
            if (shapeManager.SelectedShapes.Count > 0)
            {
                for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
                {
                    shapeManager.Shapes.Remove(shapeManager.SelectedShapes[i]);
                }
                shapeManager.SelectedShapes.Clear(); // Xóa danh sách hình đã chọn
                pnlMain.Refresh(); // Vẽ lại giao diện
            }
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            selectedDashStyle = DashStyle.Solid;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            selectedDashStyle = DashStyle.Dash;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            selectedDashStyle = DashStyle.DashDot;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            selectedDashStyle = DashStyle.DashDotDot;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            selectedDashStyle = DashStyle.Dot;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void độDàyBútToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedPenWidth = 2;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            selectedPenWidth = 1;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            selectedPenWidth = 2;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            selectedPenWidth = 3;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            selectedPenWidth = 4;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            selectedPenWidth = 5;
            for (int i = 0; i < shapeManager.SelectedShapes.Count; i++)
            {
                ShapeBase s = shapeManager.SelectedShapes[i];
                s.SetPen(selectedColor, selectedPenWidth, selectedDashStyle);
            }
            pnlMain.Refresh();
        }


    }
}


