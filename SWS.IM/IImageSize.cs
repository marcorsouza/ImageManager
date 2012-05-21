using System.Drawing;

namespace SWS.Plug
{
    public interface IImageSize
    {
        Size CalculateSize(int width, int height);
    }
}