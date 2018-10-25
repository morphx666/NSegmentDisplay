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

        public void Render(Graphics g, int padding) {
            using(SolidBrush bf = new SolidBrush(State ? ForeColorOn : ForeColorOff)) {
                switch(Orientation) {
                    case Orientations.Horizontal:
                        g.FillRectangle(bf, X, Y, Width, Thickness);
                        break;
                    case Orientations.Vertical:
                        g.FillRectangle(bf, X, Y, Thickness, Height);
                        break;
                    case Orientations.Diagonal:
                        using(Pen p = new Pen(State ? ForeColorOn : ForeColorOff, Thickness)) {
                            g.DrawLine(p, X, Y, TrgX, TrgY);
                        }
                        break;
                }
            }
        }
    }
}