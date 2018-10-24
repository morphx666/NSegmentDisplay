using System.Collections.Generic;
using System.Drawing;

namespace NSegmentDisplay {
    public interface INSegments {
        Rectangle Bounds { get; }
        int Value { get; set; }
        List<int> Encodings { get; }

        void SetupSegments();
        void Render(Graphics g);
    }
}
