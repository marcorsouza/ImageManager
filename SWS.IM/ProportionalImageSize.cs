using System;
using System.Drawing;

namespace SWS.Plug
{
    public class ProportionalImageSize : IImageSize
    {
        private readonly Image _image;

        public ProportionalImageSize(Image image)
        {
            _image = image;
        }

        public Size CalculateSize(int width, int height)
        {
            double imgWidth = _image.Width;
            double imgHeight = _image.Height;
            int newWidth = 0;
            int newHeight = 0;
            Size newSize = new Size();

            if (width < height)
            {
                double perc = Math.Round((height * 100 / imgHeight), 2);
                newWidth = (int)(imgWidth * perc / 100);
                newHeight = (int)height;
                newSize = new Size(newWidth, newHeight);
            }
            else if (width > height)
            {
                double perc = Math.Round((width * 100 / imgWidth), 2);
                newHeight = (int)(imgHeight * perc / 100);
                newWidth = (int)width;
                newSize = new Size(newWidth, newHeight);
            }

            return newSize;
        }
    }
}