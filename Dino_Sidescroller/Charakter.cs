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
        public Charakter()
        {

        }

        private bool keyPresed;

        public bool KeyPresed
        {
            get { return keyPresed; }
            set { keyPresed = value; }
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


        //Wenn the user is Pressing a Key the Charakter Jumps Up
        public int Jump()
        {
            if (keyPresed = true)
            {
                MessageBox.Show(keyPresed.ToString());
            }
            

            return possition_y;       
        }

        public Rectangle GenerateCharacter(SizeF size)
        {
            int h = 50;

            Rectangle rect = new Rectangle(15,Convert.ToInt32( 2 * (size.Height / 3)-h + possition_y), 20, h);
            return rect;
        }

    }
}