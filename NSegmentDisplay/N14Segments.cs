using System;

//          A
//          −
//          M
//    F | K\|/I | B
//        G- −H
//    E | J/|\L | C
//          N
//          −
//          D

namespace NSegmentDisplay {
    public class N14Segments : N7Segments {
        public N14Segments() : base() {
            segments = new Segment[14];
            for(int i = 0; i < segments.Length; i++) {
                segments[i] = new Segment();
            }
            Encodings.Clear(); //            NMLKJIHGFEDCBA
            Encodings.AddRange(new int[] { 0b00000000111111,    // 0
                                           0b00000100000110,    // 1
                                           0b00000011011011,    // 2
                                           0b00000010001111,    // 3
                                           0b00000011100110,    // 4
                                           0b00000011101101,    // 5
                                           0b00000011111101,    // 6
                                           0b10000100100001,    // 7
                                           0b00000011111111,    // 8
                                           0b00000011100111,    // 9
                                           0b00000011110111,    // A
                                           0b11000010001111,    // B
                                           0b00000000111001,    // C
                                           0b11000000001111,    // D
                                           0b00000011111001,    // E
                                           0b00000011110001,    // F
                                           0b00000010111101,    // G
                                           0b00000011110110,    // H
                                           0b11000000001001,    // I
                                           0b00000000011110,    // J
                                           0b00100101110000,    // K
                                           0b00000000111000,    // L
                                           0b00010100110110,    // M
                                           0b00110000110110,    // N
                                           0b00000000111111,    // O
                                           0b00000011110011,    // P
                                           0b00100000111111,    // Q
                                           0b00100011110011,    // R
                                           0b00010010001101,    // S
                                           0b11000000000001,    // T
                                           0b00000000111110,    // U
                                           0b00001100110000,    // V
                                           0b00101000110110,    // W
                                           0b00111100000000,    // X
                                           0b10010100000000,    // Y
                                           0b00001100001001,    // Z
                                           0b00000000000000
            });

            SetupSegments();
        }

        public override void SetupSegments() {
            base.SetupSegments();

            if(segments.Length == 14) {
                // I
                segments[8].Orientation = Segment.Orientations.Diagonal;
                segments[8].X = segments[1].X + mThickness / 2;
                segments[8].Y = segments[0].Y + mThickness / 2;
                segments[8].TrgX = segments[6].X + mWidth / 2;
                segments[8].TrgY = segments[6].Y + mThickness / 2;

                // J
                segments[9].Orientation = Segment.Orientations.Diagonal;
                segments[9].X = segments[4].X + mThickness / 2;
                segments[9].Y = segments[3].Y + mThickness / 2;
                segments[9].TrgX = segments[6].X + mWidth / 2;
                segments[9].TrgY = segments[6].Y + mThickness / 2;

                // K
                segments[10].Orientation = Segment.Orientations.Diagonal;
                segments[10].X = segments[5].X + mThickness / 2;
                segments[10].Y = segments[0].Y + mThickness / 2;
                segments[10].TrgX = segments[6].X + mWidth / 2;
                segments[10].TrgY = segments[6].Y + mThickness / 2;

                // L
                segments[11].Orientation = Segment.Orientations.Diagonal;
                segments[11].X = segments[2].X + mThickness / 2;
                segments[11].Y = segments[3].Y + mThickness / 2;
                segments[11].TrgX = segments[6].X + mWidth / 2;
                segments[11].TrgY = segments[6].Y + mThickness / 2;

                // H
                segments[7].Orientation = segments[6].Orientation;
                segments[7].X = segments[6].X + mWidth / 2 + mPadding;
                segments[7].Y = segments[6].Y;
                segments[7].Width = mWidth / 2 - mPadding/2;

                // G Redefinition
                segments[6].Width = mWidth / 2 - mPadding/2;

                // M
                segments[12].Orientation = Segment.Orientations.Vertical;
                segments[12].X = segments[0].X + mWidth / 2 - mThickness / 2;
                segments[12].Y = segments[5].Y;

                // N
                segments[13].Orientation = Segment.Orientations.Vertical;
                segments[13].X = segments[0].X + mWidth / 2 - mThickness / 2;
                segments[13].Y = segments[4].Y;
            }
        }
    }
}