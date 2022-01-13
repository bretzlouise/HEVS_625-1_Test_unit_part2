﻿using System.Drawing;


namespace BLL.Interface
{
    public interface IImageFilters
    {
        Bitmap originalBmp { get; set; }
        Bitmap RainbowFilter(Bitmap bmp);
        Bitmap SwapFilter(Bitmap bmp);
        Bitmap BlackWhite(Bitmap bmp);
    }
}
