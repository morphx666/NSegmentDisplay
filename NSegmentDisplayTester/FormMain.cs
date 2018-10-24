using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

// https://en.wikipedia.org/wiki/Seven-segment_display

namespace NSegmentDisplay {
    public partial class FormMain : Form {
        private NSegmentsCollection ssc = new NSegmentsCollection() {
            X = 20,
            Y = 20,
            Width = 36,
            Thickness = 8,
            ForeColorOff = Color.FromArgb(202, 202, 202),
            ForeColorOn = Color.FromArgb(31, 31, 31),
            BackColor = Color.FromArgb(211, 211, 211)
        };
        private Type[] supportedDisplays = { typeof(N7Segments), typeof(N9Segments) };
        private int supportedDisplayIndex = 0;
        private int padding = 4;

        public FormMain() {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.BackColor = Color.FromArgb(211, 211, 211);
        }

        private void FormMain_Load(object sender, EventArgs e) {
            CreateDisplay();
            LabelHelp1.ForeColor = ssc.ForeColorOn;
            LabelHelp2.ForeColor = ssc.ForeColorOn;

            Task.Run(() => {
                while(true) {
                    lock(ssc) {
                        ValueTo7Segments(To12(DateTime.Now.Hour), 0, 2);
                        ValueTo7Segments(DateTime.Now.Minute, 2, 2);
                        ValueTo7Segments(DateTime.Now.Second, 4, 2);
                        ValueTo7Segments(DateTime.Now.Millisecond, 6, 3);
                        ssc[ssc.Count - 1].Value = DateTime.Now.Hour < 12 ? 0xA : ssc[ssc.Count - 1].Encodings.Count - 1;
                    }
                    this.Invalidate();
                    System.Threading.Thread.Sleep(10);
                }
            });

            this.Resize += (object o1, EventArgs e1) => CenterDisplay();

            this.KeyDown += (object o1, KeyEventArgs e1) => {
                lock(ssc) {
                    switch(e1.KeyCode) {
                        case Keys.Left:
                            supportedDisplayIndex = Math.Abs(supportedDisplayIndex - 1) % supportedDisplays.Length;
                            CreateDisplay();
                            break;
                        case Keys.Right:
                            supportedDisplayIndex = (supportedDisplayIndex + 1) % supportedDisplays.Length;
                            CreateDisplay();
                            break;
                        case Keys.W:
                            ssc.Width += ((e1.Modifiers & Keys.Shift) == Keys.Shift ? -1 : 1);
                            ssc.Width = Math.Max(1, ssc.Width);
                            CreateDisplay();
                            break;
                        case Keys.H:
                            ssc.Height += ((e1.Modifiers & Keys.Shift) == Keys.Shift ? -1 : 1);
                            ssc.Height = Math.Max(1, ssc.Height);
                            CreateDisplay();
                            break;
                        case Keys.T:
                            ssc.Thickness += ((e1.Modifiers & Keys.Shift) == Keys.Shift ? -1 : 1);
                            ssc.Thickness = Math.Max(1, ssc.Thickness);
                            CreateDisplay();
                            break;
                        case Keys.P:
                            padding += ((e1.Modifiers & Keys.Shift) == Keys.Shift ? -1 : 1);
                            padding = Math.Max(0, padding);
                            CreateDisplay();
                            break;
                    }
                }
            };
        }

        private void CenterDisplay() {
            Rectangle a = this.DisplayRectangle;
            Rectangle b = ssc.Bounds;
            ssc.X = (a.Width - b.Width) / 2;
            ssc.Y = (a.Height - b.Height) / 2;
        }

        private void CreateDisplay() {
            ssc.Clear();
            for(int i = 0; i < 10; i++) {
                NSegments display = (NSegments)Activator.CreateInstance(supportedDisplays[supportedDisplayIndex]);

                display.Width = (i >= 6 ? ssc.Width / 2 : ssc.Width);
                display.Height = (i >= 6 ? ssc.Height / 2 : ssc.Height);
                display.Thickness = (i >= 6 ? (int)Math.Ceiling(ssc.Thickness / 1.5) : ssc.Thickness);
                display.Padding = padding;

                display.X = ssc.X +
                                 i * (display.Bounds.Width + 2) +
                                (i >= 2 ? ssc.Width : 0) +
                                (i >= 4 ? ssc.Width : 0) +
                                (i >= 6 ? ssc.Width * 4 : 0) +
                                (i >= 9 ? ssc.Width : 0);
                display.Y = (i >= 6 ? ssc.Y + ssc.Height + ssc.Thickness / 2 : ssc.Y);
                display.ForeColorOff = ssc.ForeColorOff;
                display.ForeColorOn = ssc.ForeColorOn;
                display.BackColor = ssc.BackColor;

                ssc.Add(display);
            }
            ssc[ssc.Count - 1].Encodings.Add(0b1110011); // P

            CenterDisplay();
        }

        private int To12(int h) {
            if(h > 12) {
                h -= 12;
            } else if(h == 0) {
                h = 12;
            }
            return h;
        }

        private void ValueTo7Segments(int value, int index, int length) {
            string v = value.ToString(new string('0', length));
            for(int i = 0; i < length; i++) {
                ssc[index + i].Value = int.Parse(v[i].ToString());
            }
        }

        private void FormMain_Paint(object sender, PaintEventArgs e) {
            lock(ssc) {
                ssc.Render(e.Graphics);
            }
        }
    }
}
