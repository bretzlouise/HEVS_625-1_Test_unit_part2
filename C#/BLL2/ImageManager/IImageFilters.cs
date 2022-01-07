﻿using System.Drawing;

namespace BLL
{
    public interface IImageFilters
    {
        Bitmap RainbowFilter(Bitmap bmp);
        Bitmap SwapFilter(Bitmap bmp);
        Bitmap BlackWhite(Bitmap bmp);

    }
}
