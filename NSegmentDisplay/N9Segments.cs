// https://en.wikipedia.org/wiki/Nine-segment_display

//          A
//          −
//    F | H / | B
//        G −
//    E | I / | C
//          −
//          D

namespace NSegmentDisplay {
    public class N9Segments : N7Segments {
        public N9Segments() : base() {
            segments = new Segment[9];
            for(int i = 0; i < segments.Length; i++) {
                segments[i] = new Segment();
            }

            Encodings.Clear(); //            IHGFEDCBA
            Encodings.AddRange(new int[] { 0b000111111,    // 0
                                           0b010000110,    // 1
                                           0b100001011,    // 2
                                           0b111000001,    // 3
                                           0b001100110,    // 4
                                           0b001101101,    // 5
                                           0b011011100,    // 6
                                           0b010010001,    // 7
                                           0b001111111,    // 8
                                           0b101100011,    // 9
                                           0b001110111,    // A
                                           0b001111100,    // B
                                           0b000111001,    // C
                                           0b001011110,    // D
                                           0b001111001,    // E
                                           0b001110001,    // F
                                           0b000000000
            });

            SetupSegments();
        }

        public override void SetupSegments() {
            base.SetupSegments();

            if(segments.Length == 9) {
                // H
                segments[7].Orientation = Segment.Orientations.Diagonal;
                segments[7].X = segments[6].X;
                segments[7].Y = segments[6].Y;
                segments[7].X = segments[5].X + mThickness / 2;
                segments[7].Y = segments[6].Y + mThickness / 2;
                segments[7].TrgX = segments[1].X + mThickness / 2;
                segments[7].TrgY = segments[0].Y + mThickness / 2;

                // I
                segments[8].Orientation = Segment.Orientations.Diagonal;
                segments[8].X = segments[3].X;
                segments[8].Y = segments[3].Y;
                segments[8].X = segments[4].X + mThickness / 2;
                segments[8].Y = segments[3].Y + mThickness / 2;
                segments[8].TrgX = segments[2].X + mThickness / 2;
                segments[8].TrgY = segments[6].Y + mThickness / 2;
            }
        }
    }
}
