using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Interest.Models
{
    public class Pin
    {
        public int ID { get; set; }
        public InterestUser Publisher { get; set; }
        public string url { get; set; }
        public byte[] Image { get; set; }
        [NotMapped]
        public string ImageLink
        {
            get
            {
                return "/Interest/GetImage/" + ID.ToString();
            }
        }
        [MaxLength(250)]
        public string Notes { get; set; }


        public static byte[] ScaleImage(byte[] source, int maxWidth, int maxHeight)
        {
            var image = System.Drawing.Image.FromStream(new MemoryStream(source));

            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static byte[] GetImageByteArray(string ImageUrl)
        {
            var client = new WebClient();
            var imageArray = client.DownloadData(ImageUrl);
            var bytearraytoputindb = ScaleImage(imageArray, 100, 100);
            return bytearraytoputindb;
        }
    }
}