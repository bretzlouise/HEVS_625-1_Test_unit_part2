using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace InputOutputManager
{
    public class ImageManager
    {

        public Bitmap loadFile()
        {
            Bitmap originalBitmap = null;
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Select an image file.",
                Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp"
            };
            //Load selected image in the Bitmap
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Image.FromStream(streamReader.BaseStream);
                streamReader.Close();
            }
            return originalBitmap;
        }

        // Save the edited Image 
        public void saveImage(Bitmap editedImage)
        {
            if (editedImage != null) // check the value of the image
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Title = "Specify a file name and file path",
                    Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp"
                };

                if (sfd.ShowDialog() == DialogResult.OK) // if the save process ok
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                        imgFormat = ImageFormat.Bmp;
                    else if (fileExtension == "JPG")
                        imgFormat = ImageFormat.Jpeg;

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    editedImage.Save(streamWriter.BaseStream, imgFormat); // save the final image
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
        }
    }
}
