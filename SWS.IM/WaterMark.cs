using System.Drawing;

namespace SWS.Plug
{
    public abstract class WaterMark
    {
        public string WaterMarkText { get; set; }
        public abstract Image Create(Image image);
    }
}