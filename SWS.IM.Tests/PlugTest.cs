using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace SWS.Plug.Tests
{
    [TestFixture]
    public class PlugTest
    {
        private Image _image;

        [SetUp]
        public void Setup()
        {
            //var path = @"D:\Sites\Exemplos\SWS\img\family guy.jpg";
            var path = @"C:\family guy.jpg";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                _image = Image.FromStream(fs);
            }
        }

        [TearDown] 
        public void Dispose()
        {
            _image = null;
        }
        
        [Test]
        public void LoadImageTest()
        {
            Assert.AreNotEqual(_image,null);
        }

        [Test]
        public void ResizeImageWithDimensions1024By768Test()
        {
            ImageProperty param = new ResizeImageProperty() {Width = 122, Height = 124};
            ImageManager imageManager = ImageManagerFactory.Create(ImageManagerType.Resize, _image, param);

            var size = imageManager.CalculateSize();
            Assert.AreEqual(size.Width, 165);
            Assert.AreEqual(size.Height, 124);
        }

        [Test]
        public void ResizeImagePreserveAspectTest()
        {
            ImageProperty param = new ResizeImageProperty() { Width = 122, Height = 124,PreserveAspectRatio = true};
            ImageManager imageManager = ImageManagerFactory.Create(ImageManagerType.Resize, _image, param);
            imageManager.TryBind();

            Assert.AreEqual(imageManager.NewImage.Width, 165);
            Assert.AreEqual(imageManager.NewImage.Height, 124);
        }

        [Test]
        public void SaveImageTest()
        {
            ImageProperty param = new ResizeImageProperty() { Width = 122, Height = 124 };
            ImageManager imageManager = ImageManagerFactory.Create(ImageManagerType.Resize, _image, param);
            imageManager.Save("teste.jpg", ImageFormat.Jpeg);
        }
    }
}
