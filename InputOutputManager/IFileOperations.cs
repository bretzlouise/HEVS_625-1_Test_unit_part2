using System;
using System.Drawing;

namespace InputOutputManager
{
    public interface IFileOperations
    {
        Bitmap openFile(object sender, EventArgs e);

        void saveFile(object sender, EventArgs e, Bitmap resultBitmap);

    }
}
