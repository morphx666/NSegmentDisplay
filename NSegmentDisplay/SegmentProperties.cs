using System.Drawing;

// Common segments' properties

namespace NSegmentDisplay {
    public abstract class SegmentProperties {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Thickness { get; set; }
        public Color ForeColorOff { get; set; }
        public Color ForeColorOn { get; set; }
        public Color BackColor { get; set; }

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
