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
                //// H
                base.segments[8].Orientation = Segment.Orientations.Diagonal;
                base.segments[8].X = segments[6].X;
                base.segments[8].Y = segments[6].Y;
                base.segments[8].SrcX = base.segments[6].X + Width / 2 - Thickness / 2;
                base.segments[8].SrcY = segments[6].Y - Thickness / 2;
                base.segments[8].TrgX = base.segments[0].X + Width;
                base.segments[8].TrgY = segments[0].Y;

                //// I
                base.segments[9].Orientation = Segment.Orientations.Diagonal;
                base.segments[9].X = segments[3].X;
                base.segments[9].Y = segments[3].Y;
                base.segments[9].SrcX = base.segments[6].X + Width / 2 + Thickness;
                base.segments[9].SrcY = segments[6].Y + Thickness;
                base.segments[9].TrgX = base.segments[3].X;
                base.segments[9].TrgY = segments[3].Y + Thickness;

                //// J
                base.segments[10].Orientation = Segment.Orientations.Diagonal;
                base.segments[10].X = segments[6].X;
                base.segments[10].Y = segments[6].Y;
                base.segments[10].SrcX = base.segments[6].X + Width / 2 - Thickness / 2;
                base.segments[10].SrcY = segments[6].Y;
                base.segments[10].TrgX = base.segments[0].X - Thickness;
                base.segments[10].TrgY = segments[0].Y + Thickness / 2;

                // K
                base.segments[11].Orientation = Segment.Orientations.Diagonal;
                base.segments[11].X = segments[6].X;
                base.segments[11].Y = segments[6].Y;
                base.segments[11].SrcX = base.segments[6].X + Width / 2 + Thickness;
                base.segments[11].SrcY = segments[6].Y - Thickness;
                base.segments[11].TrgX = base.segments[2].X - Thickness;
                base.segments[11].TrgY = segments[3].Y + Thickness / 2;
                return;

                // L
                base.segments[12].Orientation = Segment.Orientations.Vertical;
                base.segments[12].X = segments[0].X + segments[6].Width / 2 - Thickness / 2;
                base.segments[12].Y = segments[0].Y;

                // M
                base.segments[13].Orientation = Segment.Orientations.Vertical;
                base.segments[13].X = segments[0].X + segments[6].Width / 2 - Thickness / 2;
                base.segments[13].Y = segments[6].Y + 2 * Thickness;

                // G
                base.segments[6].Orientation = Segment.Orientations.Horizontal;
                segments[6].X = mX + mThickness + mPadding;
                segments[6].Y = mY + mThickness + mHeight + mPadding + mPadding / 2;
                segments[6].Width = segments[6].Width / 2 - Padding;

                // I
                base.segments[7].Orientation = Segment.Orientations.Horizontal;
                segments[7].X = mX + segments[6].Width + mThickness + mPadding * 2;
                segments[7].Y = mY + mThickness + mHeight + mPadding + mPadding / 2;
                segments[7].Width = segments[6].Width;
            }
        }
    }
}