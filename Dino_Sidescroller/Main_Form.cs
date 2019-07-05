using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public partial class Main_Form : Form
    {
        Timer timer;
        Graphics_Paint graphics_Paint;
        Game_Logic game_Logic;
        private int frameCount;
        private Font font;
        int score, clicked;

        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;


            game_Logic = new Game_Logic(ClientSize);
            graphics_Paint = new Graphics_Paint(game_Logic);

            timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 17;
            timer.Start();
            frameCount = 500;
            score = frameCount;

            clicked = 0;

            KeyUp += Key_Up;

            font = new Font("Symbol", 18, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Has always to be the first line of the overridden OnPaint-Method.
            base.OnPaint(e);

            // Get the graphics object.        
            Graphics graphics = e.Graphics;


            graphics_Paint.BaseLine(graphics, ClientSize, !game_Logic.Collision);

            if (game_Logic.Collision)
            {

                graphics_Paint.GameOver(graphics, ClientSize);
                //Score
                graphics.DrawString((score / 10 - 50).ToString(), font, Brushes.Black, (ClientSize.Width / 10) * 9, 10);
            }
            else
            {
                graphics.DrawString((score / 10 - 50).ToString(), font, Brushes.Black, (ClientSize.Width / 10) * 9, 10);
                graphics_Paint.Paint_HitBox(graphics, ClientSize, frameCount);
                graphics_Paint.CactiAnimation(graphics, ClientSize);
                graphics_Paint.DinoAnimation(graphics, ClientSize, frameCount);
                graphics_Paint.Paint_Environment(graphics, ClientSize, frameCount);
            }



        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            //FrameCount stops Counting if Collied
            if (!game_Logic.Collision)
            {
                //the timer starts and increments the counter.
                frameCount += 1;
            }
            score = frameCount;



            game_Logic.Rectangles.FrameCount = frameCount;

            game_Logic.Update();

            if (game_Logic.Charakter.MaxHeightReached())
            {
                game_Logic.Charakter.Space = false;
                game_Logic.Charakter.Jump = true;
            }


            Invalidate();

        }

        private void Key_Up(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                game_Logic.Charakter.Space = false;
                game_Logic.Charakter.Jump = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                game_Logic.Charakter.JumpVelocitiy = 5;

            }

        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                game_Logic.Charakter.JumpVelocitiy = 8;
            }

            if ((e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && !game_Logic.Charakter.Jump && game_Logic.Charakter.Rect.Height > 15)
                game_Logic.Charakter.Space = true;

            if (e.KeyCode == Keys.Space && game_Logic.Collision)
            {
                //restart
                Visible = false;
                new Main_Form().ShowDialog();
                this.Close();

            }
            if (e.KeyCode == Keys.Up && game_Logic.Collision)
            {
                //restart
                Visible = false;
                new Main_Form().ShowDialog();
                this.Close();

            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.B)
            {
                clicked += 1;

                if (clicked % 2 != 0)
                {
                    graphics_Paint.HitBoxShow = true;
                }
                else
                    graphics_Paint.HitBoxShow = false;

            }
        }
        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            bool b = false;

            b = graphics_Paint.GameOverHitbox.Contains(x, y);

            if (b)
            {
                this.Visible = false;
                new Main_Form().ShowDialog();
                this.Close();

            }

        }

        public int FrameCount
        {
            get { return frameCount; }
            set { frameCount = value; }
        }




    }
}
