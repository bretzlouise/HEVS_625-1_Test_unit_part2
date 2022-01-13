using System.Drawing;

namespace InputOutputManager
{
    public interface IFileOperations
    {
        Bitmap openFile();

        void saveFile(Bitmap resultBitmap);

    }
}
