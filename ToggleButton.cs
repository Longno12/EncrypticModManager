using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ModManager
{
    public class ToggleButton : CheckBox
    {
        [Category("Appearance")]
        public Color OnBackColor { get; set; } = Color.FromArgb(0, 122, 204);

        [Category("Appearance")]
        public Color OffBackColor { get; set; } = Color.FromArgb(60, 60, 60);

        [Category("Appearance")]
        public Color SliderColor { get; set; } = Color.WhiteSmoke;

        private readonly Timer animationTimer;
        private int sliderX;
        private bool isAnimating;

        public ToggleButton()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.MinimumSize = new Size(45, 22);
            this.Appearance = Appearance.Button;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.CheckedBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;

            sliderX = 4;
            isAnimating = false;

            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += (sender, args) =>
            {
                int targetX = Checked ? Width - Height + 1 : 4;
                if (Math.Abs(sliderX - targetX) <= 1)
                {
                    sliderX = targetX;
                    animationTimer.Stop();
                    isAnimating = false;
                }
                else
                {
                    sliderX += (targetX > sliderX) ? 2 : -2;
                }
                this.Invalidate();
            };
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (!isAnimating)
            {
                isAnimating = true;
                animationTimer.Start();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.Parent.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int sliderSize = this.Height - 8;
            Rectangle backgroundRect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(backgroundRect.X, backgroundRect.Y, this.Height, this.Height, 90, 180);
                path.AddArc(backgroundRect.Right - this.Height, backgroundRect.Y, this.Height, this.Height, -90, 180);
                path.CloseFigure();

                e.Graphics.FillPath(new SolidBrush(this.Checked ? OnBackColor : OffBackColor), path);
            }

            if (!isAnimating)
            {
                sliderX = this.Checked ? this.Width - this.Height + 1 : 4;
            }

            Rectangle sliderRect = new Rectangle(sliderX, 4, sliderSize, sliderSize);

            using (SolidBrush sliderBrush = new SolidBrush(SliderColor))
            {
                e.Graphics.FillEllipse(sliderBrush, sliderRect);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                animationTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}