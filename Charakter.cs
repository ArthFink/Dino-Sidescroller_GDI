using System;
using System.Drawing;


namespace Dino_Sidescroller
{
    public class Charakter
    {

        SizeF cSize;
        private Rectangle rect;
        private bool keyReleased;
        private int baseHight;
        private bool keyPresedUp;
        private int jumphight;
        private int possition_y;
        private PointF charPossition;


        public Charakter(SizeF clinetSize)
        {
            cSize = clinetSize;
            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 10;
            // rect = new Rectangle(15, baseHight, 20, 20);

            CharPossition = new PointF(30, baseHight-38);

            jumphight = 19;
            gravati = 0;
        }

        #region Proprieties

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }


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

        public PointF CharPossition
        {
            get { return charPossition; }
            set { charPossition = value; }
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


        public void CharakterJumpFall()
        {

            if (keyPresedUp && jumphight > 0)
            {
                gravati++;
                jumphight--;

                charPossition.Y -= (float)(jumphight - gravati);
            }
            else if (keyPresedUp && gravati > 0)
            {
                gravati--;
                jumphight++;

                charPossition.Y += (float)(gravati - jumphight);
            }
            if (CharPossition.Y > baseHight-38)
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



    }


}