using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using BLL.Interface;
using BLL.ModificationImage;

namespace UnitTests
{
    [TestClass]
    public class EdgeDetectionTest
    {
        public Bitmap initialPicture = Properties.Resources.beach;
        public Bitmap openSuse = Properties.Resources.openSuse;
        IEdgeDetection edgeDetection = new EdgeDetection();


        //Test method to check if the method CompareImages is right
        [TestMethod]
        public void CompareImagesMethodTest()
        {
            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = initialPicture;
            Bitmap resultSavedBitmap = initialPicture;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(true, isSame);
        }

        //Test method to check if the method CompareImages return false when widths arent the same
        [TestMethod]
        public void CompareImagesMethodTestWithWrongSize()
        {
            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = initialPicture;
            Bitmap resultSavedBitmap = openSuse;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(false, isSame);
        }

        //Test method to check if the method CompareImages return false when the pixels arent the same
        [TestMethod]
        public void CompareImagesMethodTestWithPixelsDifferents()
        {
            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = initialPicture;
            Bitmap resultSavedBitmap = Properties.Resources.beachPrewitt;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(false, isSame);
        }

        //Test method to check that the Sobel 3x3 filter works in the same way in the code and in the app result
        [TestMethod]
        public void Sobel3x3EdgeDetectionTest()
        {
            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = edgeDetection.Sobel3x3Filter(initialPicture);//.Sobel3x3Filter(false);
            Bitmap resultSavedBitmap = Properties.Resources.beachSobel;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(true, isSame);
        }

        //Test method to check that the Kirsch filter works in the same way in the code and in the app result
        [TestMethod]
        public void KirschEdgeDetectionTest()
        {
            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = edgeDetection.KirschFilter(initialPicture);
            Bitmap resultSavedBitmap = Properties.Resources.beachKirsch;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(true, isSame);
        }


        //Test method to check that the Prewitt filter works in the same way in the code and in the app result
        [TestMethod]
        public void PrewittEdgeDetectionTest()
        {

            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = edgeDetection.PrewittFilter(initialPicture);
            Bitmap resultSavedBitmap = Properties.Resources.beachPrewitt;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(true, isSame);
        }
    }
}
