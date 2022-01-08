using System.Drawing;

namespace BLL.Interface
{
    public interface ICanvasManager
    {
        Bitmap copyToSquareCanvas(Bitmap sourceBitmap, int canvasWidthLenght);
    }
}
