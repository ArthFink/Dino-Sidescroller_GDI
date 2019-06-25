using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;

            game_Logic = new Game_Logic(ClientSize);
            graphics_Paint = new Graphics_Paint(game_Logic);

            timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 30;
            timer.Start();
            KeyUp += key_Up;

            KeyDown += new KeyEventHandler(Key_Press);

            frameCount = 1;

            //font = new Font("Wingdings", 20, FontStyle.Bold);
            font = new Font("Symbol", 20, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Has always to be the first line of the overriden OnPaint-Method.
            base.OnPaint(e);
            // Get the graphics object.        
            Graphics graphics = e.Graphics;


            graphics_Paint.Paint_Environment(graphics, ClientSize);

            graphics_Paint.Paint_Character(graphics, ClientSize);

            graphics_Paint.Paint_Obstacles(graphics, ClientSize, frameCount);

            graphics.DrawString((frameCount / 10).ToString(), font, Brushes.Black, (ClientSize.Width / 10) * 9, 10);
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            //the timer starts and increments the counter.
            frameCount += 1;

            game_Logic.Update();


            Invalidate();

        }

        /// <summary>
        ///Detects If key is Presst
        /// </summary>
        private void Key_Press(object sender, KeyEventArgs e)
        {
            if (game_Logic.Charakter.Rect.Y == game_Logic.Charakter.BaseHight)
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
                {
                    game_Logic.Charakter.KeyPresedUp = true;
                }
            }

            if (e.KeyCode == Keys.Down)
            {

            }

        }

        private void key_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
            {
                game_Logic.Charakter.KeyReleased = false;
            }
        }



        public int FrameCount
        {
            get { return frameCount; }
            set { frameCount = value; }
        }

    }
}
