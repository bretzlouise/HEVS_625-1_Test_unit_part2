using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BLL
{
    public class PresentationManager : IPresentationManager
    { 
        //background worker progress
        public void BgWorkerProg(object sender, ProgressChangedEventArgs e, ToolStripProgressBar pbtsTraitementPrct, ToolStripStatusLabel lbltsPrct)
        {

            pbtsTraitementPrct.Value = e.ProgressPercentage;
            lbltsPrct.Text = e.ProgressPercentage + @" %"; //Show the purcentage of progess
        }

        //Reset buttons
        public void ButtonReset(object sender, EventArgs e, CheckBox chbNone, CheckBox chbBlackWhite, CheckBox chbRainBow, CheckBox chbSwapColor, Panel toolPanel, Button btnOpenOriginal,
            PictureBox picPreview)
        {
            ResetControl(toolPanel);
            ResetControl(chbBlackWhite);
            ResetControl(chbRainBow);
            ResetControl(chbSwapColor);
            ResetControl(chbNone);
            //Enable the different elements
            btnOpenOriginal.Enabled = chbRainBow.Enabled = chbSwapColor.Enabled = chbNone.Enabled = chbBlackWhite.Enabled = true;


        }
        //Check checkbox none changed
        public void CheckChbNoneChanged(object sender, EventArgs e, CheckBox chbBlackWhite, CheckBox chbNone, CheckBox chbRainBow, CheckBox chbSwapColor, ComboBox cmbEdgeDetection)
        {
            if (chbNone.Checked)//true
            {
                chbBlackWhite.Checked = chbSwapColor.Checked = chbRainBow.Checked = false;
                chbBlackWhite.Enabled = chbSwapColor.Enabled = chbRainBow.Enabled = false;

                cmbEdgeDetection.Enabled = true;
            }
            else //false
            {
                chbBlackWhite.Enabled = true;
                chbRainBow.Enabled = true;
                chbSwapColor.Enabled = true;
                cmbEdgeDetection.Enabled = false;
            }
        }


        //Check if checkboxes changed
        public void CheckThatChanged(object sender, EventArgs e, BackgroundWorker bgWorkerFilter, CheckBox chbNone, ComboBox cmbEdgeDetection
                                    , Panel toolPanel, ToolStripStatusLabel lbltsInProgress, ToolStripStatusLabel lbltsPrct,
            ToolStripProgressBar pbtsTraitementPrct)
        {
            //sender is a checkBox
            CheckBox senderEvent = sender as CheckBox;

            if (senderEvent.Checked)
            {
                StartFilter(toolPanel, lbltsInProgress, lbltsPrct, pbtsTraitementPrct, cmbEdgeDetection);
                //run the worker, and pass the name of the checkbox as parameter
                bgWorkerFilter.RunWorkerAsync(senderEvent.Text.ToString());
                chbNone.Enabled = senderEvent.Enabled = false;
            }
            else
            {
                chbNone.Enabled = true;
                cmbEdgeDetection.Enabled = false;
            }
        }


        //end the filter and enable edge detections
        public void EndTheFilter(object sender, RunWorkerCompletedEventArgs e, ToolStripStatusLabel lbltsInProgress, ToolStripStatusLabel lbltsPrct, ToolStripProgressBar pbtsTraitementPrct, ComboBox cmbEdgeDetection, Panel toolPanel)
        {
            lbltsInProgress.Text = @"Done";
            lbltsPrct.Visible = false;
            pbtsTraitementPrct.Visible = false;
            cmbEdgeDetection.Enabled = true;
            toolPanel.Enabled = true;
        }
        //Listener for edge detections
        public void ListenerEdgeDetectionFilter(object sender, EventArgs e, ComboBox cmbEdgeDetection, CheckBox chbBlackWhite, CheckBox chbRainBow, CheckBox chbSwapColor, CheckBox chbNone)
        {
            if (cmbEdgeDetection.SelectedIndex >= 1)
            {
                chbBlackWhite.Enabled = false;
                chbRainBow.Enabled = false;
                chbSwapColor.Enabled = false;
                chbNone.Enabled = false;
            }

            //Disable Checkboxes if nothing selected
            if (chbNone.Checked.Equals(true))
            {
                chbBlackWhite.Enabled = false;
                chbRainBow.Enabled = false;
                chbSwapColor.Enabled = false;
            }
            if (chbRainBow.Checked.Equals(true) || chbBlackWhite.Checked.Equals(true) || chbSwapColor.Checked.Equals(true))
            {
                chbNone.Enabled = false;
            }
        }

        //Reset controls method to reset ui elements
        public void ResetControl(Control form)
        {
            foreach (Control control in form.Controls)
            {
                switch (control)
                {
                    // set control in comboBox (with a cast automaticaly)
                    case ComboBox comboBox:
                        {
                            if (comboBox.Items.Count > 0)
                                comboBox.SelectedIndex = -1;
                            break;
                        }
                    case CheckBox checkBox:
                        {
                            checkBox.Checked = false;
                            break;
                        }
                }
            }
        }

        //Reset controls and enable checkboxes
        public void ResetControlsEnableCheckboxes(CheckBox chbNone, CheckBox chbBlackWhite, CheckBox chbRainBow, CheckBox chbSwapColor,
                                                   Button btnSaveNewImage, Button btnReset, Button btnOpenOriginal, Panel toolPanel)
        {
            chbNone.Enabled = chbBlackWhite.Enabled = chbRainBow.Enabled = chbSwapColor.Enabled = btnSaveNewImage.Enabled = btnReset.Enabled = true;
            btnOpenOriginal.Enabled = true;
            ResetControl(toolPanel);
            ResetControl(chbBlackWhite);
            ResetControl(chbRainBow);
            ResetControl(chbSwapColor);
            ResetControl(chbNone);
        }

        //Start filters
        public void StartFilter(Panel toolPanel, ToolStripStatusLabel lbltsInProgress, ToolStripStatusLabel lbltsPrct,
            ToolStripProgressBar pbtsTraitementPrct, ComboBox cmbEdgeDetection)
        {
            toolPanel.Enabled = false;
            lbltsInProgress.Visible = true;
            lbltsInProgress.Text = @"In progress :"; //Element to show progression in %
            lbltsPrct.Visible = true;
            pbtsTraitementPrct.Visible = true;
            cmbEdgeDetection.Enabled = false;
        }
    }

}
