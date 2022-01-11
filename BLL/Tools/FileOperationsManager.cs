using System;
using InputOutputManager;
using System.Drawing;

namespace BLL.Tools
{
    public class FileOperationsManager : InputOutputManager.IFileOperations
    {

        bool imageSaved;
        InputOutputManager.IFileOperations fileOperations;

        private Bitmap edited = null;
        private Bitmap originalBitmap = null;
        private Bitmap modifiedBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        private Bitmap filterBitmap = null;
        private bool filterButtonEnabled = false;
        private bool dropListEnabled = false;

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
                previewBitmap = originalBitmap;
                resultBitmap = originalBitmap;
                filterBitmap = originalBitmap;
                modifiedBitmap = originalBitmap;

                //ApplyFilter(true);

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
