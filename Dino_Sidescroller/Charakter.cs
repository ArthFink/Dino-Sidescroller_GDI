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

        const int maxJumpHight = 200;

        SizeF cSize;
        private Rectangle rect;
        private bool keyReleased;
        private int baseHight;
        private bool keyPresedUp;
        private int jumphight;
        private int possition_y;

        public Charakter(SizeF clinetSize)
        {
            cSize = clinetSize;
            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 10;
            rect = new Rectangle(15, baseHight, 10, 10);


            jumphight = 19;
            gravati = 0;
        }

        #region Propaties

        public bool KeyReleased
        {
            get { return keyReleased; }
            set { keyReleased = value; }
        }

        public int BaseHight
        {
            get { return baseHight; ; }
            set { baseHight = value; }
        }

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

        public int Possition_x
        {
            get { return Possition_x; }
            set { Possition_x = value; }
        }


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


        public void JumpFall()
        {

            if (keyPresedUp && jumphight > 0)
            {
                gravati++;
                jumphight--;

                rect.Y -= (int)(jumphight - gravati);
            }
            else if (keyPresedUp && gravati > 0)
            {
                gravati--;
                jumphight++;

                rect.Y += (int)(gravati - jumphight);
            }
            if (rect.Y > baseHight)
            {
                gravati = 0;
                jumphight = 19;
                keyPresedUp = false;
                CharakterReset();

            }


        }

        //If Charakert Falls below the base line the charakter is resettet
        public void CharakterReset()
        {
            if (rect.Y > baseHight)
            {
                rect.Y = baseHight;
            }

        }


    }


}