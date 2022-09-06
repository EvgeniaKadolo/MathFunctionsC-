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


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "y = x * a + b";
        }

        Chart myChart = new Chart();
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a;
                double b;
                double c;

                myChart.ChartAreas.Clear();
                myChart.Series.Clear();

                myChart.Parent = this;
                myChart.Dock = DockStyle.Top;
                myChart.ChartAreas.Add(new ChartArea("Math functions"));
                Series mySeriesOfPoint = new Series();
                mySeriesOfPoint.Color = Color.Red;
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                mySeriesOfPoint.ChartArea = "Math functions";

                if (textBox3.Text != "")
                {
                    double x = double.Parse(textBox3.Text);
                    mySeriesOfPoint.ChartType = SeriesChartType.Point;
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            a = double.Parse(textBox1.Text);
                            b = double.Parse(textBox2.Text);
                            mySeriesOfPoint.Points.AddXY(x, x * a + b);
                            break;
                        case 1:
                            a = double.Parse(textBox1.Text);
                            b = double.Parse(textBox2.Text);
                            c = double.Parse(textBox4.Text);
                            mySeriesOfPoint.Points.AddXY(x, a * Math.Sin(x * b) + c);
                            break;
                        case 2:
                            a = double.Parse(textBox1.Text);
                            b = double.Parse(textBox2.Text);
                            c = double.Parse(textBox4.Text);
                            mySeriesOfPoint.Points.AddXY(x, a * Math.Cos(x * b + c));
                            break;
                        case 3:
                            a = double.Parse(textBox1.Text);
                            b = double.Parse(textBox2.Text);
                            c = double.Parse(textBox4.Text);
                            mySeriesOfPoint.Points.AddXY(x, a * Math.Tan(x * b) + c);
                            break;
                        case 4:
                            a = double.Parse(textBox1.Text);
                            b = double.Parse(textBox2.Text);
                            c = double.Parse(textBox4.Text);
                            mySeriesOfPoint.Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                            break;
                        case 5:
                            a = double.Parse(textBox1.Text);
                            b = double.Parse(textBox2.Text);
                            mySeriesOfPoint.Points.AddXY(x, b * Math.Pow(x, a));
                            break;
                        case 6:
                            a = double.Parse(textBox1.Text);
                            b = double.Parse(textBox2.Text);
                            mySeriesOfPoint.Points.AddXY(x, Math.Pow(a, x + b));
                            break;
                        case 7:
                            a = double.Parse(textBox1.Text);
                            b = double.Parse(textBox2.Text);
                            if ((a < 7 && a > 0 && b == 1) || (b < 3 && b > -1 && a == 1))
                                mySeriesOfPoint.Points.AddXY(x, Math.Pow((Math.Sin(x) + a * x) / (x - Math.Pow(x, 1 / 2) + 1), b / x));
                            break;
                        default:
                            break;
                    }
                    myChart.Series.Add(mySeriesOfPoint);
                }
                else
                {
                    for (double x = -Math.PI; x <= Math.PI; x += Math.PI / 100.0)
                    {
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                a = double.Parse(textBox1.Text);
                                b = double.Parse(textBox2.Text);
                                mySeriesOfPoint.Points.AddXY(x, x * a + b);
                                break;
                            case 1:
                                a = double.Parse(textBox1.Text);
                                b = double.Parse(textBox2.Text);
                                c = double.Parse(textBox4.Text);
                                mySeriesOfPoint.Points.AddXY(x, a * Math.Sin(x * b) + c);
                                break;
                            case 2:
                                a = double.Parse(textBox1.Text);
                                b = double.Parse(textBox2.Text);
                                c = double.Parse(textBox4.Text);
                                mySeriesOfPoint.Points.AddXY(x, a * Math.Cos(x * b + c));
                                break;
                            case 5:
                                a = double.Parse(textBox1.Text);
                                b = double.Parse(textBox2.Text);
                                mySeriesOfPoint.Points.AddXY(x, b * Math.Pow(x, a));
                                break;
                            case 6:
                                a = double.Parse(textBox1.Text);
                                b = double.Parse(textBox2.Text);
                                mySeriesOfPoint.Points.AddXY(x, Math.Pow(a, x + b));
                                break;
                            case 7:
                                a = double.Parse(textBox1.Text);
                                b = double.Parse(textBox2.Text);
                                if((a < 7 && a > 0 && b == 1) || (b < 3 && b > -1 && a == 1))
                                    mySeriesOfPoint.Points.AddXY(x, Math.Pow((Math.Sin(x) + a * x) / (x - Math.Pow(x, 1 / 2) + 1), b / x));
                                break;
                            default:
                                break;
                        }
                    }
                    myChart.Series.Add(mySeriesOfPoint);
                    if(comboBox1.SelectedIndex == 3) funcTan();
                    if(comboBox1.SelectedIndex == 4) funcCtg();
                }
            }
            catch
            {}
        }

        private void funcTan()
        {
            var a = double.Parse(textBox1.Text);
            var b = double.Parse(textBox2.Text);
            var c = double.Parse(textBox4.Text);

            List<Series> series = new List<Series>(4);

            for (int i = 0; i < series.Capacity; i++)
            {
                series.Add(new Series());
                series[i].Color = Color.Red;
                series[i].ChartType = SeriesChartType.Line;
                series[i].ChartArea = "Math functions";
            }

            if(b < 0)
            {
                for (double x = Math.PI / 2.1 / b; x <= -Math.PI / 2.08 / b; x += Math.PI / 10000.0)
                {
                    series[0].Points.AddXY(x, a * Math.Tan(x * b) + c);
                }
                for (double y = 3 * Math.PI / 2.035 / b; y <= Math.PI / 1.93 / b; y += Math.PI / 10000.0)
                {
                    series[1].Points.AddXY(y, a * Math.Tan(y * b) + c);
                }
                for (double y = 5 * Math.PI / 2.022 / b; y <= 3 * Math.PI / 1.975 / b; y += Math.PI / 10000.0)
                {
                    series[2].Points.AddXY(y, a * Math.Tan(y * b) + c);
                }
                for (double y = 7 * Math.PI / 2.1 / b; y <= 5 * Math.PI / 1.985 / b; y += Math.PI / 10000.0)
                {
                    series[3].Points.AddXY(y, a * Math.Tan(y * b) + c);
                }
            }
            else if(b > 0)
            {
                for (double x = -Math.PI / 2.08 / b; x <= Math.PI / 2.1 / b; x += Math.PI / 10000.0)
                {
                    series[0].Points.AddXY(x, a * Math.Tan(x * b) + c);
                }
                for (double y = Math.PI / 1.93 / b; y <= 3 * Math.PI / 2.035 / b; y += Math.PI / 10000.0)
                {
                    series[1].Points.AddXY(y, a * Math.Tan(y * b) + c);
                }
                for (double y = 3 * Math.PI / 1.975 / b; y <= 5 * Math.PI / 2.022 / b; y += Math.PI / 10000.0)
                {
                    series[2].Points.AddXY(y, a * Math.Tan(y * b) + c);
                }
                for (double y = 5 * Math.PI / 1.985 / b; y <= 7 * Math.PI / 2.1 / b; y += Math.PI / 10000.0)
                {
                    series[3].Points.AddXY(y, a * Math.Tan(y * b) + c);
                }
            }
            else
            {
                for (double x = -Math.PI / 2.08; x <= Math.PI / 2.1; x += Math.PI / 10000.0)
                {
                    series[0].Points.AddXY(x, a * Math.Tan(x * b) + c);
                }
            }
            myChart.Series.Add(series[0]);
            myChart.Series.Add(series[1]);
            myChart.Series.Add(series[2]);
            myChart.Series.Add(series[3]);
        }

        private void funcCtg()
        {
            var a = double.Parse(textBox1.Text);
            var b = double.Parse(textBox2.Text);
            var c = double.Parse(textBox4.Text);

            List<Series> series = new List<Series>(4);

            for (int i = 0; i < series.Capacity; i++)
            {
                series.Add(new Series());
                series[i].Color = Color.Red;
                series[i].ChartType = SeriesChartType.Line;
                series[i].ChartArea = "Math functions";
            }

            if (b > 0)
            {
                for (double x = (-0.99 * Math.PI - c) / b; x <= (-0.01 - c) / b; x += Math.PI / 10000.0)
                {
                    series[0].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
                for (double x = (0.01 - c) / b; x <= (Math.PI - 0.01 - c) / b; x += Math.PI / 10000.0)
                {
                    series[1].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
                for (double x = (3.151 - c) / b; x <= (6.273 - c) / b; x += Math.PI / 10000.0)
                {
                    series[2].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
                for (double x = (6.292 - c) / b; x <= (9.415 - c) / b; x += Math.PI / 10000.0)
                {
                    series[3].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
            }
            else if (b < 0)
            {
                for (double x = (-0.01 - c) / b; x <= (-0.99 * Math.PI - c) / b; x += Math.PI / 10000.0)
                {
                    series[0].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
                for (double x = (Math.PI - 0.01 - c) / b; x <= (0.01 - c) / b; x += Math.PI / 10000.0)
                {
                    series[1].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
                for (double x = (6.273 - c) / b; x <= (3.151 - c) / b; x += Math.PI / 10000.0)
                {
                    series[2].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
                for (double x = (9.415 - c) / b; x <= (6.292 - c) / b; x += Math.PI / 10000.0)
                {
                    series[3].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
            }
            else
            {
                for (double x = -0.99 * Math.PI - c; x <= -0.01 - c; x += Math.PI / 10000.0)
                {
                    series[0].Points.AddXY(x, a * 1 / Math.Tan(x * b + c));
                }
            }
            
            myChart.Series.Add(series[0]);
            myChart.Series.Add(series[1]);
            myChart.Series.Add(series[2]);
            myChart.Series.Add(series[3]);
        }
    }
}