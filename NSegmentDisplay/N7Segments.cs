using System;
using System.Drawing;

// Container for a set of seven segments

//        A
//        −
//    F | G | B
//        −
//    E |   | C
//        −
//        D

namespace NSegmentDisplay {
    public class N7Segments : NSegments {
        public N7Segments() {
            segments = new Segment[7];
            for(int i = 0; i < segments.Length; i++) {
                segments[i] = new Segment();
            }

            mWidth = base.Width;
            mHeight = base.Height;
            mThickness = base.Thickness;
            mForeColorOff = base.ForeColorOff;
            mForeColorOn = base.ForeColorOn;

            //                                    GFEDCBA 
            base.Encodings.AddRange(new int[] { 0b0111111,    // 0
                                                0b0000110,    // 1
                                                0b1011011,    // 2
                                                0b1001111,    // 3
                                                0b1100110,    // 4
                                                0b1101101,    // 5
                                                0b1111101,    // 6
                                                0b0000111,    // 7
                                                0b1111111,    // 8
                                                0b1101111,    // 9
                                                0b1110111,    // A
                                                0b1111100,    // B
                                                0b0111001,    // C
                                                0b1011110,    // D
                                                0b1111001,    // E
                                                0b1110001,    // F
                                                0b0000000
            });

            SetupSegments();
        }

        public override void SetupSegments() {
            for(int i = 0; i < segments.Length; i++) {
                segments[i].Width = mWidth;
                segments[i].Height = mHeight;
                segments[i].Thickness = mThickness;
                segments[i].ForeColorOff = mForeColorOff;
                segments[i].ForeColorOn = mForeColorOn;
                segments[i].BackColor = mBackColor;
            };

            // A
            segments[0].X = mX + mThickness + mPadding;
            segments[0].Y = mY;

            // B
            segments[1].Orientation = Segment.Orientations.Vertical;
            segments[1].X = mX + mThickness + mWidth + mPadding * 2;
            segments[1].Y = mY + mThickness + mPadding;

            // C
            segments[2].Orientation = Segment.Orientations.Vertical;
            segments[2].X = mX + mThickness + mWidth + mPadding * 2;
            segments[2].Y = mY + mThickness * 2 + mHeight + mPadding * 2;

            // D
            segments[3].X = mX + mThickness + mPadding;
            segments[3].Y = mY + mThickness * 2 + mPadding * 3 + mHeight * 2;

            // E
            segments[4].Orientation = Segment.Orientations.Vertical;
            segments[4].X = mX;
            segments[4].Y = mY + mThickness * 2 + mPadding * 2 + mHeight;

            // F
            segments[5].Orientation = Segment.Orientations.Vertical;
            segments[5].X = mX;
            segments[5].Y = mY + mThickness + mPadding;

            // G
            segments[6].X = mX + mThickness + mPadding;
            segments[6].Y = mY + mThickness + mHeight + mPadding + mPadding / 2;
        }
    }
}
