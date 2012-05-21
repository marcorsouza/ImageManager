using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace SWS.IM.Tests
{
    [TestFixture]
    public class IMTest
    {
        private Image image;

        [SetUp]
        public void Setup()
        {
            //var path = @"D:\Sites\Exemplos\SWS\img\family guy.jpg";
            var path = @"D:\Sites\Exemplos\SWS\img\family guy.jpg";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                image = Image.FromStream(fs);
            }
        }

        [TearDown] 
        public void Dispose()
        {
            image = null;
        }
        
        [Test]
        public void LoadImageTest()
        {
            Assert.AreNotEqual(image,null);
        }

        [Test]
        public void ResizeImage122By124WithImage1024By768Test()
        {
            ImageParameter param = new ResizeImageParameter() {Width = 122, Height = 124};

            ImageManager imageManager = ImageManagerFactory.Create(ImageManagerType.Resize, image, param);
            var size = imageManager.GetSize();
            imageManager.Save("teste.jpg",ImageFormat.Jpeg);
            Assert.AreEqual(size.Width, 165);
            Assert.AreEqual(size.Height, 124);
        }
    }
}
