using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace DesktopApp
{
    public static class BarcodeGenrator
    {

        public static byte[] GenerateBarcodeImage(string productName, string encryptedPrice)
        {
            int labelWidth = (int)(38 * 11.81);   // ≈ 448 px
            int labelHeight = (int)(12 * 11.81);  // ≈ 142 px
            int barcodeWidth = (int)(labelWidth * 0.85);
            int barcodeHeight = (int)(labelHeight * 0.45); // زودنا الارتفاع شوية

            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = barcodeWidth,
                    Height = barcodeHeight,
                    Margin = 0,
                    PureBarcode = true
                }
            };
            var bitMatrix = barcodeWriter.Encode(encryptedPrice);

            using (var bitmap = new Bitmap(labelWidth, labelHeight))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                // Draw Top Text (معرض الطنطاوي ...)
                using (var font = new Font("Arial", 14, FontStyle.Bold))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
                {
                    graphics.DrawString("معرض الطنطاوي للأجهزة الكهربائية والأدوات المنزلية", font, Brushes.Black,
                        new RectangleF(0, 0, labelWidth, 30), sf);
                }

                // Draw Barcode
                int barcodeX = (labelWidth - bitMatrix.Width) / 2;
                int barcodeY = 35; // After top text

                for (int x = 0; x < bitMatrix.Width; x++)
                {
                    for (int y = 0; y < bitMatrix.Height; y++)
                    {
                        if (bitMatrix[x, y])
                        {
                            int px = barcodeX + x;
                            int py = barcodeY + y;
                            if (px >= 0 && px < labelWidth && py >= 0 && py < labelHeight)
                                bitmap.SetPixel(px, py, Color.Black);
                        }
                    }
                }

                // Draw Bottom Text (اسم المنتج)
                using (var font = new Font("Arial", 12, FontStyle.Bold))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
                {
                    graphics.DrawString(productName, font, Brushes.Black,
                        new RectangleF(0, barcodeY + barcodeHeight + 5, labelWidth, 25), sf);
                }

                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }


    }
}
