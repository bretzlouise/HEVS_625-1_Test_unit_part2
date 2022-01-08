using InputOutputManager;
using System;
using System.Drawing;

namespace BLL.Tools
{
    public class FileManager : InputOutputManager.IImageManager
    {
        bool imageSaved;
        InputOutputManager.IImageManager imageManager;
        public FileManager()
        {
            this.imageManager = new FileManager();
        }

        public FileManager(IImageManager iFileManager)
        {
            this.imageManager = iFileManager;
        }
        //Use the interface to implement reusable methods in the business layer
        public Bitmap loadFile()
        {
            try
            {
                return imageManager.loadFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void saveImage(Bitmap savedImage)
        {
            try
            {
                imageManager.saveImage(savedImage);
                imageSaved = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                imageSaved = false;
            }
        }

        //getter for the bool if the image is saved or not
        public bool getImageSaved()
        {
            return this.imageSaved;
        }
    }
}
