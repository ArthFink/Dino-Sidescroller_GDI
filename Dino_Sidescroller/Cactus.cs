using System.Drawing;

namespace Dino_Sidescroller
{
    public class Cactus
    {
        int imgIndex;
        Rectangle hitBoxRectangle;

        public Cactus()
        {

            hitBoxRectangle = new Rectangle(10, 10, 10, 10);

        }

        #region Properties


        public Rectangle HitBoxRectangle
        {
            get { return hitBoxRectangle; }
            set { hitBoxRectangle = value; }

        }

        public int ImgIndex
        {
            get { return imgIndex; }
            set { imgIndex = value; }
        }

        #endregion

    }
}
