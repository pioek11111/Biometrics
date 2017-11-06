using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class Histogram : Form
    {
        public Histogram(int[] R, int[] G, int[] B)
        {
            InitializeComponent();
            var dataPointSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Histogram",
                Color = Color.Red,
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column,
                MarkerStyle = MarkerStyle.None,
                BorderWidth = 1,
                BorderColor = Color.White
            };

            for (int i = 0; i < R.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, R[i]);
                chart1.Series["Series2"].Points.AddXY(i, G[i]);
                chart1.Series["Series3"].Points.AddXY(i, B[i]);
            }

            //chart1.Series.Add(dataPointSeries);
            chart1.Series["Series1"].Color = Color.Red;
            chart1.Series["Series2"].Color = Color.Green;
            chart1.Series["Series3"].Color = Color.Blue;
            chart1.Series[0]["PointWidth"] = "1";
        }

        private void Histogram_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
