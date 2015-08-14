using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Interest.Models
{
    public class Pin
    {
        public int ID { get; set; }
        public InterestUser Publisher { get; set; }
        public string url { get; set; }
        public byte[] Image { get; set; }
        [MaxLength(250)]
        public string Notes { get; set; }

        public static byte[] ResizeImage(byte[] source, int width, int height)
        {
            var image = System.Drawing.Image.FromStream(new MemoryStream(source));
            var ratioX = (double)width / image.Width;
            var ratioY = (double)height / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);
            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}