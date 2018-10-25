using System.Drawing;

// Common segments' properties

namespace NSegmentDisplay {
    public abstract class SegmentProperties {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BackColor { get; set; }

        public int TrgX { get; set; }
        public int TrgY { get; set; }

        public Pen POn;
        public Pen POff;

        private Color mForeColorOff;
        private Color mForeColorOn;
        private int mThickness;

        public int Thickness {
            get => mThickness;
            set {
                if(mThickness != value) {
                    mThickness = value;
                    CreatePens();
                }
            }
        }

        public Color ForeColorOff {
            get => mForeColorOff;
            set {
                if(mForeColorOff != value) {
                    mForeColorOff = value;
                    CreatePens();
                }
            }
        }

        public Color ForeColorOn {
            get => mForeColorOn;
            set {
                if(mForeColorOn != value) {
                    mForeColorOn = value;
                    CreatePens();
                }
            }
        }

        private void CreatePens() {
            if(POff != null) POff.Dispose();
            POff = new Pen(mForeColorOff, mThickness) {
                StartCap = System.Drawing.Drawing2D.LineCap.Triangle,
                EndCap = System.Drawing.Drawing2D.LineCap.Triangle
            };

            if(POn != null) POn.Dispose();
            POn = new Pen(mForeColorOn, mThickness) {
                StartCap = System.Drawing.Drawing2D.LineCap.Triangle,
                EndCap = System.Drawing.Drawing2D.LineCap.Triangle
            };
        }

        protected SegmentProperties() {
            Width = 40;
            Height = 60;
            Thickness = 12;
            ForeColorOff = Color.FromArgb(0, 50, 0);
            ForeColorOn = Color.LimeGreen;
            BackColor = Color.Transparent;
        }
    }
}
