using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BLL
{
    public interface IReadWriteFileApplyFilter
    {
        //Load Image method
        void LoadImage(object sender, EventArgs e, PictureBox picPreview);

        //Save Image method
        void SaveImage(object sender, EventArgs e);

        //Set preview Bitmap method
        void SetPreviewBitmap(Object sender, Bitmap originalBitmap, PictureBox picPreview);

        //Apply Filter method
        void ApplyTheFilter(bool preview, ComboBox cmbEdgeDetection, PictureBox picPreview, BackgroundWorker bgWorker, int selectedIndex
                                      , Panel toolPanel, ToolStripStatusLabel lbltsInProgress, ToolStripStatusLabel lbltsPrct,
                                  ToolStripProgressBar pbtsTraitementPrct);

        //Reset picture to original method
        void ResetPicture(Object sender, PictureBox picPreview);

        //Reset picture and controls method
        void ResetAll(Object sender, PictureBox picPreview, EventArgs e, CheckBox chbNone, CheckBox chbBlackWhite, CheckBox chbRainBow, CheckBox chbSwapColor,
           Panel toolPanel, Button btnOpenOriginal);

        //Backgroundworker method
        void DoBgWorker(object sender, DoWorkEventArgs e, PictureBox picPreview);
    }
}
