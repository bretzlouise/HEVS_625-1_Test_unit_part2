using System;
using InputOutputManager;
using System.Drawing;

namespace BLL.Tools
{
    public class FileOperationsManager : InputOutputManager.IFileOperations
    {
        //Call to the interface
        InputOutputManager.IFileOperations fileOperations;
        
        //Variables
        bool imageSaved;
        private Bitmap originalBitmap = null;
        private Bitmap resultBitmap = null;

        public FileOperationsManager()
        {
            this.fileOperations = new FileOperations();
        }

        public FileOperationsManager(IFileOperations iFileOperations)
        {
            this.fileOperations = iFileOperations;
        }


        public Bitmap openFile()
        {
            try
            {

                originalBitmap = fileOperations.openFile();

                resultBitmap = originalBitmap;

                return originalBitmap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void saveFile(Bitmap resultBitmapNeed)
        {

            try
            {
                fileOperations.saveFile(resultBitmapNeed);
                imageSaved = true;
                resultBitmap = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                imageSaved = false;
            }
        }

        //getter for the bool if the file is saved or not
        public bool getFileSaved()
        {
            return this.imageSaved;
        }


    }
}
