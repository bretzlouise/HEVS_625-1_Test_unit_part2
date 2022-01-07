using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using ImageEdgeDetection;
using System.Collections.Generic;

namespace TestImageEdgeDetection
{
    // Class that tests the filter methods 
    [TestClass]
    public class FilterTest
    {

        public Bitmap originalPictureOpenSuse, originalPictureForest, rainbowedPicture, swapedPicture,
                        kirschPicture, prewitPicture, sobelPicture, result;
        public List<Bitmap> pictureList = new List<Bitmap>(); 
        public IImageFilters imageFilters = new ImageFilters();


        [TestInitialize]
        public void Init()
        {
            //Charging all the pictures needed for the test from the Resources of the projecz
            originalPictureOpenSuse = Properties.Resources.openSuse;
            rainbowedPicture = Properties.Resources.openSuseRainbow;
            swapedPicture = Properties.Resources.openSuseSwap;

            pictureList.Add(originalPictureOpenSuse);
            pictureList.Add(rainbowedPicture);
            pictureList.Add(swapedPicture);
        }

        //Test method to check that the initially loaded table is filled in
        [TestMethod]
        public void PictureListTest()
        {
            Assert.IsNotNull(pictureList);
        }

        //Test method to check that each image in the table has content
        [TestMethod]
        public void AllResourcePictureTest()
        {
            foreach(Bitmap picture in pictureList)
            {
                Assert.IsNotNull(picture);
            }
            
        }

        //Test method to check that the Rainbow filter works in the same way in the code and in the app result
        [TestMethod]
        public void RainbowFilterTest()
        {
            // Loading images et application of the filter
            Bitmap resultPictureAfterFilter = imageFilters.RainbowFilter(originalPictureOpenSuse);
            Bitmap resultSavedBitmap = rainbowedPicture;

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
            Bitmap resultSavedBitmap = swapedPicture;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(true, isSame);
        }


    }
}
