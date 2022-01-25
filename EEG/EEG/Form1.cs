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

        //Thanks to http://csharphelper.com/blog/2014/10/let-the-user-draw-polygons-in-c/ for this part of code

        // Each polygon is represented by a List.
        private List<List<Point>> Polygons = new List<List<Point>>();
        // See if the mouse is over a polygon's edge.
        private bool MouseIsOverEdge(Point mouse_pt,
            out List<Point> hit_polygon, out int hit_pt1,
            out int hit_pt2, out Point closest_point)
        {
            // Examine each polygon.
            // Examine them in reverse order to check those on top first.
            for (int pgon = Polygons.Count - 1; pgon >= 0; pgon--)
            {
                var polygon = Polygons[pgon];

                // See if we're over one of the polygon's segments.
                for (int p1 = 0; p1 < polygon.Count; p1++)
                {
                    // Get the index of the polygon's next point.
                    int p2 = (p1 + 1) % polygon.Count;

                    // See if we're over the segment between these points.
                    PointF closest;
                    if (FindDistanceToSegmentSquared(mouse_pt, polygon[p1], polygon[p2], out closest) < 10)
                    {
                        // We're over this segment.
                        hit_polygon = polygon;
                        hit_pt1 = p1;
                        hit_pt2 = p2;
                        closest_point = Point.Round(closest);
                        return true;
                    }
                }
            }

            hit_polygon = null;
            hit_pt1 = -1;
            hit_pt2 = -1;
            closest_point = new Point(0, 0);
            return false;
        }

        private int FindDistanceToSegmentSquared(Point mouse_pt, Point point1, Point point2, out PointF closest)
        {
            double dist1 = Math.Pow(mouse_pt.X - point1.X, 2) + Math.Pow(mouse_pt.Y - point1.Y, 2);
            double dist2 = Math.Pow(mouse_pt.X - point2.X, 2) + Math.Pow(mouse_pt.Y - point2.Y, 2);

            closest = (dist1 < dist2) ? point1 : point2;
            return (int)((dist1 < dist2) ? dist1 : dist2);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (MouseIsOverEdge(new Point(e.X,e.Y), out List<Point> hit_polygon, out int hit_point, out int hit_point2, out Point closest_point))
            {
                
            }
        }
    }
}
