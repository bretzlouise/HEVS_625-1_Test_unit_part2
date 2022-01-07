using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace BLL
{
    public class ReadWriteFileApplyFilter : IReadWriteFileApplyFilter
    {
        //A bitmap consists of the pixel data for a graphics image and its attributes

        private Bitmap previewBitmap = null;
        private Bitmap copyBitmap = null;
        private Bitmap resultBitmap = null;
        private Bitmap originalBitmap = null;

        IPresentation p = new Presentation();
        IImageFilters iif = new ImageFilters();
        IEdgeDetection eed = new EdgeDetection();
        ICanvasManager cm = new CanvasManager();

        //Load an Image
        public void LoadImage(object sender, EventArgs e, PictureBox picPreview)
        {

            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = @"Select an image file.",
                Filter = @"Images|*.png;*.jpg;*.jpeg;*.bmp|Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            StreamReader streamReader = new StreamReader(ofd.FileName);
            originalBitmap = (Bitmap)Image.FromStream(streamReader.BaseStream);
            streamReader.Close();
            SetPreviewBitmap(sender, originalBitmap, picPreview);

        }

        //Save the Image
        public void SaveImage(object sender, EventArgs e)
        {
            if (resultBitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Title = @"Specify a file name and file path",
                    Filter = @"Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;
                string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                ImageFormat imgFormat = ImageFormat.Png;

                // using switch - case beacuase we only have two different cases 
                switch (fileExtension)
                {
                    case "BMP":
                        imgFormat = ImageFormat.Bmp;
                        break;
                    case "JPG":
                        imgFormat = ImageFormat.Jpeg;
                        break;
                }

                StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                streamWriter.Flush();
                streamWriter.Close();

                resultBitmap = null;
            }
        }

        //Backgroundworker
        public void DoBgWorker(object sender, DoWorkEventArgs e, PictureBox picPreview)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            switch (e.Argument)
            {
                case "Rainbow":
                    previewBitmap = iif.RainbowFilter(previewBitmap);
                    copyBitmap = previewBitmap;
                    break;
                case "Black and White":
                    previewBitmap = iif.BlackWhite(previewBitmap);
                    copyBitmap = previewBitmap;
                    break;
                case "Swap color":
                    previewBitmap = iif.SwapFilter(previewBitmap);
                    copyBitmap = previewBitmap;
                    break;
 
            }

            resultBitmap = new Bitmap(copyBitmap);

            //make sure that the picPreview will not be used
            lock (picPreview.Image)
            {
                //set the copy as the new Image of the ui element
                picPreview.Image = copyBitmap;
            }
        }

        //Set preview bitmap
        public void SetPreviewBitmap(object sender, Bitmap originalBitmap, PictureBox picPreview)
        {
            previewBitmap = cm.copyToSquareCanvas(originalBitmap, picPreview.Width);
            picPreview.Image = previewBitmap;
        }
        //Apply the filters
        public void ApplyTheFilter(bool preview, ComboBox cmbEdgeDetection, PictureBox picPreview, BackgroundWorker bgWorkerFilter, int SelectedIndex
                                   , Panel toolPanel, ToolStripStatusLabel lbltsInProgress, ToolStripStatusLabel lbltsPrct,
                                   ToolStripProgressBar pbtsTraitementPrct)
        {
            if (previewBitmap == null || cmbEdgeDetection.SelectedIndex == -1)
            {
                return;
            }

            /* Reason : we change the way that we make , we took all the stuff and make it in BackgroundWorker to don't have "freeze" on the app
             * 
             */
            copyBitmap = (Bitmap)picPreview.Image.Clone();
            p.StartFilter(toolPanel, lbltsInProgress, lbltsPrct, pbtsTraitementPrct, cmbEdgeDetection);
            bgWorkerFilter.RunWorkerAsync(cmbEdgeDetection.SelectedItem.ToString());
        }
        //Reset the picture to original
        public void ResetPicture(Object sender, PictureBox picPreview)
        {
            SetPreviewBitmap(sender, originalBitmap, picPreview);
        }
        //Reset picture and Controls
        public void ResetAll(Object sender, PictureBox picPreview, EventArgs e, CheckBox chbNone, CheckBox chbBlackWhite, CheckBox chbRainBow, CheckBox chbSwapColor,
            Panel toolPanel, Button btnOpenOriginal)
        {
            p.ButtonReset(sender, e, chbNone, chbBlackWhite, chbRainBow, chbSwapColor, toolPanel, btnOpenOriginal, picPreview);
            ResetPicture(sender, picPreview);
        }

    }
}
