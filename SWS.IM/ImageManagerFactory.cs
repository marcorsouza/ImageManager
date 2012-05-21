using System.Drawing;

namespace SWS.IM
{
    public enum ImageManagerType
    {
        Resize    
    }

    public class ImageManagerFactory
    {
        public static ImageManager Create(ImageManagerType manager, Image image, ImageParameter parameterManager)
        {
            ImageManager imageManager = null;

            switch (manager)
            {
                case ImageManagerType.Resize:
                    imageManager = new ResizeImageManager(image, parameterManager);
                    break;
            }

            return imageManager;
        }
    }
}