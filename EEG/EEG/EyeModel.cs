namespace EEG
{
    struct Color
    {
        public int R;
        public int G;
        public int B;

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }

    /// <summary>
    /// system of coordinate to draw the eye, the coordinate are in % respect the face dimension
    /// </summary>
    struct Rectangle
    {
        public byte Top;
        public byte Bottom;
        public byte Left;
        public byte Right;

        public Rectangle(byte top, byte bottom, byte left, byte right)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }
    }

    /// <summary>
    /// Geometric caratheristics
    /// </summary>
    class EyeModel
    {
        public Sides Side { get; private set; } = Sides.None;
        public Color Color { get; set; } = new Color(125,0,250);
        public Rectangle Dimension { get; private set; } = new Rectangle(10, 10, 10, 10);
        /// <summary>
        /// the radius for the corner
        /// </summary>
        public int Radius { get; private set; } = 0;

        public EyeModel(Sides side)
        {
            Side = side;
        }
    }

}
