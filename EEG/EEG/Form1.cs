using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EEG
{
    public partial class Form1 : Form
    {
        FaceVModel TheFace = new FaceVModel();

        public Form1()
        {
            InitializeComponent();
            Polygons = new List<List<Point>>();

            List<Point> RightEye = new List<Point>();
            RightEye.Add(new Point(10, 10));
            RightEye.Add(new Point(10, 50));
            RightEye.Add(new Point(50, 50));
            RightEye.Add(new Point(50, 10));

            Polygons.Add(RightEye);

            List<Point> LeftEye = new List<Point>();
            LeftEye.Add(new Point(90, 10));
            LeftEye.Add(new Point(90, 50));
            LeftEye.Add(new Point(140, 50));
            LeftEye.Add(new Point(140, 10));

            Polygons.Add(LeftEye);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            TheFace.Paint(pictureBox1.Size.Height, pictureBox1.Size.Width, e);
            Pen pen = new Pen(new SolidBrush(System.Drawing.Color.Yellow), 2);
            e.Graphics.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            //draw polygon
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(pictureBox1.BackColor);

            // Draw the old polygons.
            foreach (List<Point> polygon in Polygons)
            {
                e.Graphics.FillPolygon(Brushes.White, polygon.ToArray());
                e.Graphics.DrawPolygon(Pens.Blue, polygon.ToArray());

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

        //Thanks to http://csharphelper.com/blog/2014/10/let-the-user-draw-polygons-in-c/ for this part of code

        // Each polygon is represented by a List.
        private List<List<Point>> Polygons = new List<List<Point>>();
        // See if the mouse is over a polygon's edge.
        private bool MouseIsOverEdge(Point mouse_pt, out List<Point> hit_polygon, out Point closest_point)
        {
            foreach (var _poly in Polygons)
            {
                foreach (var _point in _poly)
                {
                    if (FindDistancePoint(mouse_pt, _point) < 10)
                    {
                        // We're over this segment.
                        hit_polygon = _poly;
                        closest_point = Point.Round(_point);
                        return true;
                    }
                }
            }
            hit_polygon = null;
            closest_point = new Point(0, 0);
            return false;
        }

        private int FindDistancePoint(Point mouse_pt, Point point)
        {
            return (int)(Math.Pow(mouse_pt.X - point.X, 2) + Math.Pow(mouse_pt.Y - point.Y, 2));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (MouseIsOverEdge(new Point(e.X, e.Y), out List<Point> hit_polygon, out Point closest_point))
            {
                label1.Text = $"X: {closest_point.X} Y: {closest_point.Y}";
                Cursor = Cursors.SizeAll;
            }
            else
                Cursor = Cursors.Default;
        }
    }
}
