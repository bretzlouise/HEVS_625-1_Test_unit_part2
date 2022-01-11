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

        IImageFilters imageFilters = new ImageFilters();
        IEdgeDetection edgeFilters = new EdgeDetection();
        ICanvasManager canvasManager = new CanvasManager();


        private Bitmap originalBitmap = null;
        private Bitmap forResetBitmap = null;

        //tempBitmap is used is case no image filter is applied so you can still apply an edge filter
        private Bitmap tempBitmap = null;
        private Bitmap resultBitmap = null;

        //private FileManager file = null;
        //private FileManager file = new FileManager();

        private FileOperationsManager file = null;

        ////Nos anciennes variables
        private Bitmap edited = null;
        ////private Bitmap originalBitmap = null;
        private Bitmap modifiedBitmap = null;
        private Bitmap previewBitmap = null;
        //private Bitmap resultBitmap = null;
        //private Bitmap filterBitmap = null;
        private bool filterButtonEnabled = false;
        private bool dropListEnabled = false;


        public MainForm()
        {
            InitializeComponent();

            //file = new FileManager();
            

            //UpdateButtons();
            cmbEdgeDetection.SelectedIndex = 0;
            btnSaveNewImage.Enabled = false;

            file = new FileOperationsManager();
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            
            originalBitmap = file.openFile(sender,e);

            modifiedBitmap = originalBitmap;
            picPreview.Image = originalBitmap;

            try
            {
                var initialImageSize = picPreview.Image.Size;
                var displaySize = picPreview.ClientSize;
                picPreview.Image = canvasManager.copyToSquareCanvas(originalBitmap, 415);
                picPreview.SizeMode = initialImageSize.Width > displaySize.Width || initialImageSize.Height > displaySize.Height ?
                PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;

                ApplyEdgeDetection(true);

                
            }
            catch (NullReferenceException) { }
        }
        

        //button that calls method to save modified image in local storage
        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {
            
            file.saveFile(sender,e, modifiedBitmap);           
        }

        

        private void FilterButtons(object sender, EventArgs e)
        {
            btnSaveNewImage.Enabled = true;
            dropListEnabled = true;
            cmbEdgeDetection.Enabled = dropListEnabled;

            string button = sender.ToString();
            string filter1 = "System.Windows.Forms.Button, Text: None";
            string filter2 = "System.Windows.Forms.Button, Text: Rainbow";

            if (button.Equals(filter1))
            {
                picPreview.Image = originalBitmap;
                modifiedBitmap = originalBitmap;
            }
            else
            {
                if (button.Equals(filter2))
                {
                    Console.WriteLine("Je suis dans Rainbow");
                    edited = imageFilters.RainbowFilter(modifiedBitmap);
                }
                else
                {
                    edited = imageFilters.SwapFilter(modifiedBitmap);
                }
                
                modifiedBitmap = edited;
                //resultBitmap = modifiedBitmap;
                picPreview.Image = modifiedBitmap;
            }
        }


        private void ApplyEdgeDetection(bool preview)
        {

            //CONTROLER ET NETTOYER LES LIGNES -> 133
            //if (modifiedBitmap == null || cmbEdgeDetection.SelectedIndex == -1)
            if (cmbEdgeDetection.SelectedIndex == -1)
                {
                if (modifiedBitmap == null)
                {
                }
                return;
            }


            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = (Bitmap)picPreview.Image;
                Console.WriteLine("Je suis dans le true");
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
            cmbEdgeDetection.Enabled = dropListEnabled;
        }

        private void NeighbourCountValueChangedEventHandler(object sender, EventArgs e)
        {
            ApplyEdgeDetection(true);
        }
    }
}
