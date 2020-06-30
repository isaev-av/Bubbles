using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bubbles.Forms
{
    public partial class Circle : UserControl
    {
        private static int SpeedOfIncrease = 0;
        public static int BaseMoveSpeed = 1;
        private static int CircleSize;
        private Color color = Color.Azure;

        public static Circle[] Circles { get; private set; } = new Circle[0];
        public int moveSpeedX = MoveSpeed, moveSpeedY = MoveSpeed;

        private static int MoveSpeed => BaseMoveSpeed * SpeedOfIncrease / 10;

        protected override void OnPaint(PaintEventArgs e) => Print(this, e);

        public Circle(Color color, int size, int x = 0, int y = 0)
        {
            InitializeComponent();

            CircleSize = size;
            ClientSize = new Size(new Point(CircleSize, CircleSize));
            Location = new Point(x, y);
            this.color = color;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(ClientRectangle);
            Region region = new Region(path);
            Region = region;
            BorderStyle = BorderStyle.None;
        }

        private void Print(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            BackColor = color;

            e.Graphics.DrawEllipse(Pens.Black, 0, 0, CircleSize, CircleSize);
        }

        public static void SetUp(int numberOfCircles)
        {
            Circles = new Circle[numberOfCircles]; 
        }

        public static void Clear() => Circles = new Circle[0];

        public static void SetSpeed(int speed)
        {
            SpeedOfIncrease = speed;
        }

        public void IncreaseSizes()
        {
            this.Size = new Size(++CircleSize, CircleSize);
        }
    }
}
