using System.Drawing;


namespace BLL.Interface
{
    interface IEdgeDetection
    {
        //convolution filter (returning bitmap)
        Bitmap ConvolutionFilter(Bitmap sourceBitmap,
                                             double[,] xFilterMatrix,
                                             double[,] yFilterMatrix,
                                                  double factor = 1,
                                                       int bias = 0,
                                             bool grayscale = false);


        //Creating interface for the image Detection 
        Bitmap Sobel3x3Filter(Bitmap sourceBitmap,
                                                bool grayscale = true);
        Bitmap PrewittFilter(Bitmap sourceBitmap,
                                               bool grayscale = true);
        Bitmap KirschFilter(Bitmap sourceBitmap,
                                              bool grayscale = true);
    }
}
