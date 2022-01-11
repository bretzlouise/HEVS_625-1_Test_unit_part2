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


        public Bitmap openFile(object sender, EventArgs e)
        {
            try
            {
                originalBitmap = fileOperations.openFile(sender, e);
                resultBitmap = originalBitmap;

                return originalBitmap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void saveFile(object sender, EventArgs e, Bitmap resultBitmapNeed)
        {

            try
            {
                fileOperations.saveFile(sender, e,resultBitmapNeed);
                imageSaved = true;
                resultBitmap = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                imageSaved = false;
            }
        }

        
    }
}
