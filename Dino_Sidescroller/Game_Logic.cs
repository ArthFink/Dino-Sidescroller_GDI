using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public class Game_Logic
    {
        private Charakter charakter;
        private Rectangles rectangles;

        public Game_Logic(SizeF clinetSize)
        {
            charakter = new Charakter(clinetSize);
            //charakter.CharakterReset();
            rectangles = new Rectangles(clinetSize);
        }

        #region Properties

        private RectangleF obstacles;

        public RectangleF Obstacles
        {
            get { return obstacles; }
            set { obstacles = value; }
        }


        public Charakter Charakter
        {
            get { return charakter; }
            set { charakter = value; }
        }



        public Rectangles Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }

        #endregion

        //Score
        public int Score()
        {
            throw new System.NotImplementedException();
        }

        public void CharFall()
        {
            charakter.Fall();
        }

        public void rectangelsGenarate()
        {
            rectangles.GenerateObstacelsArry();
        }
        public void ObstacelsMove()
        {
            rectangles.MoveObstecals();
        }







    }
}