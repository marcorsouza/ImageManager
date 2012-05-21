using System.Drawing;

namespace SWS.IM
{
    public interface IImageCrop
    {
        Image Crop(Image image,Rectangle rectangle);
    }
}