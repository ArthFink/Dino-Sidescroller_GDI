using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public partial class Main_Form : Form
    {
        Timer timer, dinoTimer;
        Graphics_Paint graphics_Paint;
        Game_Logic game_Logic;
        private int frameCount;
        private Font font;


        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;

            game_Logic = new Game_Logic(ClientSize);
            graphics_Paint = new Graphics_Paint(game_Logic);

            timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 17;
            timer.Start();
            frameCount = 1;

            /* dinoTimer = new Timer();
             timer.Tick += new EventHandler(DinoTimerEventProcessor);
             timer.Interval = 40;
             timer.Start();*/

            KeyUp += Key_Up;

            //KeyDown += new KeyEventHandler(Key_Press);

            font = new Font("Symbol", 18, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Has always to be the first line of the overridden OnPaint-Method.
            base.OnPaint(e);

            // Get the graphics object.        
            Graphics graphics = e.Graphics;

            //Score
            graphics.DrawString((frameCount / 10).ToString(), font, Brushes.Black, (ClientSize.Width / 10) * 9, 10);

            //graphics_Paint.Paint_Obstacles(graphics, ClientSize, frameCount);
            // graphics_Paint.CactiAnimation(graphics, ClientSize);
            graphics_Paint.BaseLine(graphics, ClientSize);

            graphics_Paint.DinoAnimation(graphics, ClientSize);

            graphics_Paint.Paint_Character(graphics, ClientSize);
            //graphics_Paint.Paint_Environment(graphics, ClientSize);

        }


        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            //the timer starts and increments the counter.
            frameCount += 1;

            game_Logic.Rectangles.FrameCount = frameCount;

            game_Logic.Update();

            if(game_Logic.Charakter.MaxHeightReached())
            {
                game_Logic.Charakter.Space = false;
                game_Logic.Charakter.Jump = true;
            }


            Invalidate();

        }


        /*  private void DinoTimerEventProcessor(Object myObject, EventArgs myEventArgs)
          {
              game_Logic.Update();

              Invalidate();
          }*/



        /// <summary>
        ///Detects If key is Preset
        /// </summary>
        /*private void Key_Press(object sender, KeyEventArgs e)
        {
            if (game_Logic.Charakter.Rect.Y == game_Logic.Charakter.BaseHight)
            {

                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
                {
                    game_Logic.Charakter.KeyPresedUp = true;
                }
            }


        }*/

        private void Key_Up(object sender, KeyEventArgs e)
        {
            #region rt
            /* if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
             {
                 game_Logic.Charakter.KeyPresedUp = false;
             }*/
            #endregion
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                game_Logic.Charakter.Space = false;
                game_Logic.Charakter.Jump = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                // characterSize = new Size(characterHeight, characterHeight);

                game_Logic.Charakter.JumpVelocitiy = 5;

            }

        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                //characterSize = new Size(characterHeight, characterHeight / 2);

                game_Logic.Charakter.JumpVelocitiy = 8;
            }

            if ((e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && !game_Logic.Charakter.Jump && game_Logic.Charakter.Rect.Height > 15)
                game_Logic.Charakter.Space = true;
        }

        public int FrameCount
        {
            get { return frameCount; }
            set { frameCount = value; }
        }


    }
}
