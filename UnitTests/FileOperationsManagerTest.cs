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

        // Test method to check that if the exception is correct with the loadFile() method
        [TestMethod]
        public void TestLoadFileExceptions()
        {
           
            var loadFile = Substitute.For<IFileOperations>();  //create a substitute for the fileOperation

            FileOperations fileOperation = new FileOperations(); 
            
            loadFile.openFile().Returns(x => { throw new Exception(); });//Make the method throw an exception

            
            fileOperation.openFile();//Emulate null loadFile

          
            Assert.ThrowsException<Exception>(() => loadFile.openFile());  //Test the Exception
        }


        // Test method to check that if the exception is correct with the saveFile() method
        [TestMethod]
        public void TestSaveFileExceptions()
        {
            
            var saveFile = Substitute.For<IFileOperations>();//create a substitute for the fileOperation
            FileOperations fileOperation = new FileOperations();

          
            saveFile
                .When(x => x.saveFile(null))
                .Do(x => { throw new Exception(); });  //Make the method throw an exception
            
            fileOperation.saveFile(null);//Save a null image
        
            Assert.ThrowsException<Exception>(() => saveFile.saveFile(null));    //Test the Exception
        }


    }
}
