using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = ((Bitmap)pictureBox1.Image).GetPixel(j, i);
                    int color = (p.R + p.B + p.G) / 3;
                    b.SetPixel(j, i, Color.FromArgb(color, color, color));
                }
            }
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

            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var p = ((Bitmap)pictureBox1.Image).GetPixel(j, i);

                    b.SetPixel(j, i, Color.FromArgb(Math.Max(0, Math.Min(p.R + alpha, 255)),
                                                    Math.Max(0, Math.Min(p.G + alpha, 255)),
                                                    Math.Max(0, Math.Min(p.B + alpha, 255))));
                }
            }
            pictureBox1.Image = b;
        }

        private void contrast(int contrast)
        {
            Bitmap b = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            float factor = (259 * (contrast + 255)) / (255 * (259 - contrast));

            for (int i = 0; i < pictureBox1.Image.Height; i++)
            {
                for (int j = 0; j < pictureBox1.Image.Width; j++)
                {
                    var colour = ((Bitmap)pictureBox1.Image).GetPixel(j, i);
                    float newRed = Truncate(factor * (colour.R - 128) + 128);
                    float newGreen = Truncate(factor * (colour.G - 128) + 128);
                    float newBlue = Truncate(factor * (colour.B - 128) + 128);

                    b.SetPixel(j, i, Color.FromArgb((int)newRed, (int)newGreen, (int)newBlue));
                }
            }
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

        private void contrastClick(object sender, EventArgs e)
        {
            int c = int.Parse(textBox1.Text);
            contrast(c);
        }
    }
}
