using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InputOutputManager
{
    public interface IFileOperations
    {
        Bitmap openFile(object sender, EventArgs e);

        void saveFile(object sender, EventArgs e, Bitmap resultBitmap);

    }
}
