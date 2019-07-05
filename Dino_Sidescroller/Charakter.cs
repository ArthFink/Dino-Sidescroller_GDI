using System;
using System.Drawing;


namespace Dino_Sidescroller
{
    public class Charakter
    {

        const int maxjumphight = 120;
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

            rect = new Rectangle(60, Function(jumphight), 25, 31);

            jump = false; space = false;

            jumphight = maxjumphight;

            jumpVelocitiy = 6;
        }



        public void CharakterJumpFall()
        {

            XCalculation();

            rect.Y = Function(jumphight);

            CharakterReset();
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

            if (!space && jumphight < maxjumphight)
                jumphight += jumpVelocitiy;

            else if (space && jumphight >= 0)
                jumphight -= jumpVelocitiy;


            else if (jumphight == maxjumphight)
            {
                space = false;
                jump = false;
            }


        }

        public bool MaxHeightReached()
        {

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