using System.Drawing;

namespace BLL
{
    public interface ICanvasManager
    {
        Bitmap copyToSquareCanvas(Bitmap sourceBitmap, int canvasWidthLenght);
    }
}
