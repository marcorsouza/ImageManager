using System.Drawing;
using System.Drawing.Drawing2D;

namespace SWS.IM
{
    public class ResizeImageManager : ImageManager
    {
        private Size _size;
        public ResizeImageManager(Image image, ImageParameter imageParameter) 
            : base(image, imageParameter)
        {
            SetImageSize(new ProportionalImageSize(image));
        }

        protected override void Builder()
        {
            //Pega dimensões proporcionais da image
            _size = GetSize();

            //Redimenciona a imagem 
            Resize();

            //Corta imagem
            Crop();
        }

        private void Crop()
        {
            var x = 0;
            var y = 0;

            if (ImageParameter.Height > ImageParameter.Width)
            {
                if (_size.Width > ImageParameter.Width)
                {
                    x = (_size.Width - ImageParameter.Width)/2;
                }
            }
            if (ImageParameter.Width > ImageParameter.Height)
            {
                if (_size.Height > ImageParameter.Height)
                {
                    y = (_size.Height - ImageParameter.Height)/2;
                }
            }

            Crop(new Rectangle(x, y, ImageParameter.Width, ImageParameter.Height));
        }

        private void Resize()
        {
            var width = ImageParameter.Width;
            var height = ImageParameter.Height;

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