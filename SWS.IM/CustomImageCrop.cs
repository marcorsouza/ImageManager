﻿using System.Drawing;

namespace SWS.Plug
{
    public class CustomImageCrop:IImageCrop
    {
        public Image Crop(Image image, Rectangle rectangle)
        {
            Bitmap bmpImage = new Bitmap(image);
            Bitmap bmpCrop = bmpImage.Clone(rectangle, bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }
    }
}