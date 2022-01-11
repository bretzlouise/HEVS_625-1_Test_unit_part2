using InputOutputManager;
using System;
using System.Drawing;

namespace BLL.Tools
{
    public class FileManager : InputOutputManager.IImageManager
    {
        bool imageSaved;
        InputOutputManager.IImageManager imageManager;


        //public Bitmap edited = null;
        //public Bitmap originalBitmap = null;
        //public Bitmap modifiedBitmap = null;
        //public Bitmap previewBitmap = null;
        //public Bitmap resultBitmap = null;
        //public Bitmap filterBitmap = null;
        //public bool filterButtonEnabled = false;
        //public bool dropListEnabled = false;


        public FileManager()
        {
            this.imageManager = new FileManager();
        }

        public FileManager(IImageManager iFileManager)
        {
            this.imageManager = iFileManager;
        }
        //Use the interface to implement reusable methods in the business layer
        public Bitmap loadFile()
        {
            try
            {
                return imageManager.loadFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void saveImage(Bitmap savedImage)
        {
            try
            {
                imageManager.saveImage(savedImage);
                imageSaved = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                imageSaved = false;
            }
        }

        //getter for the bool if the image is saved or not
        public bool getImageSaved()
        {
            return this.imageSaved;
        }

        public void ApplyFilter(bool preview)
        {
        //    //if (previewBitmap == null || cmbEdgeDetection.SelectedIndex == -1)
        //    //{
        //    //    return;
        //    //}

        //    Bitmap selectedSource = null;
        //    Bitmap bitmapResult = null;


        //    if (preview == true)
        //    {
        //        selectedSource = (Bitmap)picPreview.Image;
        //    }
        //    else
        //    {
        //        selectedSource = originalBitmap;
        //    }

        //    if (selectedSource != null)
        //    {
        //        filterButtonEnabled = false;

        //        if (cmbEdgeDetection.SelectedItem.ToString() == "None")
        //        {
        //            filterButtonEnabled = true;
        //            dropListEnabled = false;
        //            modifiedBitmap = originalBitmap;
        //            picPreview.Image = originalBitmap;
        //        }
        //        else if (cmbEdgeDetection.SelectedItem.ToString() == "Sobel 3x3")
        //        {
        //            bitmapResult = selectedSource.Sobel3x3Filter(false);
        //        }

        //        else if (cmbEdgeDetection.SelectedItem.ToString() == "Prewitt")
        //        {
        //            bitmapResult = selectedSource.PrewittFilter(false);
        //        }

        //        else if (cmbEdgeDetection.SelectedItem.ToString() == "Kirsch")
        //        {
        //            bitmapResult = selectedSource.KirschFilter(false);
        //        }


        //        UpdateButtons();
        //    }

        //    if (bitmapResult != null)
        //    {
        //        if (preview == true)
        //        {
        //            picPreview.Image = bitmapResult;
        //        }
        //        else
        //        {
        //            resultBitmap = (Bitmap)picPreview.Image;
        //        }
        //    }
        }
    }
}
