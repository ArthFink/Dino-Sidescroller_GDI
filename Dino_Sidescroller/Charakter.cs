using System;
using System.Drawing;


namespace Dino_Sidescroller
{
    public class Charakter
    {

        const int maxjumphight = 150;
        SizeF cSize;
        Rectangle rect;
        bool jump, space;
        int baseHight;
        int jumphight;
        int jumpVelocitiy;
        int possition_y;


        public Charakter(SizeF clinetSize)
        {
            cSize = clinetSize;
            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 16;

            rect = new Rectangle(60, Function(jumphight), 30, 30);

            jump = false; space = false;

            jumphight = maxjumphight;

            jumpVelocitiy = 4;
        }



        public void CharakterJumpFall()
        {
            #region asdad
            /* //Jump
             if (keyPresedUp && jumphight > 0)
             {
                 gravati++;
                 jumphight--;

                 rect.Y -= (int)(jumphight - 0.3*gravati);
             }
             //Fall
             else if (!keyPresedUp && gravati > 0)
             {
                 gravati--;
                 jumphight++;

                 rect.Y += (int)(0.3*gravati - jumphight);
             }

             if (rect.Y >= baseHight)
             {
                 gravati = 0;
                 jumphight = 19;
                 keyPresedUp = false;
                 CharakterReset();
             }*/
            #endregion
            XCalculation();

            rect.Y = Function(jumphight);
        }


        private int Function(int x)
        {
            return (int)(baseHight - rect.Height - (Math.Pow(maxjumphight, 2) / 100) + (Math.Pow(x, 2) / 100));
        }

        //If Character Falls below the base line the character is reset
        public void CharakterReset()
        {
            if (rect.Y > baseHight)
                rect.Y = baseHight;
        }

        private void XCalculation()
        {
            //Wenn nicht gesprungen wird und das rect noch nicht den Boden erreicht hat, soll der Charakter fallen
            if (!space && jumphight < maxjumphight)
                jumphight += jumpVelocitiy;
            //Wenn gesprungen wird und die maximale Sprunghöhe noch nicht erreicht wurde
            else if (space && jumphight >= 0)
                jumphight -= jumpVelocitiy;

            //Wenn der Charakter wieder auf dem Boden gelandet ist
            else if (jumphight == maxjumphight)
            {
                space = false;
                jump = false;
            }

            //Es kann zu Berechnungsfehlern kommen, wenn man sich beim Fallen duckt, die dazu führen, dass der Charakter unter den Boden kommt
            //Das wird hierdurch verhindert
            if (jumphight > maxjumphight)
                jumphight = maxjumphight;
        }

        public bool MaxHeightReached()
        {
            //Wenn die maximale Sprunghöhe erreicht wurde, soll das Key UP Event ausgeführt werden
            if (jumphight <= 0)
                return true;

            return false;
        }

        #region Proprieties



        /*
        public bool KeyReleased
        {
            get { return keyReleased; }
            set { keyReleased = value; }
        }*/

        public int BaseHight
        {
            get { return baseHight; ; }
            set { baseHight = value; }
        }

        public bool KeyPresedUp
        {
            get { return space; }
            set { space = value; }
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


        public int JumpVelocitiy
        {
            get { return jumpVelocitiy; }
            set { jumpVelocitiy = value; }
        }

        public bool Space
        {
            get { return space; }
            set { space = value; }
        }
        public bool Jump
        {
            get { return jump; }
            set { jump = value; }
        }

        #endregion
    }


}