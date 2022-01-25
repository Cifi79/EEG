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
    /// system of coordinate to draw the eye, the coordinate are in % respect the face dimension (i.e. Top = 0.5)
    /// </summary>
    struct Rectangle
    {
        public float Top;
        public float Bottom;
        public float Left;
        public float Right;

        public Rectangle(float top, float bottom, float left, float right)
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
        static Rectangle LeftAnger = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle LeftFear = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle LeftDisgust = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle LeftContempt = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle LeftJoy = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle LeftSadness = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle LeftSurprise = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle LeftNeutral = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle RightAnger = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle RightFear = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle RightDisgust = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle RightContempt = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle RightJoy = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle RightSadness = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle RightSurprise = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);
        static Rectangle RightNeutral = new Rectangle(0.1f, 0.1f, 0.1f, 0.1f);

        public Sides Side { get; private set; } = Sides.None;

        private Emotions _emotion = Emotions.Neutral;
        public Emotions Emotion
        {
            get { return _emotion; }
            set
            {
                _emotion = value;

                switch (_emotion)
                {
                    case Emotions.Anger:
                        Dimension = (Side == Sides.Left) ? EyeModel.LeftAnger : EyeModel.RightAnger;
                        break;
                    case Emotions.Fear:
                        Dimension = (Side == Sides.Left) ? EyeModel.LeftFear : EyeModel.RightFear;
                        break;
                    case Emotions.Disgust:
                        Dimension = (Side == Sides.Left) ? EyeModel.LeftDisgust : EyeModel.RightDisgust;
                        break;
                    case Emotions.Contempt:
                        Dimension = (Side == Sides.Left) ? EyeModel.LeftContempt : EyeModel.RightContempt;
                        break;
                    case Emotions.Joy:
                        Dimension = (Side == Sides.Left) ? EyeModel.LeftJoy : EyeModel.RightJoy;
                        break;
                    case Emotions.Sadness:
                        Dimension = (Side == Sides.Left) ? EyeModel.LeftSadness : EyeModel.RightSadness;
                        break;
                    case Emotions.Surprise:
                        Dimension = (Side == Sides.Left) ? EyeModel.LeftSurprise : EyeModel.RightSurprise;
                        break;
                    case Emotions.Neutral:
                        Dimension = (Side == Sides.Left) ? EyeModel.LeftNeutral : EyeModel.RightNeutral;
                        break;
                    default:
                        break;
                }
            }
        }

        public Color Color { get; set; } = new Color(125, 0, 250);
        public Rectangle Dimension { get; private set; } = new Rectangle(0.1f, 0.9f, 0.1f, 0.9f);
        /// <summary>
        /// the radius for the corner
        /// </summary>
        public int Radius { get; private set; } = 0;

        public EyeModel(Sides side)
        {
            Side = side;

            switch (Side)
            {
                case Sides.None:
                    break;
                case Sides.Left:
                    Dimension = new Rectangle(0.1f, 0.9f, 0.1f, 0.4f);
                    break;
                case Sides.Right:
                    Dimension = new Rectangle(0.1f, 0.9f, 0.6f, 0.9f);
                    break;
                default:
                    break;
            }
        }
    }

}
