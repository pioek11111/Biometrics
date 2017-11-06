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
        private Image grayImage;
        private Image currentImageCp;

        public Form1()
        {
            InitializeComponent();
            original = new Bitmap(pictureBox1.Image);
            currentImageCp = new Bitmap(pictureBox1.Image);
            greyClick(this, null);
            pictureBox1.Image = new Bitmap(original);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

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
            grayImage = new Bitmap(pictureBox1.Image);
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
            pictureBox1.Image = new Bitmap(original);
            greyClick(this, null);
            pictureBox1.Image = new Bitmap(original);
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

        private void Histogram_Click(object sender, EventArgs e)
        {
            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];

            LockBitmap o = new LockBitmap((Bitmap)pictureBox1.Image);
            o.LockBits();
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = o.GetPixel(j, i);

                    R[p.R]++;
                    G[p.G]++;
                    B[p.B]++;
                }
            }
            o.UnlockBits();
            pictureBox1.Refresh();

            var h = new Histogram(R, G, B);
            h.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap o = new LockBitmap((Bitmap)pictureBox1.Image);
            o.LockBits();
            int minR = 255;
            int minG = 255;
            int minB = 255;
            int maxR = 0;
            int maxG = 0;
            int maxB = 0;
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = o.GetPixel(j, i);
                    minR = Math.Min(minR, p.R);
                    minG = Math.Min(minG, p.G);
                    minB = Math.Min(minB, p.B);
                    maxR = Math.Max(maxR, p.R);
                    maxG = Math.Max(maxG, p.G);
                    maxB = Math.Max(maxB, p.B);
                }
            }
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = o.GetPixel(j, i);

                    o.SetPixel(j, i, Color.FromArgb(255 * (p.R - minR) / (maxR - minR),
                                                    255 * (p.G - minG) / (maxG - minG),
                                                    255 * (p.B - minB) / (maxB - minB)));
                }
            }
            o.UnlockBits();
            pictureBox1.Refresh();
        }

        private void TrashHolding(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap lockBitmap = new LockBitmap(b);
            LockBitmap orig = new LockBitmap((Bitmap)grayImage);

            int label = trackBar2.Value;
            lockBitmap.LockBits();
            orig.LockBits();
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var colour = orig.GetPixel(j, i);
                    int newcolor = colour.R >= label ? 255 : 0;
                    lockBitmap.SetPixel(j, i, Color.FromArgb(newcolor, newcolor, newcolor));
                }
            }
            lockBitmap.UnlockBits();
            orig.UnlockBits();
            pictureBox1.Image = b;
            currentImageCp = new Bitmap(b);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void nonlinearContrastEdition(object sender, EventArgs e)
        {
            /*int val = trackBar3.Value;
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap lockBitmap = new LockBitmap(b);
            LockBitmap orig = new LockBitmap((Bitmap)original);

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
            pictureBox1.Image = b;*/
        }

        private void nonlinearNormalization_ValueChanged(object sender, EventArgs e)
        {
            //double alpha = Math.Log10(nonlinearNormalization.Value + 1.01);
            double alpha = nonlinearNormalization.Value;
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap n = new LockBitmap((Bitmap)b);
            LockBitmap orig = new LockBitmap((Bitmap)original);
            n.LockBits();
            orig.LockBits();
            double maxR = 0;
            double maxG = 0;
            double maxB = 0;
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = orig.GetPixel(j, i);
                    maxR = Math.Max(maxR, p.R);
                    maxG = Math.Max(maxG, p.G);
                    maxB = Math.Max(maxB, p.B);
                }
            }
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = orig.GetPixel(j, i);

                    n.SetPixel(j, i, Color.FromArgb((int)(255 * Math.Pow((p.R / maxR), alpha)),
                                                    (int)(255 * Math.Pow((p.G / maxG), alpha)),
                                                    (int)(255 * Math.Pow((p.B / maxB), alpha))));
                }
            }
            orig.UnlockBits();
            n.UnlockBits();
            pictureBox1.Image = b;
        }

        private void gaussianFilterTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int param = gaussianFilterTrackBar.Value;

            int[,] matrix = new int[,] { { 1, 1 , param, 1, 1 },
                                         { 1, param, param * param, param, 1 },
                                         { param, param * param, param * param * param, param * param, param} ,
                                         { 1, param, param * param, param, 1 },
                                         { 1, 1 , param, 1, 1 }, };
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sum += matrix[i, j];
                }
            }

            Bitmap bitmap = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap n = new LockBitmap((Bitmap)bitmap);
            LockBitmap orig = new LockBitmap((Bitmap)currentImageCp);
            n.LockBits();
            orig.LockBits();

            for (int i = 2; i < pictureBox1.Image.Height - 2; i++)
            {
                for (int j = 2; j < pictureBox1.Image.Width - 2; j++)
                {
                    var p = orig.GetPixel(j, i);
                    int r = 0, g = 0, b = 0;
                    for (int k = i - 2; k <= i + 2; k++)
                    {
                        for (int l = j - 2; l < j + 3; l++)
                        {
                            r += matrix[k - (i - 2), l - (j - 2)] * orig.GetPixel(l, k).R;
                            g += matrix[k - (i - 2), l - (j - 2)] * orig.GetPixel(l, k).G;
                            b += matrix[k - (i - 2), l - (j - 2)] * orig.GetPixel(l, k).B;
                        }
                    }
                    r /= sum;
                    g /= sum;
                    b /= sum;
                    n.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }
            orig.UnlockBits();
            n.UnlockBits();
            pictureBox1.Image = bitmap;
        }

        private void EdgeDetectionEvent(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap old = new LockBitmap((Bitmap)pictureBox1.Image);
            LockBitmap n = new LockBitmap((Bitmap)bitmap);
            old.LockBits();
            n.LockBits();

            for (int i = 1; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 1; j < pictureBox1.Image.Width; j++)
                {
                    var p1 = old.GetPixel(j, i);
                    var p2 = old.GetPixel(j, i - 1);
                    var p3 = old.GetPixel(j - 1, i);
                    var p4 = old.GetPixel(j - 1, i - 1);

                    int r = Math.Min(Math.Abs(p1.R - p2.R) + Math.Abs(p1.R - p3.R) + Math.Abs(p1.R - p4.R), 255);
                    int g = Math.Min(Math.Abs(p1.G - p2.G) + Math.Abs(p1.G - p3.G) + Math.Abs(p1.G - p4.G), 255);
                    int b = Math.Min(Math.Abs(p1.B - p2.B) + Math.Abs(p1.B - p3.B) + Math.Abs(p1.B - p4.B), 255);

                    n.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }

            old.UnlockBits();
            n.UnlockBits();
            pictureBox1.Image = bitmap;
            grayImage = bitmap;
            currentImageCp = new Bitmap(bitmap);
        }

        private void LaplacianClick(object sender, EventArgs e)
        {
            int param = gaussianFilterTrackBar.Value;

            int[,] matrix = new int[,] { { 0, -1 , 0 },
                                         { -1, 4, 1 },
                                         { 0, -1 , 0 } };


            Bitmap bitmap = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap n = new LockBitmap((Bitmap)bitmap);
            LockBitmap orig = new LockBitmap((Bitmap)currentImageCp);
            n.LockBits();
            orig.LockBits();

            for (int i = 1; i < pictureBox1.Image.Height - 1; i++)
            {
                for (int j = 1; j < pictureBox1.Image.Width - 1; j++)
                {
                    var p = orig.GetPixel(j, i);
                    int r = 0, g = 0, b = 0;
                    for (int k = i - 1; k <= i + 1; k++)
                    {
                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            r += matrix[k - (i - 1), l - (j - 1)] * orig.GetPixel(l, k).R;
                            g += matrix[k - (i - 1), l - (j - 1)] * orig.GetPixel(l, k).G;
                            b += matrix[k - (i - 1), l - (j - 1)] * orig.GetPixel(l, k).B;
                        }
                    }

                    r = (int)Truncate(r);
                    g = (int)Truncate(g);
                    b = (int)Truncate(b);
                    n.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }
            orig.UnlockBits();
            n.UnlockBits();
            pictureBox1.Image = bitmap;
        }

        private void Equalization_Click(object sender, EventArgs e)
        {
            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];

            Bitmap bitmap = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            LockBitmap n = new LockBitmap((Bitmap)bitmap);
            LockBitmap o = new LockBitmap((Bitmap)pictureBox1.Image);
            o.LockBits();
            n.LockBits();
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = o.GetPixel(j, i);
                    R[p.R]++;
                    G[p.G]++;
                    B[p.B]++;
                }
            }

            int cdfRMin = 0;
            int cdfGMin = 0;
            int cdfBMin = 0;

            for (int i = 1; i < 256; i++)
            {
                if (R[i - 1] > 0 && cdfRMin == 0)
                    cdfRMin = R[i - 1];
                if (G[i - 1] > 0 && cdfGMin == 0)
                    cdfGMin = G[i - 1];
                if (B[i - 1] > 0 && cdfBMin == 0)
                    cdfBMin = B[i - 1];

                R[i] += R[i - 1];
                G[i] += G[i - 1];
                B[i] += B[i - 1];
            }
            int NxM = pictureBox1.Image.Height * pictureBox1.Image.Width;
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = o.GetPixel(j, i);
                    int r = (int)(255 * (R[p.R] - cdfRMin) / (NxM - cdfRMin));
                    int g = (int)(255 * (G[p.G] - cdfGMin) / (NxM - cdfGMin));
                    int b = (int)(255 * (B[p.B] - cdfBMin) / (NxM - cdfBMin));
                    n.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }

            o.UnlockBits();
            n.UnlockBits();
            pictureBox1.Image = bitmap;            
        }

        private void Image_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                currentImageCp = new Bitmap(pictureBox1.Image);
                original = new Bitmap(pictureBox1.Image);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void Projection_Click(object sender, EventArgs e)
        {
            int[] horizontal = new int[pictureBox1.Image.Width];
            int[] vertical = new int[pictureBox1.Image.Width];

            LockBitmap o = new LockBitmap((Bitmap)pictureBox1.Image);
            o.LockBits();
            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = o.GetPixel(j, i);

                    if (p.R == 0)
                    {
                        horizontal[j]++;
                        vertical[i]++;
                    }
                }
            }
            o.UnlockBits();
            var projection = new Projection(horizontal, vertical);
            projection.Show();
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
