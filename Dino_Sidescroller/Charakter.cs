using System;
using System.Drawing;


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
            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 48;

            rect = new Rectangle(25, baseHight, 20, 40);

            jumphight = 10;
            gravati = 0;
        }



        public void CharakterJumpFall()
        {

            if (keyPresedUp && jumphight > 0)
            {
                gravati++;
                jumphight--;

                rect.Y -= (int)(jumphight - 0.5*gravati);
            }
            else if (keyPresedUp && gravati > 0)
            {
                gravati--;
                jumphight++;

                rect.Y += (int)(0.5*gravati - jumphight);
            }
            if (rect.Y > baseHight)
            {
                gravati = 0;
                jumphight = 19;
                keyPresedUp = false;
                CharakterReset();

            }


        }

        //If Character Falls below the base line the character is reset
        public void CharakterReset()
        {
            if (rect.Y > baseHight)
            {
                rect.Y = baseHight;
            }

        }

        #region Proprieties




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


    }


}