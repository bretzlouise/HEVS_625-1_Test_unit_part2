using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;

namespace TestImageEdgeDetection
{
    public static class TestMethods
    {

        // Method that compares each pixel between two bitmaps 
        public static bool CompareImages(Bitmap a, Bitmap b)
        {
            string a_ref, b_ref;

            // Condition of checking the height and width of each picture
            if (a.Width != b.Width || a.Height != b.Height)
            {
                return false;
            }

            // Loop to reach one pixel after another
            for (int i = 0; i < a.Width; i++)
            {
                for (int j = 0; j < a.Height; j++)
                {
                    a_ref = a.GetPixel(i, j).ToString();
                    b_ref = b.GetPixel(i, j).ToString();

                    //Condition if not equal return false
                    if (!a_ref.Equals(b_ref))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
      
    }
}
