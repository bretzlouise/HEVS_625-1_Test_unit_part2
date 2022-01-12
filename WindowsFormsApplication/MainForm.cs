using System;
using System.Drawing;
using System.Windows.Forms;
using BLL.Interface;
using BLL.ModificationImage;
using BLL.Tools;

namespace WindowsFormsApplication
{
    public partial class MainForm : Form
    {
        //Call to the interfaces
        IImageFilters imageFilters = new ImageFilters();
        IEdgeDetection edgeFilters = new EdgeDetection();
        ICanvasManager canvasManager = new CanvasManager();

        //Call to the FileOperationsManager
        private FileOperationsManager file = null;

        //Variables
        private Bitmap originalBitmap = null;
        private Bitmap edited = null;
        private Bitmap modifiedBitmap = null;
        private bool filterButtonEnabled = false;
        private bool dropListEnabled = false;


        public MainForm()
        {
            InitializeComponent();
            UpdateButtons();
            cmbEdgeDetection.SelectedIndex = 0;
            btnSaveNewImage.Enabled = false;

            file = new FileOperationsManager();
        }

        //Get a new picture
        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {

            filterButtonEnabled = false;
            UpdateButtons();
            originalBitmap = file.openFile();


            modifiedBitmap = originalBitmap;
            picPreview.Image = originalBitmap;

            try
            {
                var initialImageSize = picPreview.Image.Size;
                var displaySize = picPreview.ClientSize;
                picPreview.Image = canvasManager.copyToSquareCanvas(originalBitmap, 415);
                picPreview.SizeMode = initialImageSize.Width > displaySize.Width || initialImageSize.Height > displaySize.Height ?
                PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
              

                EnableButtons();
            }
            catch (NullReferenceException) { }
        }
        

        //Save the picture
        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {          
            file.saveFile(modifiedBitmap);           
        }

        //Enable filters buttons
        private void EnableButtons()
        {
            filterButtonEnabled = true;
            UpdateButtons();
        }

        //Use one or more filters
        private void ApplyFilters(object sender, EventArgs e)
        {
            btnSaveNewImage.Enabled = true;
            dropListEnabled = true;
            cmbEdgeDetection.Enabled = dropListEnabled;

            string button = sender.ToString();
            string filter1 = "System.Windows.Forms.Button, Text: None";
            string filter2 = "System.Windows.Forms.Button, Text: Rainbow";
            string filter3 = "System.Windows.Forms.Button, Text: Swap";
            string filter4 = "System.Windows.Forms.Button, Text: Black and White";

            if (button.Equals(filter1))
            {
                picPreview.Image = originalBitmap;
                modifiedBitmap = originalBitmap;
            }
            else
            {
                if (button.Equals(filter2))
                {
                    edited = imageFilters.RainbowFilter(modifiedBitmap);
                }
                if (button.Equals(filter3))
                {
                    edited = imageFilters.SwapFilter(modifiedBitmap);
                }
                if (button.Equals(filter4))
                {
                    edited = imageFilters.BlackWhite(modifiedBitmap);
                }
                
                modifiedBitmap = edited;
                picPreview.Image = modifiedBitmap;
            }
        }

        //Apply Edge detection on the picture
        private void ApplyEdgeDetection(bool preview)
        {
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
                    bitmapResult = edgeFilters.Sobel3x3Filter(modifiedBitmap, false);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Prewitt")
                {
                    bitmapResult = edgeFilters.PrewittFilter(modifiedBitmap, false);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Kirsch")
                {
                    bitmapResult = edgeFilters.KirschFilter(modifiedBitmap, false);
                }
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    picPreview.Image = bitmapResult;
                    modifiedBitmap = bitmapResult;
                }
                else
                {
                    modifiedBitmap = (Bitmap)picPreview.Image;
                }
            }
        }


        //Method to enable the buttons and dropdownlist
        private void UpdateButtons()
        {
            buttonFilter1.Enabled = filterButtonEnabled;
            buttonFilter2.Enabled = filterButtonEnabled;
            buttonFilter3.Enabled = filterButtonEnabled;
            buttonFilter4.Enabled = filterButtonEnabled;
            cmbEdgeDetection.Enabled = dropListEnabled;
        }

        //Method used to enable EdgeDetection when Filters are on
        private void NeighbourCountValueChangedEventHandler(object sender, EventArgs e)
        {
            ApplyEdgeDetection(true);
        }
    }
}
