using System.Drawing;
using BLL.Interface;
using BLL.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTests
{
    [TestClass]
    public class CanvasManagerTest
    {
        [TestMethod]
        public void TestCopyToSquareCanvas()
        {
            //Arrange
            Bitmap result = new CanvasManager().copyToSquareCanvas(new Bitmap(1080, 720), 1000);
            var subCanvas = Substitute.For<ICanvasManager>();
            CanvasManager canvas = new CanvasManager();
            Bitmap originalImage = Properties.Resources.openSuse;
            subCanvas.copyToSquareCanvas(originalImage, 415).Returns(originalImage);

            //Act
            Bitmap subCanvasImage = subCanvas.copyToSquareCanvas(originalImage, 415);
            Bitmap canvasImage = canvas.copyToSquareCanvas(originalImage, 415);

            //Assert
            Assert.AreNotEqual(new Bitmap(720, 1080).Width, result.Width);
            Assert.IsTrue(TestMethods.CompareImages(subCanvasImage, canvasImage));
        }
    }
}
