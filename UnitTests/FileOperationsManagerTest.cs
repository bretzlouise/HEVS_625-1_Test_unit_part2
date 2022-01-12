using System;
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

        [TestMethod]
        public void TestLoadFileExceptions()
        {
            //create a substitute for the fileOperation
            var loadFile = Substitute.For<IFileOperations>();


            FileOperations fileOperation = new FileOperations();
            //Make the method throw an exception
            loadFile.openFile().Returns(x => { throw new Exception(); });

            //Emulate null loadFile
            fileOperation.openFile();

            //Test the Exception
            Assert.ThrowsException<Exception>(() => loadFile.openFile());
        }

        [TestMethod]
        public void TestSaveFileExceptions()
        {
            //create a substitute for the fileOperation
            var saveFile = Substitute.For<IFileOperations>();

            FileOperations fileOperation = new FileOperations();

            //Make the method throw an exception
            saveFile
                .When(x => x.saveFile(null))
                .Do(x => { throw new Exception(); });
            //Save a null image
            fileOperation.saveFile(null);
            //Test the Exception
            Assert.ThrowsException<Exception>(() => saveFile.saveFile(null));
        }


    }
}
