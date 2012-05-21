using System.Drawing;

namespace SWS.IM
{
    public interface IImageSize
    {
        Size GetSize(int width, int height);
    }
}