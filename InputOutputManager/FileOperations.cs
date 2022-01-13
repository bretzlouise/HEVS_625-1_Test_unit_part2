using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace InputOutputManager
{
    public class FileOperations : IFileOperations
    {

        private Bitmap originalBitmap = null;

        public Bitmap openFile(string path)
        {
            // test si le fichier existe
            if (File.Exists(path))
            {
              
                return new Bitmap(path, true);
            }
            else
            {
                
                throw new FileNotFoundException("File does not exists.");
            }
        }

        public void saveFile(Bitmap image, string path)
        {

            ImageFormat imgFormat;
            switch (Path.GetExtension(path).ToLower())
            {
                default:
                case "png":
                    imgFormat = ImageFormat.Png;
                    break;
                case "bmp":
                    imgFormat = ImageFormat.Bmp;
                    break;
                case "jpg":
                    imgFormat = ImageFormat.Jpeg;
                    break;
            }

            StreamWriter streamWriter = new StreamWriter(path, false);
            image.Save(streamWriter.BaseStream, imgFormat);
            streamWriter.Flush();
            streamWriter.Close();
        }

    }
}
