using System;

namespace NSegmentDisplay {
    public class N14Segments : N7Segments {
        public N14Segments() : base() {
            segments = new Segment[14];
            for(int i = 0; i < segments.Length; i++) {
                segments[i] = new Segment();
            }

            //base.Encodings.Clear();
            //base.Encodings.AddRange(new int[] { 0b000111111,    // 0
            //                                    0b010000110,    // 1
            //                                    0b100001011,    // 2
            //                                    0b111000001,    // 3
            //                                    0b001100110,    // 4
            //                                    0b001101101,    // 5
            //                                    0b011011100,    // 6
            //                                    0b010010001,    // 7
            //                                    0b001111111,    // 8
            //                                    0b101100011,    // 9
            //                                    0b001110111,    // A
            //                                    0b001111100,    // B
            //                                    0b000111001,    // C
            //                                    0b001011110,    // D
            //                                    0b001111001,    // E
            //                                    0b001110001,    // F
            //});

            SetupSegments();
        }

        public override void SetupSegments() {
            base.SetupSegments();

            if(segments.Length == 14) {
                // TODO: Need to implement and EndPoint so that we can render both DiagonalLeft
                //          and DiagonalRight segments, without the Segment.Render "guessing"
                //          where the start and end points are located.
                throw new NotImplementedException();
            }
        }
    }
}