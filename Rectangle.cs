namespace RGBNeuralNet
{
    public class Rectangle
    {
        public Rectangle(int x, int y, int width, int height)
        {
            Left = x;
            Top = y;
            Width = width;
            Height = height;
        }

        public int Left
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Top
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Right
        {
            get
            {
                return Left + Width;
            }
        }

        public int Bottom
        {
            get
            {
                return Top + Height;
            }
        }
    }
}
