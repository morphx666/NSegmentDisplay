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
            switch(Orientation) {
                case Orientations.Horizontal:
                    g.DrawLine(State ? POn : POff, X, Y + Thickness / 2, X + Width, Y + Thickness / 2);
                    break;
                case Orientations.Vertical:
                    g.DrawLine(State ? POn : POff, X + Thickness / 2, Y, X + Thickness / 2, Y + Height);
                    break;
                case Orientations.Diagonal:
                    g.DrawLine(State ? POn : POff, X, Y, TrgX, TrgY);
                    break;
            }
        }
    }
}