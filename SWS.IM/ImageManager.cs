using System.Drawing;
using System.Drawing.Imaging;

namespace SWS.IM
{
    public abstract class ImageManager
    {
        public ImageParameter ImageParameter { get; private set; }
        protected Image Image;
        public Image NewImage { get; protected set; }
        private IImageSize _imageSize;
        private IImageCrop _imageCrop;
        
        private readonly WaterMark _waterMark;

        protected abstract void Builder();

        public void SetImageSize(IImageSize imageSize)
        {
            _imageSize = imageSize;
        }

        public void SetImageCrop(IImageCrop imageCrop)
        {
            _imageCrop = imageCrop;
        }

        public Size GetSize()
        {
            return _imageSize.GetSize(ImageParameter.Width, ImageParameter.Height);
        }

        protected void Crop(Rectangle rectangle)
        {
            NewImage = _imageCrop.Crop(NewImage, rectangle);
        }

        protected ImageManager(Image image, ImageParameter imageParameter,WaterMark waterMark = null)
        {
            Image = image;
            _waterMark = waterMark;
            ImageParameter = imageParameter;

            SetImageCrop(new CustomImageCrop());
        }
        
        public void Save(string fileName, ImageFormat imageFormat=null)
        {
            Builder();

            if (_waterMark != null)
                NewImage = _waterMark.Create(NewImage);

            if(imageFormat != null)
            {
                NewImage.Save(fileName, imageFormat);
            }
            else
            {
                NewImage.Save(fileName);
            }

            NewImage = null;
        }
    }
}