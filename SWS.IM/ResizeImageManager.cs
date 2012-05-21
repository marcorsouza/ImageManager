using System.Drawing;
using System.Drawing.Drawing2D;

namespace SWS.Plug
{
    public class ResizeImageManager : ImageManager
    {
        private Size _size;
        public ResizeImageManager(Image image, ImageProperty imageProperty) 
            : base(image, imageProperty)
        {
            SetImageSize(new ProportionalImageSize(image));
        }

        protected override void Bind()
        {
            //Pega dimensões proporcionais da image
            _size = CalculateSize();

            //Redimenciona a imagem 
            Resize();

            //Corta imagem
            if (!((ResizeImageProperty)ImageProperty).PreserveAspectRatio)
                Crop();
        }

        private void Crop()
        {
            var x = 0;
            var y = 0;

            if (ImageProperty.Height > ImageProperty.Width)
            {
                if (_size.Width > ImageProperty.Width)
                {
                    x = (_size.Width - ImageProperty.Width)/2;
                }
            }
            if (ImageProperty.Width > ImageProperty.Height)
            {
                if (_size.Height > ImageProperty.Height)
                {
                    y = (_size.Height - ImageProperty.Height)/2;
                }
            }

            Crop(new Rectangle(x, y, ImageProperty.Width, ImageProperty.Height));
        }

        private void Resize()
        {
            var width = ImageProperty.Width;
            var height = ImageProperty.Height;

            if (_size.Width > width)
                width = _size.Width;

            if (_size.Height > height)
                height = _size.Height;


            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(Image, 0, 0, width, height);
            g.Dispose();

            NewImage = (Image) b;
        }
    }
}