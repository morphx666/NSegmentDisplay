using System;
using System.Drawing;

// Single segment

namespace NSegmentDisplay {
    public class Segment : SegmentProperties {
        private const double ToDeg = 180 / Math.PI;

        public enum Orientations {
            Horizontal,
            Vertical,
            Diagonal
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
                            g.FillRectangle(bb, X - Thickness, Y, Width + 2 * Thickness, Thickness);
                            g.FillRectangle(bf, X, Y, Width, Thickness);
                            break;
                        case Orientations.Vertical:
                            g.FillRectangle(bb, X, Y - Thickness, Thickness, Height + 2 * Thickness);
                            g.FillRectangle(bf, X, Y, Thickness, Height);
                            break;
                        case Orientations.Diagonal:
                            PointF p1 = new Point(SrcX, SrcY);
                            PointF p2 = new Point(TrgX, TrgY);
                            double dx = p2.X - p1.X;
                            double dy = p2.Y - p1.Y;
                            double a = Math.Atan2(dy, dx);
                            double h = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

                            g.TranslateTransform(p1.X, p1.Y);
                            g.RotateTransform((float)(a * ToDeg));
                            g.TranslateTransform(-p1.X, -p1.Y);
                            g.FillRectangle(bf, p1.X, p1.Y, (int)h, Thickness);
                            g.ResetTransform();
                            break;
                    }
                }
            }
        }
    }
}