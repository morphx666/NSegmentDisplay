using System;
using System.Drawing;

// Container for a set of seven segments

namespace NSegmentDisplay {
    public class N7Segments : NSegments {
        public N7Segments() {
            segments = new Segment[7];
            for(int i = 0; i < segments.Length; i++) {
                segments[i] = new Segment();
            }

            mWidth = base.Width;
            mHeight = base.Height;
            mThickness = base.Thickness;
            mForeColorOff = base.ForeColorOff;
            mForeColorOn = base.ForeColorOn;

            base.Encodings.AddRange(new int[] { 0x3F, 0x06, 0x5B, 0x4F, 0x66, 0x6D, 0x7D, 0x07, 0x7F, 0x6F, 0x77, 0x7C, 0x39, 0x5E, 0x79, 0x71 });

            SetupSegments();
        }

        public override void SetupSegments() {
            for(int i = 0; i < segments.Length; i++) {
                segments[i].Width = mWidth;
                segments[i].Height = mHeight;
                segments[i].Thickness = mThickness;
                segments[i].ForeColorOff = mForeColorOff;
                segments[i].ForeColorOn = mForeColorOn;
                segments[i].BackColor = mBackColor;
            };

            mWidth += mPadding;
            mThickness += mPadding;

            // A
            segments[0].X = mX + mThickness;
            segments[0].Y = mY;

            // B
            segments[1].Orientation = Segment.Orientations.Vertical;
            segments[1].X = mX + mThickness + mWidth;
            segments[1].Y = mY + mThickness;

            // C
            segments[2].Orientation = Segment.Orientations.Vertical;
            segments[2].X = mX + mThickness + mWidth;
            segments[2].Y = mY + mThickness * 2 + mHeight;

            // D
            segments[3].X = mX + mThickness;
            segments[3].Y = mY + mThickness * 2 + mHeight * 2;

            // E
            segments[4].Orientation = Segment.Orientations.Vertical;
            segments[4].X = mX;
            segments[4].Y = mY + mThickness * 2 + mHeight;

            // F
            segments[5].Orientation = Segment.Orientations.Vertical;
            segments[5].X = mX;
            segments[5].Y = mY + mThickness;

            // G
            segments[6].X = mX + mThickness;
            segments[6].Y = mY + mThickness + mHeight;

            mWidth -= mPadding;
            mThickness -= mPadding;
        }

        public override void Render(Graphics g) {
            using(SolidBrush b = new SolidBrush(mBackColor)) {
                g.FillRectangle(b, this.Bounds);
            }

            int encoding = Encodings[Value];
            for(int i = segments.Length - 1; i >= 0; i--) {
                //int x = segments[i].X;
                //int y = segments[i].Y;
                //if(segments[i].Orientation == Segment.Orientations.Vertical) {
                //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //    g.TranslateTransform(this.Bounds.X, this.Bounds.Bottom);
                //    g.RotateTransform(5);
                //    g.TranslateTransform(-this.Bounds.X, -this.Bounds.Bottom);
                //} else {
                //    segments[i].X += (this.Bounds.Bottom - y) / 10;
                //    segments[i].Y += (this.Bounds.Bottom - y) / 20;
                //}

                segments[i].State = (encoding & (int)Math.Pow(2, i)) != 0;
                segments[i].Render(g);
                //encoding = encoding >> 1;

                //if(segments[i].Orientation == Segment.Orientations.Vertical) {
                //    g.ResetTransform();
                //} else {
                //    segments[i].X = x;
                //    segments[i].Y = y;
                //}
            }
        }
    }
}
