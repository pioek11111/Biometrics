using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private Image original;

        public Form1()
        {
            InitializeComponent();
            original = pictureBox1.Image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // change pictureBox on negative
        private void greyClick(object sender, EventArgs e)
        {
            LockBitmap o = new LockBitmap((Bitmap)pictureBox1.Image);            
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap lockBitmap = new LockBitmap(b);
            lockBitmap.LockBits();
            o.LockBits();

            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = o.GetPixel(j, i);
                    int color = (p.R + p.B + p.G) / 3;
                    lockBitmap.SetPixel(j, i, Color.FromArgb(color, color, color));
                }
            }
            o.UnlockBits();
            lockBitmap.UnlockBits();
            pictureBox1.Image = b;
        }

        private void negativeClick(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = ((Bitmap)pictureBox1.Image).GetPixel(j, i);

                    b.SetPixel(j, i, Color.FromArgb(255 - p.R, 255 - p.G, 255 - p.B));
                }
            }
            pictureBox1.Image = b;
        }

        private void lightening(int alpha)
        {
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            //LockBitmap bLock = new LockBitmap(b);
            LockBitmap o = new LockBitmap((Bitmap)pictureBox1.Image);
            o.LockBits();
            //bLock.LockBits();
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = o.GetPixel(j, i);

                    o.SetPixel(j, i, Color.FromArgb(Math.Max(0, Math.Min(p.R + alpha, 255)),
                                                    Math.Max(0, Math.Min(p.G + alpha, 255)),
                                                    Math.Max(0, Math.Min(p.B + alpha, 255))));
                }
            }
            //bLock.UnlockBits();
            o.UnlockBits();            
            pictureBox1.Refresh();
        }

        private void contrast(int contrast)
        {
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap lockBitmap = new LockBitmap(b);
            LockBitmap orig = new LockBitmap((Bitmap)original);

            float factor = (259 * (contrast + 255)) / (255 * (259 - contrast));
            lockBitmap.LockBits();
            orig.LockBits();
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var colour = orig.GetPixel(j, i);
                    float newRed = Truncate(factor * (colour.R - 128) + 128);
                    float newGreen = Truncate(factor * (colour.G - 128) + 128);
                    float newBlue = Truncate(factor * (colour.B - 128) + 128);

                    lockBitmap.SetPixel(j, i, Color.FromArgb((int)newRed, (int)newGreen, (int)newBlue));
                }
            }
            lockBitmap.UnlockBits();
            orig.UnlockBits();
            pictureBox1.Image = b;
        }

        private float Truncate(float value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;
            return value;
        }

        private void originalClick(object sender, EventArgs e)
        {
            pictureBox1.Image = original;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lightening(10);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lightening(-10);
        }

        private void trackBar1_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            contrast(trackBar1.Value);
        }
    }

    public class LockBitmap
    {
        Bitmap source = null;
        IntPtr Iptr = IntPtr.Zero;
        BitmapData bitmapData = null;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LockBitmap(Bitmap source)
        {
            this.source = source;
        }

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void LockBits()
        {
            try
            {
                // Get width and height of bitmap
                Width = source.Width;
                Height = source.Height;

                // get total locked pixels count
                int PixelCount = Width * Height;

                // Create rectangle to lock
                Rectangle rect = new Rectangle(0, 0, Width, Height);

                // get source bitmap pixel format size
                Depth = System.Drawing.Bitmap.GetPixelFormatSize(source.PixelFormat);

                // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                if (Depth != 8 && Depth != 24 && Depth != 32)
                {
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                }

                // Lock bitmap and return bitmap data
                bitmapData = source.LockBits(rect, ImageLockMode.ReadWrite,
                                             source.PixelFormat);

                // create byte array to copy pixel values
                int step = Depth / 8;
                Pixels = new byte[PixelCount * step];
                Iptr = bitmapData.Scan0;

                // Copy data from pointer to array
                Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void UnlockBits()
        {
            try
            {
                // Copy data from byte array to pointer
                Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);

                // Unlock bitmap data
                source.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y)
        {
            Color clr = Color.Empty;

            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            if (Depth == 32) // For 32 bpp get Red, Green, Blue and Alpha
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                byte a = Pixels[i + 3]; // a
                clr = Color.FromArgb(a, r, g, b);
            }
            if (Depth == 24) // For 24 bpp get Red, Green and Blue
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                clr = Color.FromArgb(r, g, b);
            }
            if (Depth == 8)
            // For 8 bpp get color value (Red, Green and Blue values are the same)
            {
                byte c = Pixels[i];
                clr = Color.FromArgb(c, c, c);
            }
            return clr;
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (Depth == 32) // For 32 bpp set Red, Green, Blue and Alpha
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
                Pixels[i + 3] = color.A;
            }
            if (Depth == 24) // For 24 bpp set Red, Green and Blue
            {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
            }
            if (Depth == 8)
            // For 8 bpp set color value (Red, Green and Blue values are the same)
            {
                Pixels[i] = color.B;
            }
        }
    }
}
