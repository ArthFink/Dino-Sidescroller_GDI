﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public class Game_Logic
    {
        Charakter charakter;

        public Game_Logic(SizeF clinetSize)
        {

            charakter = new Charakter(clinetSize);
            //charakter.Rect.Y = 1;
        }



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


        //Score
        public int Score()
        {
            throw new System.NotImplementedException();
        }








    }
}