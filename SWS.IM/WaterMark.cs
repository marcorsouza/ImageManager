using System.Drawing;

namespace SWS.IM
{
    public abstract class WaterMark
    {
        public string WaterMarkText { get; set; }
        public abstract Image Create(Image image);
    }
}