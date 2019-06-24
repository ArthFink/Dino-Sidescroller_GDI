using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dino_Sidescroller
{
    public class Obstacles
    {
        public Obstacles()
        {

        }

        public Obstacles(int px,int py, int hight,int width)
        {
            possition_x = px;
            possition_y = py;
            this.hight = hight;
            this.width = width;
        }
        #region Properties
        private int possition_x;

        public int Possition_x
        {
            get { return possition_x; }
            set { possition_x = value; }
        }

        private int possition_y;

        public int Possition_y
        {
            get { return possition_y; }
            set { possition_y = value; }
        }

        private int hight;

        public int Hight
        {
            get { return hight; }
            set { hight = value; }
        }

        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        #endregion
    }
}