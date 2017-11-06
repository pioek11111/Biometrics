using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class Projection : Form
    {
        public Projection(int[] h, int[] v)
        {
            InitializeComponent();
            var dataPointSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Histogram",
                Color = Color.Black,
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column,
                MarkerStyle = MarkerStyle.None,
                BorderWidth = 1,
                BorderColor = Color.White
            };

            for (int i = 0; i < h.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, h[i]);
            }

            for (int i = 0; i < v.Length; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i, v[i]);
            }

            //chart1.Series.Add(dataPointSeries);
            chart1.Series["Series1"].Color = Color.Black;
            chart2.Series["Series1"].Color = Color.Black;
            chart1.Series[0]["PointWidth"] = "1";
            chart2.Series["Series1"].ChartType = SeriesChartType.Bar;
        }

        private void Projection_Load(object sender, EventArgs e)
        {

        }
    }
}
