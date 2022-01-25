using System;
using System.Collections.Generic;
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

        internal void Paint(PaintEventArgs e)
        {
            rightEye.Paint(e);
            leftEye.Paint(e);
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
            set { _emotion = value; }
        }

        private EyeModel _eyeModel;

        public EyeVModel(Sides side)
        {
            _eyeModel = new EyeModel(side);
        }

        /// <summary>
        /// Paint the eye
        /// </summary>
        public void Paint(PaintEventArgs e)
        {
            
        }
    }

}
