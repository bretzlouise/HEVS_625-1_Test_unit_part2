using System.Drawing;

namespace InputOutputManager
{
    public interface IFileOperations
    {
        Bitmap openFile(string path);

        void saveFile(Bitmap image, string path);

    }
}
