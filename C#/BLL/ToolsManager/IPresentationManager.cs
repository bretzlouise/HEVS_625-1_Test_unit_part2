using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BLL
{
    public interface IPresentationManager
    {
        //Reset controls and enable checkboxes
        void ResetControlsEnableCheckboxes(CheckBox chbNone, CheckBox chbBlackWhite, CheckBox chbRainBow, CheckBox chbSwapColor,
                                                  Button btnSaveNewImage, Button btnReset, Button btnOpenOriginal, Panel toolpanel);

        //Reset controls
        void ResetControl(Control form);

        //Listener for edge detections
        void ListenerEdgeDetectionFilter(object sender, EventArgs e, ComboBox cmbEdgeDetection, CheckBox chbBlackWhite, CheckBox chbRainBow, CheckBox chbSwapColor,
           CheckBox chbNone);

        //Start filter
        void StartFilter(Panel toolPanel, ToolStripStatusLabel lbltsInProgress, ToolStripStatusLabel lbltsPrct,
           ToolStripProgressBar pbtsTraitementPrct, ComboBox cmbEdgeDetection);

        //Check if checkbox none changed
        void CheckChbNoneChanged(object sender, EventArgs e, CheckBox chbBlackWhite, CheckBox chbNone, CheckBox chbRainBow, CheckBox chbSwapColor,
                                       ComboBox cmbEdgeDetection);

        //Check if checkboxes changed
        void CheckThatChanged(object sender, EventArgs e, BackgroundWorker bgWorkerFilter, CheckBox chbNone, ComboBox cmbEdgeDetection,
                                       Panel toolPanel, ToolStripStatusLabel lbltsInProgress, ToolStripStatusLabel lbltsPrct,
           ToolStripProgressBar pbtsTraitementPrct);

        //Reset button
        void ButtonReset(object sender, EventArgs e, CheckBox chbNone, CheckBox chbBlackWhite, CheckBox chbRainBow, CheckBox chbSwapColor, Panel toolPanel,
                               Button btnOpenOriginal, PictureBox picPreview);

        //Backgroundworker progressbar (see loagind progression)
        void BgWorkerProg(object sender, ProgressChangedEventArgs e, ToolStripProgressBar pbtsTraitementPrct,
           ToolStripStatusLabel lbltsPrct);

        //End the filter
        void EndTheFilter(object sender, RunWorkerCompletedEventArgs e, ToolStripStatusLabel lbltsInProgress,
           ToolStripStatusLabel lbltsPrct, ToolStripProgressBar pbtsTraitementPrct, ComboBox cbmEdgeDetection, Panel toolPanel);
    }

}
