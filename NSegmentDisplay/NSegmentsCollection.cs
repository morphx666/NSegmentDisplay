using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

// Container for a collection of seven segments

namespace NSegmentDisplay {
    public class NSegmentsCollection : SegmentProperties, IList<NSegments> {
        private int mX = 0;
        private int dX = 0;
        private int mY = 0;
        private int dY = 0;
        private int mWidth;
        private int dW = 0;
        private int mHeight;
        private int dH = 0;
        private int mThickness;
        private int dT = 0;
        private Color mForeColorOff;
        private Color mForeColorOn;
        private Color mBackColor = Color.Transparent;

        public List<NSegments> NSegments { get; } = new List<NSegments>();

        public NSegmentsCollection() {
            mWidth = base.Width;
            mHeight = base.Height;
            mThickness = base.Thickness;
            mForeColorOff = base.ForeColorOff;
            mForeColorOn = base.ForeColorOn;
        }

        public new int X {
            get => mX;
            set {
                if(mX != value) {
                    dX = value - mX;
                    mX = value;
                    SetupSegments();
                }
            }
        }

        public new int Y {
            get => mY;
            set {
                if(mY != value) {
                    dY = value - mY;
                    mY = value;
                    SetupSegments();
                }
            }
        }

        public new int Width {
            get => mWidth;
            set {
                if(mWidth != value) {
                    dW = value - mWidth;
                    mWidth = value;
                    SetupSegments();
                }
            }
        }

        public new int Height {
            get => mHeight;
            set {
                if(mHeight != value) {
                    dH = value - mHeight;
                    mHeight = value;
                    SetupSegments();
                }
            }
        }

        public new int Thickness {
            get => mThickness;
            set {
                if(mThickness != value) {
                    dT = value - mThickness;
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

        public Rectangle Bounds {
            get {
                Rectangle r = new Rectangle(int.MaxValue, int.MaxValue, 0, 0);
                NSegments.ForEach((sc) => {
                    Rectangle b = sc.Bounds;
                    if(b.X < r.X) r.X = b.X;
                    if(b.Y < r.Y) r.Y = b.Y;
                    if(b.Right > r.Right) r.Width = b.Right - mX;
                    if(b.Bottom > r.Bottom) r.Height = b.Bottom - mY;
                });
                return r;
            }
        }

        public string Text {
            get {
                return "";
            }
            set {
                for(int i = NSegments.Count - 1; i >= 0; i--) {
                    char c = i < value.Length ? value[i] : ' ';
                    if(char.IsDigit(c)) {
                        NSegments[i].Value = (int)c - (int)'0';
                    } else if(c==' ') {
                        NSegments[i].Value = NSegments[i].Encodings.Count - 1;
                    } else if(char.IsLetter(c)) {
                        NSegments[i].Value = (int)(c.ToString().ToUpper()[0]) - (int)'A' + 10;
                    }
                }
            }
        }

        private void SetupSegments() {
            NSegments.ForEach((NSegments ss) => {
                ss.X += dX;
                ss.Y += dY;
                ss.Width += dW;
                ss.Height += dH;
                ss.Thickness += dT;
                ss.ForeColorOff = mForeColorOff;
                ss.ForeColorOn = mForeColorOn;
                ss.BackColor = mBackColor;
            });

            dX = 0;
            dY = 0;
            dW = 0;
            dH = 0;
            dT = 0;
        }

        public void Render(Graphics g) {
            using(SolidBrush b = new SolidBrush(mBackColor)) {
                g.FillRectangle(b, this.Bounds);
            }

            NSegments.ForEach((sc) => sc.Render(g));
        }

        public NSegments this[int index] {
            get => NSegments[index];
            set => NSegments[index] = value;
        }

        public int Count => NSegments.Count;

        public bool IsReadOnly => false;

        public void Add(NSegments item) {
            NSegments.Add(item);
        }

        public void AddWithStyle(NSegments item) {
            item.X = mX;
            item.Y = mY;
            item.Width = mWidth;
            item.Thickness = mThickness;
            item.ForeColorOff = mForeColorOff;
            item.ForeColorOn = mForeColorOn;
            item.BackColor = mBackColor;
            NSegments.Add(item);
        }

        public void Clear() {
            NSegments.Clear();
        }

        public bool Contains(NSegments item) {
            return NSegments.Contains(item);
        }

        public void CopyTo(NSegments[] array, int arrayIndex) {
            NSegments.CopyTo(array, arrayIndex);
        }

        public IEnumerator<NSegments> GetEnumerator() {
            return NSegments.GetEnumerator();
        }

        public int IndexOf(NSegments item) {
            return NSegments.IndexOf(item);
        }

        public void Insert(int index, NSegments item) {
            NSegments.Insert(index, item);
        }

        public bool Remove(NSegments item) {
            return NSegments.Remove(item);
        }

        public void RemoveAt(int index) {
            NSegments.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return NSegments.GetEnumerator();
        }

        public static explicit operator List<NSegments>(NSegmentsCollection ssc) {
            return ssc.NSegments;
        }
    }
}