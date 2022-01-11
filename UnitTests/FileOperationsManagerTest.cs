using System.Drawing;
using BLL.Tools;
using InputOutputManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTests
{
    [TestClass]
    public class FileOperationsManagerTest
    {

        // Test method to check that if the openFile() method used in the FileOperationManager is correct
        [TestMethod]
        public void TestOpenFile()
        {
            
            var loadedFile = Substitute.For<IFileOperations>(); //create a substitute for the interface
            Bitmap imageStored = Properties.Resources.beach; //get the file stored            
            loadedFile.openFile().Returns(imageStored); //use the image has substitute of selecting a file

            
            FileOperationsManager fileOperations = new FileOperationsManager(loadedFile); //instantiate the BLL methods
            CanvasManager canvasManager = new CanvasManager();

            fileOperations.openFile();
            Bitmap resultInCanvas = canvasManager.copyToSquareCanvas(imageStored, 415); //Add the file in the canvas

            
            Assert.IsTrue(TestMethods.CompareImages(resultInCanvas, 
                canvasManager.copyToSquareCanvas(new Bitmap(Properties.Resources.beach), 415)));
        }

        // Test method to check that if the saveFile() method used in the FileOperationManager is correct
        [TestMethod]
        public void TestSaveFile()
        {

            var saveFile = Substitute.For<IFileOperations>(); //create a substitute for the interface
            Bitmap beachStored = Properties.Resources.beach;
            
            saveFile.saveFile(beachStored);//use the image has substitute of saving a file
            FileOperationsManager fileOperations = new FileOperationsManager(saveFile);

            fileOperations.saveFile(beachStored); //Execute the method

            Assert.IsTrue(fileOperations.getFileSaved());  //Test if the the file is saved
        }

       
    }
}
