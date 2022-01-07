/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using BLL;

namespace Presentation
{
    public partial class MainForm : Form
    {

        private Bitmap edited = null;
        private Bitmap originalBitmap = null;
        private Bitmap modifiedBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        private Bitmap filterBitmap = null;
        private bool filterButtonEnabled = false;
        private bool dropListEnabled = false;

        IReadWriteFileApplyFilter rw = new ReadWriteFileApplyFilter();
        IPresentationManager p = new PresentationManager();
        IImageFilters imageFilters = new ImageFilters();
        IEdgeDetection edgeFilters = new EdgeDetection();
        ICanvasManager canvasManager = new CanvasManager();

        public MainForm()
        {
            InitializeComponent();
           // UpdateButtons(); 
            cmbEdgeDetection.SelectedIndex = 0;
            //btnSaveNewImage.Enabled = false;
        }



        //Method to load a new picture
        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            //Get LoadImage method from interface
            rw.LoadImage(sender, e, picPreview);
            //p.ResetControlsEnableCheckboxes(btnSaveNewImage, btnOpenOriginal);
        }

        //Method to save a picture
        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {
            //Get SaveImage method from interface
            rw.SaveImage(sender, e);
        }

        //Method to apply edge detection with a dropdownlist
        private void ApplyFilter(bool preview)
        {
            if (previewBitmap == null || cmbEdgeDetection.SelectedIndex == -1)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;


            if (preview == true)
            {
                selectedSource = (Bitmap)picPreview.Image;
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                filterButtonEnabled = false;

                if (cmbEdgeDetection.SelectedItem.ToString() == "None")
                {
                    filterButtonEnabled = true;
                    dropListEnabled = false;
                    modifiedBitmap = originalBitmap;
                    picPreview.Image = originalBitmap;
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Sobel 3x3")
                {
                    bitmapResult = selectedSource.Sobel3x3Filter(false);
                }
              
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Prewitt")
                {
                    bitmapResult = selectedSource.PrewittFilter(false);
                }
               
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Kirsch")
                {
                    bitmapResult = selectedSource.KirschFilter(false);
                }
 

                UpdateButtons();
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    picPreview.Image = bitmapResult;
                }
                else
                {
                    resultBitmap = (Bitmap)picPreview.Image;
                }
            }
        }


        private void NeighbourCountValueChangedEventHandler(object sender, EventArgs e)
        {
            ApplyFilter(true);         
        }

        //Method to choose a filter between none and 2 others (0,1,2)
        private void FilterButtons(object sender, EventArgs e)
        {
            btnSaveNewImage.Enabled = true;

            dropListEnabled = true;
            cmbEdgeDetection.Enabled = dropListEnabled;

            string button = sender.ToString();
            string filter1 = "System.Windows.Forms.Button, Text: None";
            string filter2 = "System.Windows.Forms.Button, Text: Rainbow";
 
            if (button.Equals(filter1)){
                picPreview.Image = originalBitmap;
                modifiedBitmap = originalBitmap;
            }
            else {

                //var mf = new Filters();
                var mf = new ImageFilters();

                if (button.Equals(filter2))
                {
                    edited = mf.RainbowFilter(modifiedBitmap);
                }
                else
                {
                    //edited = mf.ApplyFilterSwap(modifiedBitmap); 
                    edited = mf.SwapFilter(modifiedBitmap);
                }
                modifiedBitmap = edited;
                resultBitmap = modifiedBitmap;
                picPreview.Image = modifiedBitmap;
            }       

        }

       /* //Method to enable the buttons and dropdownlist
        private void UpdateButtons()
        {
            buttonFilter1.Enabled = filterButtonEnabled;
            buttonFilter2.Enabled = filterButtonEnabled;
            buttonFilter3.Enabled = filterButtonEnabled;
            cmbEdgeDetection.Enabled = dropListEnabled;
        }*/





    }
}
