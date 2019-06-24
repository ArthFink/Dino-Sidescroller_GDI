using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace Dino_Sidescroller
{
    public class Charakter
    {

        SizeF cSize;
        private Rectangle rect;


        public Charakter(SizeF clinetSize)
        {
            cSize = clinetSize;
            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 10;
            rect = new Rectangle(15, baseHight, 10, 10);
        }

        #region Propaties

        private int baseHight;

        public int BaseHight
        {
            get { return baseHight;; }
            set { baseHight = value; }
        }


        private bool keyPresedUp;

        public bool KeyPresedUp
        {
            get { return keyPresedUp; }
            set { keyPresedUp = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        private int possition_x;

        public int Possition_x
        {
            get { return Possition_x; }
            set { Possition_x = value; }
        }


        private int possition_y;

        public int Possition_y
        {
            get { return possition_y; }
            set { possition_y = value; }
        }
        /// <summary>
        /// Gravitational Force on The Character
        /// </summary>
        private float gravati;

        public float Gravati
        {
            get { return gravati; }
            set { gravati = value; }
        }
        #endregion

        //Wenn the user is Pressing a Key the Charakter Jumps Up
        public void Jump()
        {

            if (keyPresedUp)
            {
                rect.Y += -30;
            }
            CharakterReset();
        }

        //After Jump() the Cahrakter has to fall back to the base Line
        public void Fall()
        {
            if (rect.Y < baseHight)
            {
                rect.Y += 5;
            }
            CharakterReset();
        }

        public void CharakterReset()
        {
            if (rect.Y > baseHight)
            {
                rect.Y = baseHight;
            }

        }
    }
}