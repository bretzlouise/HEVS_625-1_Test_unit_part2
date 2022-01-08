using System.Drawing;

namespace InputOutputManager
{
    public interface IImageManager
    {
        Bitmap loadFile();
        void saveImage(Bitmap bitmap);

    }
}
