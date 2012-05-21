using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace SWS.Plug
{
    public abstract class ImageManager
    {
        public ImageProperty ImageProperty { get; private set; }
        protected Image Image;
        public Image NewImage { get; protected set; }
        private IImageSize _imageSize;
        private IImageCrop _imageCrop;
        private IImageSharpen _imageSharpen;
        private bool isBinding = false;

        readonly WaterMark _waterMark;

        protected abstract void Bind();

        public void SetImageSize(IImageSize imageSize)
        {
            _imageSize = imageSize;
        }

        public void SetImageCrop(IImageCrop imageCrop)
        {
            _imageCrop = imageCrop;
        }

        public void SetImageSharpen(IImageSharpen imageSharpen)
        {
            _imageSharpen = imageSharpen;
        }

        public Size CalculateSize()
        {
            return _imageSize.CalculateSize(ImageProperty.Width, ImageProperty.Height);
        }

        protected void Crop(Rectangle rectangle)
        {
            NewImage = _imageCrop.Crop(NewImage, rectangle);
        }

        public void Sharpen()
        {
            TryBind();

            NewImage = _imageSharpen.Sharpen(NewImage);
        }

        public bool TryBind()
        {
            if (isBinding == false)
            {
                Bind();
                isBinding = true;
            }

            return isBinding;
        }

        protected ImageManager(Image image, ImageProperty imageProperty,WaterMark waterMark = null)
        {
            Image = image;
            _waterMark = waterMark;
            ImageProperty = imageProperty;

            SetImageCrop(new CustomImageCrop());
            SetImageSharpen(new ImageSharpen());
        }
        
        public void Save(string fileName, ImageFormat imageFormat=null)
        {
            TryBind();

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