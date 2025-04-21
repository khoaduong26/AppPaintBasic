namespace PaintBasic
{
    partial class Paint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Line = new System.Windows.Forms.Button();
            this.Curve = new System.Windows.Forms.Button();
            this.Ellipse = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.Square = new System.Windows.Forms.Button();
            this.Rectangle = new System.Windows.Forms.Button();
            this.Polygon = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Pen_Style = new System.Windows.Forms.ComboBox();
            this.PenThick = new System.Windows.Forms.NumericUpDown();
            this.ChoosePenColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlMain = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LineStyle = new System.Windows.Forms.ComboBox();
            this.ChooseLineColor = new System.Windows.Forms.Button();
            this.ChooseBrushColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Selection = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Delete_All = new System.Windows.Forms.Button();
            this.UnGroup = new System.Windows.Forms.Button();
            this.Group = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenThick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlMain)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(0, 126);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(91, 577);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Line);
            this.flowLayoutPanel1.Controls.Add(this.Curve);
            this.flowLayoutPanel1.Controls.Add(this.Ellipse);
            this.flowLayoutPanel1.Controls.Add(this.Circle);
            this.flowLayoutPanel1.Controls.Add(this.Square);
            this.flowLayoutPanel1.Controls.Add(this.Rectangle);
            this.flowLayoutPanel1.Controls.Add(this.Polygon);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(84, 457);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // Line
            // 
            this.Line.Image = global::PaintBasic.Properties.Resources.Screenshot_2025_04_08_231717;
            this.Line.Location = new System.Drawing.Point(3, 2);
            this.Line.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(75, 58);
            this.Line.TabIndex = 0;
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Curve
            // 
            this.Curve.Image = global::PaintBasic.Properties.Resources.Screenshot_2025_04_08_233002;
            this.Curve.Location = new System.Drawing.Point(3, 64);
            this.Curve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Curve.Name = "Curve";
            this.Curve.Size = new System.Drawing.Size(75, 58);
            this.Curve.TabIndex = 1;
            this.Curve.UseVisualStyleBackColor = true;
            this.Curve.Click += new System.EventHandler(this.Curve_Click);
            // 
            // Ellipse
            // 
            this.Ellipse.Image = global::PaintBasic.Properties.Resources.Screenshot_2025_04_08_233058;
            this.Ellipse.Location = new System.Drawing.Point(3, 126);
            this.Ellipse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(75, 58);
            this.Ellipse.TabIndex = 2;
            this.Ellipse.UseVisualStyleBackColor = true;
            this.Ellipse.Click += new System.EventHandler(this.Ellipse_Click);
            // 
            // Circle
            // 
            this.Circle.Image = global::PaintBasic.Properties.Resources.Screenshot_2025_04_08_233143;
            this.Circle.Location = new System.Drawing.Point(3, 188);
            this.Circle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(75, 58);
            this.Circle.TabIndex = 3;
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // Square
            // 
            this.Square.Image = global::PaintBasic.Properties.Resources.fd;
            this.Square.Location = new System.Drawing.Point(3, 250);
            this.Square.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(75, 58);
            this.Square.TabIndex = 4;
            this.Square.UseVisualStyleBackColor = true;
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.Image = global::PaintBasic.Properties.Resources.Screenshot_2025_04_08_233246;
            this.Rectangle.Location = new System.Drawing.Point(3, 312);
            this.Rectangle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(75, 58);
            this.Rectangle.TabIndex = 5;
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // Polygon
            // 
            this.Polygon.Image = global::PaintBasic.Properties.Resources.Screenshot_2025_04_08_233310__2_;
            this.Polygon.Location = new System.Drawing.Point(3, 374);
            this.Polygon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Polygon.Name = "Polygon";
            this.Polygon.Size = new System.Drawing.Size(75, 58);
            this.Polygon.TabIndex = 6;
            this.Polygon.UseVisualStyleBackColor = true;
            this.Polygon.Click += new System.EventHandler(this.Polygon_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 121);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Pen_Style);
            this.groupBox1.Controls.Add(this.PenThick);
            this.groupBox1.Controls.Add(this.ChoosePenColor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(319, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pen Properties";
            // 
            // Pen_Style
            // 
            this.Pen_Style.FormattingEnabled = true;
            this.Pen_Style.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.Pen_Style.Location = new System.Drawing.Point(141, 89);
            this.Pen_Style.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pen_Style.Name = "Pen_Style";
            this.Pen_Style.Size = new System.Drawing.Size(121, 26);
            this.Pen_Style.TabIndex = 5;
            this.Pen_Style.SelectedIndexChanged += new System.EventHandler(this.Pen_Style_SelectedIndexChanged);
            // 
            // PenThick
            // 
            this.PenThick.Location = new System.Drawing.Point(141, 60);
            this.PenThick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PenThick.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.PenThick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PenThick.Name = "PenThick";
            this.PenThick.Size = new System.Drawing.Size(120, 24);
            this.PenThick.TabIndex = 4;
            this.PenThick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PenThick.ValueChanged += new System.EventHandler(this.PenThick_ValueChanged);
            // 
            // ChoosePenColor
            // 
            this.ChoosePenColor.ForeColor = System.Drawing.Color.SpringGreen;
            this.ChoosePenColor.Location = new System.Drawing.Point(141, 25);
            this.ChoosePenColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChoosePenColor.Name = "ChoosePenColor";
            this.ChoosePenColor.Size = new System.Drawing.Size(172, 32);
            this.ChoosePenColor.TabIndex = 3;
            this.ChoosePenColor.Text = "Click to select color";
            this.ChoosePenColor.UseVisualStyleBackColor = true;
            this.ChoosePenColor.Click += new System.EventHandler(this.ChoosePenColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pen Style";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pen Thickness";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pen Color";
            // 
            // PlMain
            // 
            this.PlMain.Location = new System.Drawing.Point(93, 126);
            this.PlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlMain.Name = "PlMain";
            this.PlMain.Size = new System.Drawing.Size(994, 459);
            this.PlMain.TabIndex = 0;
            this.PlMain.TabStop = false;
            this.PlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PlMain_Paint);
            this.PlMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlMain_MouseClick);
            this.PlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlMain_MouseDown);
            this.PlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PlMain_MouseMove);
            this.PlMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlMain_MouseUp);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(333, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 121);
            this.panel3.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.LineStyle);
            this.groupBox2.Controls.Add(this.ChooseLineColor);
            this.groupBox2.Controls.Add(this.ChooseBrushColor);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(388, 116);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Brush Properties";
            // 
            // LineStyle
            // 
            this.LineStyle.FormattingEnabled = true;
            this.LineStyle.Items.AddRange(new object[] {
            "(None)",
            "Horizontal",
            "Vertical",
            "ForwardDiagonal",
            "BackwardDiagonal"});
            this.LineStyle.Location = new System.Drawing.Point(201, 86);
            this.LineStyle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LineStyle.Name = "LineStyle";
            this.LineStyle.Size = new System.Drawing.Size(181, 26);
            this.LineStyle.TabIndex = 6;
            this.LineStyle.SelectedIndexChanged += new System.EventHandler(this.LineStyle_SelectedIndexChanged);
            // 
            // ChooseLineColor
            // 
            this.ChooseLineColor.Location = new System.Drawing.Point(201, 54);
            this.ChooseLineColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChooseLineColor.Name = "ChooseLineColor";
            this.ChooseLineColor.Size = new System.Drawing.Size(181, 32);
            this.ChooseLineColor.TabIndex = 5;
            this.ChooseLineColor.Text = "Click to select color";
            this.ChooseLineColor.UseVisualStyleBackColor = true;
            this.ChooseLineColor.Click += new System.EventHandler(this.ChooseLineColor_Click);
            // 
            // ChooseBrushColor
            // 
            this.ChooseBrushColor.Location = new System.Drawing.Point(201, 18);
            this.ChooseBrushColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChooseBrushColor.Name = "ChooseBrushColor";
            this.ChooseBrushColor.Size = new System.Drawing.Size(181, 32);
            this.ChooseBrushColor.TabIndex = 4;
            this.ChooseBrushColor.Text = "Click to select color";
            this.ChooseBrushColor.UseVisualStyleBackColor = true;
            this.ChooseBrushColor.Click += new System.EventHandler(this.ChooseBrushColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Fill Line Style";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fill Line Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fill Background Color";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Location = new System.Drawing.Point(729, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(357, 124);
            this.panel4.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Selection);
            this.groupBox3.Controls.Add(this.Delete);
            this.groupBox3.Controls.Add(this.Delete_All);
            this.groupBox3.Controls.Add(this.UnGroup);
            this.groupBox3.Controls.Add(this.Group);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(340, 112);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other Tools";
            // 
            // Selection
            // 
            this.Selection.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Selection.Location = new System.Drawing.Point(221, 17);
            this.Selection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Selection.Name = "Selection";
            this.Selection.Size = new System.Drawing.Size(119, 86);
            this.Selection.TabIndex = 5;
            this.Selection.Text = "Selection";
            this.Selection.UseVisualStyleBackColor = true;
            this.Selection.Click += new System.EventHandler(this.Selection_Click);
            // 
            // Delete
            // 
            this.Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Delete.Location = new System.Drawing.Point(113, 23);
            this.Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(88, 34);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Delete_All
            // 
            this.Delete_All.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Delete_All.Location = new System.Drawing.Point(113, 74);
            this.Delete_All.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Delete_All.Name = "Delete_All";
            this.Delete_All.Size = new System.Drawing.Size(108, 34);
            this.Delete_All.TabIndex = 2;
            this.Delete_All.Text = "Delete All";
            this.Delete_All.UseVisualStyleBackColor = true;
            this.Delete_All.Click += new System.EventHandler(this.Delete_All_Click);
            // 
            // UnGroup
            // 
            this.UnGroup.ForeColor = System.Drawing.SystemColors.Desktop;
            this.UnGroup.Location = new System.Drawing.Point(5, 74);
            this.UnGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UnGroup.Name = "UnGroup";
            this.UnGroup.Size = new System.Drawing.Size(103, 34);
            this.UnGroup.TabIndex = 1;
            this.UnGroup.Text = "UnGroup";
            this.UnGroup.UseVisualStyleBackColor = true;
            this.UnGroup.Click += new System.EventHandler(this.UnGroup_Click);
            // 
            // Group
            // 
            this.Group.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Group.Location = new System.Drawing.Point(5, 23);
            this.Group.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(88, 34);
            this.Group.TabIndex = 0;
            this.Group.Text = "Group";
            this.Group.UseVisualStyleBackColor = true;
            this.Group.Click += new System.EventHandler(this.Group_Click);
            // 
            // Paint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1088, 593);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Paint";
            this.Text = "Paint";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenThick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlMain)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Curve;
        private System.Windows.Forms.Button Ellipse;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button Square;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button Polygon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Delete_All;
        private System.Windows.Forms.Button UnGroup;
        private System.Windows.Forms.Button Group;
        private System.Windows.Forms.Button Selection;
        private System.Windows.Forms.Button ChoosePenColor;
        private System.Windows.Forms.Button ChooseBrushColor;
        private System.Windows.Forms.Button ChooseLineColor;
        private System.Windows.Forms.NumericUpDown PenThick;
        private System.Windows.Forms.ComboBox Pen_Style;
        private System.Windows.Forms.ComboBox LineStyle;
    }
}

