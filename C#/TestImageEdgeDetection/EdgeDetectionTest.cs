using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using ImageEdgeDetection;
using System.Collections.Generic;


namespace TestImageEdgeDetection
{
    // Class that tests the angle detection methods 
    [TestClass]
    public class EdgeDetectionTest
    {

        public Bitmap result, initialPicture, beachKirsch,beachPrewitt, beachSobel, openSuse;
        public List<Bitmap> pictureList = new List<Bitmap>();
        public string resultImageHash, realResultImageHash,resultPictureAfterFilter_ref, resultSavedBitmap_ref;

        [TestInitialize]
        public void Init()
        {
            //Charging all the images needed for the test from the Resources folder
            initialPicture = Properties.Resources.beach;
            beachKirsch = Properties.Resources.beachKirsch;
            beachPrewitt = Properties.Resources.beachPrewitt;
            beachSobel = Properties.Resources.beachSobel;
            openSuse = Properties.Resources.openSuse;

            pictureList.Add(initialPicture);
            pictureList.Add(beachKirsch);
            pictureList.Add(beachPrewitt);
            pictureList.Add(beachSobel);
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
            foreach (Bitmap picture in pictureList)
            {
                Assert.IsNotNull(picture);
            }

        }

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
            Bitmap resultSavedBitmap = beachPrewitt;

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
            Bitmap resultPictureAfterFilter = initialPicture.Sobel3x3Filter(false);
            Bitmap resultSavedBitmap = beachSobel;

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
            Bitmap resultPictureAfterFilter = initialPicture.KirschFilter(false);
            Bitmap resultSavedBitmap = beachKirsch;

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
            Bitmap resultPictureAfterFilter = initialPicture.PrewittFilter(false);
            Bitmap resultSavedBitmap = beachPrewitt;

            //Call the comparison method between two bitmaps,
            //It returns true or false depending on whether the comparison is correct or not
            bool isSame = TestMethods.CompareImages(resultPictureAfterFilter, resultSavedBitmap);

            Assert.AreEqual(true, isSame);
        }

    }
}
