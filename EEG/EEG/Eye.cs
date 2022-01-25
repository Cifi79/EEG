using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EEG
{
    internal enum Sides
    {
        None,
        Left,
        Right
    }

    class FaceVModel
    {
        private EyeVModel rightEye = new EyeVModel(Sides.Left);
        private EyeVModel leftEye = new EyeVModel(Sides.Right);

        private Emotions _emotion = Emotions.Neutral;
        public Emotions Emotion
        {
            get { return _emotion; }
            set { _emotion = value; }
        }

        internal void Paint(int height, int width, PaintEventArgs e)
        {
            rightEye.Paint(height,width,e);
            leftEye.Paint(height,width,e);
        }

        public FaceVModel()
        {

        }
    }

    class EyeVModel
    {
        private Emotions _emotion = Emotions.Neutral;
        public Emotions Emotion
        {
            get { return _emotion; }
            set {
                _eyeModel.Emotion = value;
                _emotion = value; 
            }
        }

        private EyeModel _eyeModel;

        public EyeVModel(Sides side)
        {
            _eyeModel = new EyeModel(side);
        }

        /// <summary>
        /// Paint the eye
        /// </summary>
        public void Paint(int height, int width, PaintEventArgs e)
        {
            RectangleF _rect = new RectangleF(width * _eyeModel.Dimension.Left, height * _eyeModel.Dimension.Top, width * (_eyeModel.Dimension.Right- _eyeModel.Dimension.Left),height * (_eyeModel.Dimension.Bottom- _eyeModel.Dimension.Top));

            SolidBrush blueBrush = new SolidBrush(System.Drawing.Color.FromArgb(_eyeModel.Color.R, _eyeModel.Color.G, _eyeModel.Color.B));
            e.Graphics.FillRectangle(blueBrush, _rect);
        }
    }

}
