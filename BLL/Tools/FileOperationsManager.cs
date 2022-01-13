using InputOutputManager;
using System.Drawing;

namespace BLL.Tools
{
    public class FileOperationsManager : InputOutputManager.IFileOperations
    {
        //Call to the interface
        InputOutputManager.IFileOperations fileOperations;
        

        public FileOperationsManager()
        {
            this.fileOperations = new FileOperations();
        }

        public FileOperationsManager(IFileOperations iFileOperations)
        {
            this.fileOperations = iFileOperations;
        }


        public Bitmap openFile(string path)
        {
            return fileOperations.openFile(path);
        }

        public void saveFile(Bitmap image, string path)
        {
            fileOperations.saveFile(image, path);
        }



    }
}
