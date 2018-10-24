using System;
using System.Drawing;

// Single segment

namespace NSegmentDisplay {
    public class Segment : SegmentProperties {
        public enum Orientations {
            Horizontal,
            Vertical,
            DiagonalLeft,
            DiagonalRight
        }

        public Orientations Orientation { get; set; }
        public bool State { get; set; }

        public Segment() {
            Orientation = Orientations.Horizontal;
            State = false;
        }

        public void Render(Graphics g) {
            using(SolidBrush bb = new SolidBrush(BackColor)) {
                using(SolidBrush bf = new SolidBrush(State ? ForeColorOn : ForeColorOff)) {
                    switch(Orientation) {
                        case Orientations.Horizontal:
                            g.FillRectangle(bb, X - Thickness, Y, Width + 2*Thickness, Thickness);
                            g.FillRectangle(bf, X, Y, Width, Thickness);
                            break;
                        case Orientations.Vertical:
                            g.FillRectangle(bb, X, Y - Thickness, Thickness, Height + 2*Thickness);
                            g.FillRectangle(bf, X, Y, Thickness, Height);
                            break;
                        case Orientations.DiagonalRight:
                            PointF p1 = new Point(X - Thickness / 2, Y - Thickness / 2);
                            PointF p2 = new Point(X + Width, Y - Height - Thickness - Thickness / 2);
                            double dx = p2.X - p1.X;
                            double dy = p2.Y - p1.Y;
                            double a = Math.Atan2(dy, dx);
                            double h = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                            //p2.X = (float)(p1.X + h * Math.Cos(a));
                            //p2.Y = (float)(p1.Y - h * Math.Sin(a));


                            g.TranslateTransform(X, Y);
                            g.RotateTransform((float)(a * 180 / Math.PI));
                            g.TranslateTransform(-X, -Y);
                            g.FillRectangle(bf, p1.X, p1.Y, (int)h, Thickness);
                            g.ResetTransform();
                            break;
                    }
                }
            }
        }
    }
}