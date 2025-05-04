using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PaintBasic
{
    public partial class Paint : Form
    {
        Graphics gp;

        Color mycolor = Color.Blue;
        int myThickness;
        DashStyle penStyle;

        ColorDialog myColorDialog = new ColorDialog();
        Color newColor;

        Color brushFillColor = Color.Transparent;
        Color brushStrokeColor = Color.White;
        HatchStyle? mySelectedStyle = null;

        Bitmap myBitmap;

        List<clsDrawObject> lstObject = new List<clsDrawObject>();

        clsDrawObject selectedObject = null;
        clsDrawObject myCurrentObject;

        Point startPoint;

        bool isPress = false;
        bool isResizing = false;
        int resizePoint = 0;
        int index;
        bool btnSelect = true;
        clsPolygon currentPolygon = null;
        private object mySelectedObject;

        public Paint()
        {
            InitializeComponent();
            gp = this.PlMain.CreateGraphics();
            mycolor = Color.Black;
            myThickness = 1;
            ChoosePenColor.BackColor = mycolor;
            ChooseBrushColor.BackColor = brushFillColor;
            ChooseLineColor.BackColor = brushStrokeColor;
            penStyle = DashStyle.Solid;

            myBitmap = new Bitmap(PlMain.Width, PlMain.Height);
            gp = Graphics.FromImage(myBitmap);
            gp.Clear(Color.White);
        }
        // Lớp con sử dụng tính đa hình
        public abstract class clsDrawObject
        {
            public Point p1;
            public Point p2;

            public Pen myPen = new Pen(Color.Black, 2); // Dùng để vẽ đường viền
            public Brush myBrush = new SolidBrush(Color.Transparent); // Dùng để tô nền


            public bool Selected { get; set; } = false;

            public abstract void Draw(Graphics myGp);

            public virtual bool Contains(Point p)
            {
                Rectangle rect = new Rectangle(
                    Math.Min(p1.X, p2.X) - 5,
                    Math.Min(p1.Y, p2.Y) - 5,
                    Math.Abs(p2.X - p1.X) + 10,
                    Math.Abs(p2.Y - p1.Y) + 10);

                return rect.Contains(p);
            }

            public virtual void Resize(Point newPoint, int resizePoint)
            {
                if (resizePoint == 1)
                    p1 = newPoint;
                else if (resizePoint == 2)
                    p2 = newPoint;

                if (Math.Abs(p2.X - p1.X) < 5)
                    p2.X = p1.X + 5;
                if (Math.Abs(p2.Y - p1.Y) < 5)
                    p2.Y = p1.Y + 5;
            }

            public virtual void Move(int dx, int dy)
            {
                p1.X += dx;
                p1.Y += dy;
                p2.X += dx;
                p2.Y += dy;
            }

            public virtual void DrawSelection(Graphics myGp)
            {
                if (Selected)
                {
                    Pen selectionPen = new Pen(Color.Black, 1)
                    { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };

                    Rectangle rect = new Rectangle(
                        Math.Min(p1.X, p2.X),
                        Math.Min(p1.Y, p2.Y),
                        Math.Abs(p2.X - p1.X),
                        Math.Abs(p2.Y - p1.Y));

                    myGp.DrawRectangle(selectionPen, rect);

                    Brush handleBrush = Brushes.Black;
                    myGp.FillRectangle(handleBrush, rect.Left - 3, rect.Top - 3, 5, 5);
                    myGp.FillRectangle(handleBrush, rect.Right - 3, rect.Bottom - 3, 5, 5);
                }
            }
        }
        public class clsLine : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                myGp.DrawLine(myPen, p1, p2);
            }
        }
        public class clsRectangle : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                myGp.FillRectangle(myBrush, x, y, width, height);
                myGp.DrawRectangle(myPen, x, y, width, height);
            }
        }
        public class clsEllipse : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);

                myGp.FillEllipse(myBrush, x, y, width, height);
                myGp.DrawEllipse(myPen, x, y, width, height);
            }
        }
        public class clsSquare : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int dx = p2.X - p1.X;
                int dy = p2.Y - p1.Y;

                int sideLength = Math.Min(Math.Abs(dx), Math.Abs(dy));

                int x = p1.X;
                int y = p1.Y;

                if (dx < 0) x -= sideLength;
                if (dy < 0) y -= sideLength;

                p2 = new Point(x + sideLength, y + sideLength);

                myGp.DrawRectangle(myPen, x, y, sideLength, sideLength);
                myGp.FillRectangle(myBrush, x, y, sideLength, sideLength);
            }
        }
        public class clsCircle : clsDrawObject
        {
            public override void Draw(Graphics myGp)
            {
                int radius = Math.Min(Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y)) / 2;
                int centerX = (p1.X + p2.X) / 2;
                int centerY = (p1.Y + p2.Y) / 2;

                myGp.DrawEllipse(myPen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
                myGp.FillEllipse(myBrush, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            }
        }
        public class clsCurve : clsDrawObject
        {
            public Point controlPoint;

            public clsCurve(Point p1, Point p2, Point control)
            {
                this.p1 = p1;
                this.p2 = p2;
                this.controlPoint = control;
            }

            public override void Draw(Graphics myGp)
            {
                myGp.DrawBezier(myPen, p1, controlPoint, controlPoint, p2);

                if (Selected)
                {
                    DrawSelection(myGp);
                }
            }

            public override void Move(int dx, int dy)
            {
                base.Move(dx, dy);
                controlPoint.X += dx;
                controlPoint.Y += dy;
            }

            public override void DrawSelection(Graphics myGp)
            {
                base.DrawSelection(myGp);
                myGp.DrawEllipse(Pens.Blue, controlPoint.X - 5, controlPoint.Y - 5, 10, 10);
            }
        }
        public class clsPolygon : clsDrawObject
        {
            public List<Point> Points = new List<Point>();
            public bool IsClosed = false;

            public void AddPoint(Point p)
            {
                if (Points.Count > 1 && Distance(p, Points[0]) < 10)
                {
                    IsClosed = true;
                }
                else
                {
                    Points.Add(p);
                }
            }

            public override void Draw(Graphics g)
            {
                if (Points.Count < 2)
                    return;

                for (int i = 0; i < Points.Count - 1; i++)
                {
                    g.DrawLine(myPen, Points[i], Points[i + 1]);
                }

                if (IsClosed)
                {
                    g.DrawLine(myPen, Points[Points.Count - 1], Points[0]);
                    g.FillPolygon(myBrush, Points.ToArray());
                }
            }

            private float Distance(Point p1, Point p2)
            {
                return (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            }

            public override bool Contains(Point p)
            {
                if (IsClosed)
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddPolygon(Points.ToArray());
                        return path.IsVisible(p);
                    }
                }
                return false;
            }

            public override void Move(int dx, int dy)
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    Points[i] = new Point(Points[i].X + dx, Points[i].Y + dy);
                }
            }
            public override void Resize(Point newPoint, int resizePoint)
            {
                // Tính toán khung bao (bounding box) của đa giác
                int minX = int.MaxValue, minY = int.MaxValue;
                int maxX = int.MinValue, maxY = int.MinValue;

                foreach (var point in Points)
                {
                    minX = Math.Min(minX, point.X);
                    minY = Math.Min(minY, point.Y);
                    maxX = Math.Max(maxX, point.X);
                    maxY = Math.Max(maxY, point.Y);
                }

                int oldWidth = maxX - minX;
                int oldHeight = maxY - minY;

                if (oldWidth <= 0 || oldHeight <= 0) return; // Tránh chia cho 0

                // Xác định điểm mới của khung bao
                Point newP1 = new Point(minX, minY); // Top-left
                Point newP2 = new Point(maxX, maxY); // Bottom-right

                if (resizePoint == 1) // Resize từ góc trên-trái
                    newP1 = newPoint;
                else if (resizePoint == 2) // Resize từ góc dưới-phải
                    newP2 = newPoint;

                // Tính toán kích thước khung bao mới
                int newMinX = Math.Min(newP1.X, newP2.X);
                int newMinY = Math.Min(newP1.Y, newP2.Y);
                int newWidth = Math.Abs(newP2.X - newP1.X);
                int newHeight = Math.Abs(newP2.Y - newP1.Y);

                if (newWidth <= 5 || newHeight <= 5) return; // Đảm bảo kích thước tối thiểu

                // Tính tỷ lệ co giãn
                float scaleX = (float)newWidth / oldWidth;
                float scaleY = (float)newHeight / oldHeight;

                // Cập nhật vị trí các điểm
                for (int i = 0; i < Points.Count; i++)
                {
                    int newX = newMinX + (int)((Points[i].X - minX) * scaleX);
                    int newY = newMinY + (int)((Points[i].Y - minY) * scaleY);
                    Points[i] = new Point(newX, newY);
                }

                // Cập nhật p1 và p2 để đồng bộ với lớp cha
                p1 = new Point(newMinX, newMinY);
                p2 = new Point(newMinX + newWidth, newMinY + newHeight);
            }
            public override void DrawSelection(Graphics myGp)
            {
                if (Selected && Points.Count > 0)
                {
                    // Tính toán khung bao
                    int minX = int.MaxValue, minY = int.MaxValue;
                    int maxX = int.MinValue, maxY = int.MinValue;

                    foreach (var point in Points)
                    {
                        minX = Math.Min(minX, point.X);
                        minY = Math.Min(minY, point.Y);
                        maxX = Math.Max(maxX, point.X);
                        maxY = Math.Max(maxY, point.Y);
                    }

                    Rectangle boundingRect = new Rectangle(minX, minY, maxX - minX, maxY - minY);

                    // Vẽ khung chọn
                    Pen selectionPen = new Pen(Color.Gray, 1) { DashStyle = DashStyle.Dash };
                    myGp.DrawRectangle(selectionPen, boundingRect);

                    // Vẽ các điểm điều khiển
                    Brush handleBrush = Brushes.Black;
                    myGp.FillRectangle(handleBrush, boundingRect.Left - 3, boundingRect.Top - 3, 6, 6); // Top-left
                    myGp.FillRectangle(handleBrush, boundingRect.Right - 3, boundingRect.Bottom - 3, 6, 6); // Bottom-right
                }
            }
        }
        public class clsGroup : clsDrawObject
        {
            public enum GroupResizeMode { ScaleAll, ResizeBoundingOnly }
            public GroupResizeMode ResizeMode { get; set; } = GroupResizeMode.ScaleAll;

            public List<clsDrawObject> GroupedObjects { get; set; } = new List<clsDrawObject>();

            private Rectangle boundingRect;

            public clsGroup()
            {
                p1 = new Point();
                p2 = new Point();
            }

            // Cập nhật lại bounding box của nhóm
            public void UpdateBoundingBox()
            {
                if (GroupedObjects == null || GroupedObjects.Count == 0)
                    return;

                int minX = int.MaxValue, minY = int.MaxValue;
                int maxX = int.MinValue, maxY = int.MinValue;

                foreach (var obj in GroupedObjects)
                {
                    minX = Math.Min(minX, Math.Min(obj.p1.X, obj.p2.X));
                    minY = Math.Min(minY, Math.Min(obj.p1.Y, obj.p2.Y));
                    maxX = Math.Max(maxX, Math.Max(obj.p1.X, obj.p2.X));
                    maxY = Math.Max(maxY, Math.Max(obj.p1.Y, obj.p2.Y));
                }

                p1 = new Point(minX, minY);
                p2 = new Point(maxX, maxY);
                boundingRect = new Rectangle(minX, minY, maxX - minX, maxY - minY);
            }

            public override void Draw(Graphics myGp)
            {
                foreach (var obj in GroupedObjects)
                {
                    obj.Draw(myGp);
                }
            }

            // Chỉnh sửa để hỗ trợ resize nhóm
            public override void Resize(Point newPoint, int resizePoint)
            {
                UpdateBoundingBox(); // Đảm bảo boundingRect chính xác

                int oldMinX = boundingRect.Left;
                int oldMinY = boundingRect.Top;
                int oldWidth = boundingRect.Width;
                int oldHeight = boundingRect.Height;

                if (oldWidth == 0 || oldHeight == 0) return;

                Point newP1 = p1;
                Point newP2 = p2;

                if (resizePoint == 1)
                    newP1 = newPoint; // Top-left
                else if (resizePoint == 2)
                    newP2 = newPoint; // Bottom-right
                else
                    return;

                int newMinX = Math.Min(newP1.X, newP2.X);
                int newMinY = Math.Min(newP1.Y, newP2.Y);
                int newWidth = Math.Abs(newP2.X - newP1.X);
                int newHeight = Math.Abs(newP2.Y - newP1.Y);

                if (newWidth == 0 || newHeight == 0) return;

                if (ResizeMode == GroupResizeMode.ScaleAll)
                {
                    float scaleX_p2 = (float)(newWidth - oldWidth);
                    float scaleY_p2 = (float)(newHeight - oldHeight);

                    float scaleX_p1 = (float)(newMinX - oldMinX);
                    float scaleY_p1 = (float)(newMinY - oldMinY);

                    foreach (var obj in GroupedObjects)
                    {
                        obj.p2.X = (int)(obj.p2.X + scaleX_p2);
                        obj.p2.Y = (int)(obj.p2.Y + scaleY_p2);
                        obj.Resize(obj.p2, 2);

                        obj.p1.X = (int)(obj.p1.X + scaleX_p1);
                        obj.p1.Y = (int)(obj.p1.Y + scaleY_p1);
                        obj.Resize(obj.p1, 1);
                    }
                }

                p1 = newP1;
                p2 = newP2;
                UpdateBoundingBox();
            }

            public override void Move(int dx, int dy)
            {
                foreach (var obj in GroupedObjects)
                {
                    obj.Move(dx, dy);
                }
                UpdateBoundingBox();
            }

            public override bool Contains(Point p)
            {
                UpdateBoundingBox();
                Rectangle enlargedRect = new Rectangle(boundingRect.Left - 5, boundingRect.Top - 5, boundingRect.Width + 10, boundingRect.Height + 10);
                return enlargedRect.Contains(p);
            }

            public override void DrawSelection(Graphics myGp)
            {
                if (Selected && GroupedObjects.Count > 0)
                {
                    UpdateBoundingBox();

                    Pen selectionPen = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                    myGp.DrawRectangle(selectionPen, boundingRect);

                    Brush handleBrush = Brushes.Black;
                    myGp.FillRectangle(handleBrush, boundingRect.Left - 3, boundingRect.Top - 3, 6, 6); // top-left
                    myGp.FillRectangle(handleBrush, boundingRect.Right - 3, boundingRect.Bottom - 3, 6, 6); // bottom-right
                }
            }
        }
        // Pen Properties
        private void Pen_Style_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Pen_Style.SelectedItem.ToString())
            {
                case "Solid":
                    penStyle = DashStyle.Solid;
                    break;
                case "Dash":
                    penStyle = DashStyle.Dash;
                    break;
                case "Dot":
                    penStyle = DashStyle.Dot;
                    break;
                case "DashDot":
                    penStyle = DashStyle.DashDot;
                    break;
                case "DashDotDot":
                    penStyle = DashStyle.DashDotDot;
                    break;
            }
            this.PlMain.Invalidate();
        }
        private void ChoosePenColor_Click(object sender, EventArgs e)
        {
            myColorDialog.ShowDialog();
            newColor = myColorDialog.Color;
            ChoosePenColor.BackColor = newColor;
            mycolor = newColor;
        }
        private void PenThick_ValueChanged(object sender, EventArgs e)
        {
            myThickness = (int)PenThick.Value;
        }

        // Brush Properties
        private void ChooseBrushColor_Click(object sender, EventArgs e)
        {
            if (myColorDialog.ShowDialog() == DialogResult.OK)
            {
                brushFillColor = myColorDialog.Color;
                ChooseBrushColor.BackColor = brushFillColor;

                if (selectedObject != null)
                {
                    if (mySelectedStyle.HasValue)
                    {
                        selectedObject.myBrush = new HatchBrush(mySelectedStyle.Value, brushFillColor, brushStrokeColor);
                    }
                    else
                    {
                        selectedObject.myBrush = new SolidBrush(brushFillColor);
                    }

                    this.PlMain.Invalidate(); // Làm mới giao diện
                }
            }
        }
        private void ChooseLineColor_Click(object sender, EventArgs e)
        {
            myColorDialog.ShowDialog();
            brushStrokeColor = myColorDialog.Color;
            ChooseLineColor.BackColor = brushStrokeColor;
        }
        private void LineStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LineStyle.SelectedItem != null)
            {
                switch (LineStyle.SelectedItem.ToString())
                {
                    case "Horizontal":
                        mySelectedStyle = HatchStyle.Horizontal;
                        break;
                    case "Vertical":
                        mySelectedStyle = HatchStyle.Vertical;
                        break;
                    case "ForwardDiagonal":
                        mySelectedStyle = HatchStyle.ForwardDiagonal;
                        break;
                    case "BackwardDiagonal":
                        mySelectedStyle = HatchStyle.BackwardDiagonal;
                        break;
                    case "(None)":
                        mySelectedStyle = null;
                        break;
                    default:
                        mySelectedStyle = HatchStyle.Horizontal; // Giá trị mặc định nếu không nhận diện được
                        break;
                }

                if (selectedObject != null)
                {
                    if (mySelectedStyle.HasValue)
                    {
                        selectedObject.myBrush = new HatchBrush(mySelectedStyle.Value, brushFillColor, brushStrokeColor);
                    }
                    else
                    {
                        selectedObject.myBrush = new SolidBrush(brushFillColor);
                    }

                    this.PlMain.Invalidate(); // Làm mới giao diện
                }
            }
        }

        private void Line_Click(object sender, EventArgs e)
        {
            index = 1;
            isPress = false;
            btnSelect = false;
        }

        private void Curve_Click(object sender, EventArgs e)
        {
            index = 6;
            isPress = false;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            index = 3;
            isPress = false;
            btnSelect = false;
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            index = 5;
            isPress = false;
            btnSelect = false;
        }

        private void Square_Click(object sender, EventArgs e)
        {
            index = 4;
            isPress = false;
            btnSelect = false;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            index = 2;
            isPress = false;
            btnSelect = false;
        }

        private void Polygon_Click(object sender, EventArgs e)
        {
            index = 7;
            isPress = false;
            btnSelect = false;
        }
        // Tools 

        private void Selection_Click(object sender, EventArgs e)
        {
            Color DefaultColor = Color.White;
            Color SetColor = Color.Gray;
            if (Selection.BackColor == DefaultColor)
            {
                Selection.BackColor = SetColor;
            }
            else
            {
                Selection.BackColor = DefaultColor;
            }
            btnSelect = true;
            isPress = false;
            index = 0;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<clsDrawObject> newList = new List<clsDrawObject>();

            foreach (var obj in lstObject)
            {
                if (!obj.Selected)
                {
                    newList.Add(obj);
                }
            }

            lstObject = newList;

            this.PlMain.Invalidate();
        }

        private void Delete_All_Click(object sender, EventArgs e)
        {
            gp.Clear(Color.White);

            lstObject.Clear();

            foreach (var obj in lstObject)
            {
                obj.Draw(gp);
            }

            PlMain.Invalidate();
        }
        private void UnGroup_Click(object sender, EventArgs e)
        {
            clsGroup selectedGroup = null;
            foreach (var obj in lstObject)
            {
                if (obj.Selected && obj is clsGroup)
                {
                    selectedGroup = obj as clsGroup;
                    break;
                }
            }

            if (selectedGroup != null)
            {
                foreach (var childObj in selectedGroup.GroupedObjects)
                {
                    lstObject.Add(childObj);
                }

                lstObject.Remove(selectedGroup);

                foreach (var obj in lstObject)
                {
                    obj.Selected = false;
                }

                this.PlMain.Invalidate();
            }
        }
        private void Group_Click(object sender, EventArgs e)
        {
            List<clsDrawObject> selectedObjects = new List<clsDrawObject>();
            foreach (var obj in lstObject)
            {
                if (obj.Selected)
                {
                    selectedObjects.Add(obj);
                }
            }

            if (selectedObjects.Count > 1)
            {
                clsGroup group = new clsGroup();

                foreach (var obj in selectedObjects)
                {
                    group.GroupedObjects.Add(obj);
                }

                foreach (var obj in selectedObjects)
                {
                    lstObject.Remove(obj);
                }

                lstObject.Add(group);

                foreach (var obj in lstObject)
                {
                    obj.Selected = false;
                }

                group.Selected = true;

                this.PlMain.Invalidate();
            }
        }
        // Event 
        private void PlMain_MouseMove(object sender, MouseEventArgs e)
        {
            bool nearHandle = false;

            if (selectedObject != null)
            {
                Rectangle rect = new Rectangle(
                    Math.Min(selectedObject.p1.X, selectedObject.p2.X),
                    Math.Min(selectedObject.p1.Y, selectedObject.p2.Y),
                    Math.Abs(selectedObject.p2.X - selectedObject.p1.X),
                    Math.Abs(selectedObject.p2.Y - selectedObject.p1.Y));

                if (Math.Abs(e.X - selectedObject.p1.X) < 10 && Math.Abs(e.Y - selectedObject.p1.Y) < 10)
                {
                    this.Cursor = Cursors.SizeNWSE;
                    nearHandle = true;
                }
                else if (Math.Abs(e.X - selectedObject.p2.X) < 10 && Math.Abs(e.Y - selectedObject.p2.Y) < 10)
                {
                    this.Cursor = Cursors.SizeNWSE;
                    nearHandle = true;
                }
            }

            if (!nearHandle)
            {
                this.Cursor = Cursors.Default;
            }

            if (isPress && isResizing && selectedObject != null)
            {
                selectedObject.Resize(e.Location, resizePoint);
                this.PlMain.Invalidate();
            }
            else if (isPress && myCurrentObject != null)
            {
                myCurrentObject.p2 = e.Location;
                this.PlMain.Invalidate();
            }
            else if (isPress && selectedObject != null)
            {
                int dx = e.X - startPoint.X;
                int dy = e.Y - startPoint.Y;

                selectedObject.Move(dx, dy);

                startPoint = e.Location;
                this.PlMain.Invalidate();
            }
        }

        private void PlMain_MouseUp(object sender, MouseEventArgs e)
        {
            isPress = false;

            if (isResizing)
            {
                isResizing = false;
                resizePoint = 0;
                return;
            }
            if (myCurrentObject != null)
            {
                myCurrentObject.p2 = e.Location;
                this.lstObject.Add(myCurrentObject);
                myCurrentObject = null;
            }

            this.PlMain.Invalidate();
        }

        private void PlMain_MouseClick(object sender, MouseEventArgs e)
        {
            // Xử lý vẽ hình đa giác
            if (index == 7)
            {
                if (currentPolygon == null || currentPolygon.IsClosed)
                {
                    currentPolygon = new clsPolygon();
                    currentPolygon.myPen = new Pen(mycolor, myThickness) { DashStyle = penStyle };
                    if (mySelectedStyle.HasValue)
                    {
                        currentPolygon.myBrush = new HatchBrush(mySelectedStyle.Value, brushFillColor, brushStrokeColor);
                    }
                    else
                    {
                        currentPolygon.myBrush = new SolidBrush(brushFillColor);
                    }
                    lstObject.Add(currentPolygon);
                }

                currentPolygon.AddPoint(e.Location);
                this.Invalidate();
            }
        }

        private void PlMain_MouseDown(object sender, MouseEventArgs e)
        {
            isPress = true;
            startPoint = e.Location;

            if (e.Button == MouseButtons.Right || btnSelect == false)
            {
                foreach (var obj in lstObject)
                {
                    obj.Selected = false;
                }
            }

            if (Control.ModifierKeys == Keys.Control)
            {
                foreach (var obj in lstObject)
                {
                    if (obj.Contains(e.Location))
                    {
                        obj.Selected = !obj.Selected;
                        this.PlMain.Invalidate();
                        return;
                    }
                }
            }
            else
            {
                foreach (var obj in lstObject)
                {
                    if (obj.Contains(e.Location) && btnSelect == true)
                    {
                        foreach (var o in lstObject)
                            o.Selected = false;

                        obj.Selected = true;
                        selectedObject = obj;

                        if (Math.Abs(e.X - obj.p1.X) < 10 && Math.Abs(e.Y - obj.p1.Y) < 10)
                        {
                            isResizing = true;
                            resizePoint = 1;
                            return;
                        }
                        else if (Math.Abs(e.X - obj.p2.X) < 10 && Math.Abs(e.Y - obj.p2.Y) < 10)
                        {
                            isResizing = true;
                            resizePoint = 2;
                            return;
                        }
                        else
                        {
                            isResizing = false;
                        }

                        this.PlMain.Invalidate();
                        return;
                    }
                }

                selectedObject = null;
                myCurrentObject = null;

                if (index == 1)
                    myCurrentObject = new clsLine();
                else if (index == 2)
                    myCurrentObject = new clsRectangle();
                else if (index == 3)
                    myCurrentObject = new clsEllipse();
                else if (index == 4)
                    myCurrentObject = new clsSquare();
                else if (index == 5)
                    myCurrentObject = new clsCircle();
                else if (index == 6)
                    myCurrentObject = new clsCurve(e.Location, e.Location, e.Location);
                else if (index == 7)
                    myCurrentObject = null; 

                if (myCurrentObject != null)
                {
                    myCurrentObject.myPen.Color = mycolor;
                    myCurrentObject.myPen.Width = myThickness;
                    myCurrentObject.myPen.DashStyle = penStyle;

                    if (mySelectedStyle.HasValue)
                    {
                        myCurrentObject.myBrush = new HatchBrush(mySelectedStyle.Value, brushFillColor, brushStrokeColor);
                    }
                    else
                    {
                        myCurrentObject.myBrush = new SolidBrush(brushFillColor);
                    }

                    myCurrentObject.p1 = e.Location;
                    myCurrentObject.p2 = e.Location;
                }
            }
            this.PlMain.Invalidate();
        }

        private void PlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(myBitmap, 0, 0);

            // Vẽ các đối tượng và lựa chọn
            foreach (var obj in lstObject)
            {
                obj.Draw(e.Graphics);
                if (btnSelect == true)
                {
                    obj.DrawSelection(e.Graphics);
                }
            }

            // Vẽ đối tượng hiện tại nếu có
            if (myCurrentObject != null)
            {
                myCurrentObject.Draw(e.Graphics);
            }
        }       
    }
}
