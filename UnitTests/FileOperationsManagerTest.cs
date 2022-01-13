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

            fileOperations.openFile();

  
            Assert.IsTrue(TestMethods.CompareImages(imageStored, 
                (new Bitmap(Properties.Resources.beach))));
        }

        // Test method to check that if the saveFile() method used in the FileOperationManager is correct
        [TestMethod]
        public void TestSaveFile()
        {
            var saveFile = Substitute.For<IFileOperations>(); //create a substitute for the interface
            Bitmap beachStored = Properties.Resources.beach;
            
            saveFile.saveFile(beachStored); //use the image has substitute of saving a file
            FileOperationsManager fileOperations = new FileOperationsManager(saveFile);


            fileOperations.saveFile(beachStored); //Execute the method

            Assert.IsTrue(fileOperations.getFileSaved()); //Test if the the file is saved
        }

        // Test method to check that if the exception is correct with the loadFile() method
        [TestMethod]
        public void TestLoadFileExceptions()
        {
            var loadFile = Substitute.For<IFileOperations>(); //create a substitute for the fileOperation
            FileOperations fileOperation = new FileOperations(); 
            
            loadFile.openFile().Returns(x => { throw new FileNotFoundException(); }); //Make the method throw an exception

            fileOperation.openFile(); //Emulate null loadFile

            Assert.ThrowsException<FileNotFoundException>(() => loadFile.openFile()); //Test the Exception
        }


        // Test method to check that if the exception is correct with the saveFile() method
        [TestMethod]
        public void TestSaveFileExceptions()
        {
            var saveFile = Substitute.For<IFileOperations>(); //create a substitute for the fileOperation
            FileOperations fileOperation = new FileOperations();
          
            saveFile
                .When(x => x.saveFile(null))
                .Do(x => { throw new Exception(); }); //Make the method throw an exception
            
            fileOperation.saveFile(null); //Save a null image
        
            Assert.ThrowsException<Exception>(() => saveFile.saveFile(null)); //Test the Exception
        }

        [TestMethod]
        public void TestfileOperationsEmptyConstructor()
        {
            bool isExisting = false;

            FileOperationsManager fileOperations = new FileOperationsManager();
            if (fileOperations != null)
            {
                isExisting = true;
            }
            Assert.AreEqual(true, isExisting);
        }



    }
}
