using System;
using System.Collections.Generic;
using System.Drawing;

namespace NSegmentDisplay {
    public abstract class NSegments : SegmentProperties, INSegments {
        protected int mX = 0;
        protected int mY = 0;
        protected int mWidth;
        protected int mHeight;
        protected int mThickness;
        protected Color mForeColorOff;
        protected Color mForeColorOn;
        protected Color mBackColor = Color.Transparent;
        protected int mPadding = 0;
        protected int mValue;

        protected Segment[] segments;

        public Rectangle Bounds {
            get {
                return new Rectangle(segments[5].X,
                                     segments[0].Y,
                                     segments[1].X + segments[1].Thickness - mX,
                                     segments[3].Y + segments[3].Thickness - mY);
            }
        }
        public List<int> Encodings { get; } = new List<int>();
        public int Value {
            get => mValue;
            set => mValue = value % Encodings.Count;
        }

        public new int X {
            get => mX;
            set {
                if(mX != value) {
                    mX = value;
                    SetupSegments();
                }
            }
        }

        public new int Y {
            get => mY;
            set {
                if(mY != value) {
                    mY = value;
                    SetupSegments();
                }
            }
        }

        public new int Width {
            get => mWidth;
            set {
                if(mWidth != value) {
                    mWidth = value;
                    SetupSegments();
                }
            }
        }

        public new int Height {
            get => mHeight;
            set {
                if(mHeight != value) {
                    mHeight = value;
                    SetupSegments();
                }
            }
        }

        public new int Thickness {
            get => mThickness;
            set {
                if(mThickness != value) {
                    mThickness = value;
                    SetupSegments();
                }
            }
        }

        public new Color ForeColorOff {
            get => mForeColorOff;
            set {
                if(mForeColorOff != value) {
                    mForeColorOff = value;
                    SetupSegments();
                }
            }
        }

        public new Color ForeColorOn {
            get => mForeColorOn;
            set {
                if(mForeColorOn != value) {
                    mForeColorOn = value;
                    SetupSegments();
                }
            }
        }

        public new Color BackColor {
            get => mBackColor;
            set {
                if(mBackColor != value) {
                    mBackColor = value;
                    SetupSegments();
                }
            }
        }

        public int Padding {
            get => mPadding;
            set {
                if(mPadding != value) {
                    mPadding = value;
                    SetupSegments();
                }
            }
        }

        public abstract void SetupSegments();

        public virtual void Render(Graphics g) {
            using(SolidBrush b = new SolidBrush(BackColor)) {
                g.FillRectangle(b, this.Bounds);
            }

            int encoding = Encodings[Value];
            for(int i = segments.Length - 1; i >= 0; i--) {
                segments[i].State = (encoding & (int)Math.Pow(2, i)) != 0;
                segments[i].Render(g);
            }
        }
    }
}
