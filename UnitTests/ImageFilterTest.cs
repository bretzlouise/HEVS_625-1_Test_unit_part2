using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using BLL.Interface;
using BLL.ModificationImage;

namespace UnitTests
{
    [TestClass]
    public class ImageFilterTest
    {

        public Bitmap originalPictureOpenSuse = Properties.Resources.openSuse;
        public IImageFilters imageFilters = new ImageFilters();


        //Test method to check that the Rainbow filter works in the same way in the code and in the app result
        [TestMethod]
        public void RainbowFilterTest()
        {
            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = imageFilters.RainbowFilter(originalPictureOpenSuse);
            Bitmap resultSavedBitmap = Properties.Resources.openSuseRainbow;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(true, isSame);
        }

        //Test method to check that the Swap filter works in the same way in the code and in the app result
        [TestMethod]
        public void SwapFilterTest()
        {
            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = imageFilters.SwapFilter(originalPictureOpenSuse);
            Bitmap resultSavedBitmap = Properties.Resources.openSuseSwap;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(true, isSame);
        }

    }
}
