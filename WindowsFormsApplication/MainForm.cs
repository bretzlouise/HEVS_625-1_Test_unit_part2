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
        //private Bitmap edited = null;
        ////private Bitmap originalBitmap = null;
        //private Bitmap modifiedBitmap = null;
        //private Bitmap previewBitmap = null;
        //private Bitmap resultBitmap = null;
        //private Bitmap filterBitmap = null;
        //private bool filterButtonEnabled = false;
        //private bool dropListEnabled = false;


        public MainForm()
        {
            InitializeComponent();

            //file = new FileManager();
            file = new FileOperationsManager();

            //UpdateButtons();
            //cmbEdgeDetection.SelectedIndex = 0;
            //btnSaveNewImage.Enabled = false; 
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            
            originalBitmap = file.openFile(sender,e);

            //modifiedBitmap = originalBitmap;
            picPreview.Image = originalBitmap;

            try
            {
                var initialImageSize = picPreview.Image.Size;
                var displaySize = picPreview.ClientSize;
                picPreview.Image = canvasManager.copyToSquareCanvas(originalBitmap, 415);
                picPreview.SizeMode = initialImageSize.Width > displaySize.Width || initialImageSize.Height > displaySize.Height ?
                PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
            }
            catch (NullReferenceException) { }
        }
        

        //button that calls method to save modified image in local storage
        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Dans MainForm");

            file.saveFile(sender,e,resultBitmap);           
        }

    }
}
