using System;
using System.Drawing;
using System.IO;
using BLL.Tools;
using InputOutputManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTests
{
    [TestClass]
    public class FileManagerTest
    {
        // IFileOperations imageManager;
        // Substitute.For<IFileOperations>();
        IFileOperations imageManager;
        [TestInitialize]
        public void Initialize()
        {
            imageManager = new FileOperationsManager();
            imageManager = Substitute.For<IFileOperations>();

        }
        [TestMethod]
        public void TestLoadExistingImage()
        {
            string target = @"existingImage.png";
            imageManager.openFile(target).Returns(new Bitmap(10, 10));
            Bitmap tmp = imageManager.openFile(target);
            Assert.AreEqual(tmp.Width, 10);
            Assert.AreEqual(tmp.Height, 10);
        }

        [TestMethod]
        public void TestLoadEmptyImage()
        {
            string target = @"emptyImage.png";
            imageManager.openFile(target).Returns(x => { throw new FileNotFoundException(); });
            Assert.ThrowsException<FileNotFoundException>(() => imageManager.openFile(target));
        }

        [TestMethod]
        public void TestSaveImage()
        {
            string path = @"existingImage.png";
            Bitmap image = new Bitmap(10, 10);
            imageManager.saveFile(image, path);
            imageManager.Received(1).saveFile(Arg.Any<Bitmap>(), Arg.Any<string>());
        }

    }
}
