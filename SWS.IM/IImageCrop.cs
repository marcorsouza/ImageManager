using System.Drawing;

namespace SWS.Plug
{
    public interface IImageCrop
    {
        Image Crop(Image image,Rectangle rectangle);
    }
}