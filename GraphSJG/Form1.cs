using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphSJG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Graph(int Interval, decimal a,decimal b, decimal c)
        {
            int ic = Interval;            
            int x = 400;
            int y = 400;
            int px = -Interval;
            Point[] points = new Point[Interval*2];
            Bitmap bmp = new Bitmap(800, 800);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(new Pen(Color.Black, 3), 400, 0, 400, 800);
            g.DrawLine(new Pen(Color.Black, 3), 0, 400, 800, 400);
            if (Interval <= 10)
            {
                for (int i = 0; i <= 800; i = i + (400 / Interval))
                {
                    g.DrawString(Convert.ToString(-ic), new Font("Calibri", 11), new SolidBrush(Color.LawnGreen), i, y);
                    g.DrawString(Convert.ToString(ic), new Font("Calibri", 11), new SolidBrush(Color.LawnGreen), x, i);
                    ic = ic - 1;
                }
                for(int i = 0; i < Interval*2; i++)
                {
                    decimal fx = (a * (px * px)) + (b * px) + (c);
                    int ppx = (px * (400 / Interval))+400;
                    decimal pfx = -(fx * (400 / Interval))+400;
                    points[i] = new Point(ppx, Convert.ToInt32(pfx));
                    px = px + 1;
                }
            }
            else if (Interval <= 50)
            {
                for (int i = 0; i <= 800; i = i + (400 / (Interval/5)))
                {
                    g.DrawString(Convert.ToString(-ic), new Font("Calibri", 11), new SolidBrush(Color.LawnGreen), i, y);
                    g.DrawString(Convert.ToString(ic), new Font("Calibri", 11), new SolidBrush(Color.LawnGreen), x, i);
                    ic = ic - 5;
                }
                for (int i = 0; i < Interval * 2; i++)
                {
                    decimal fx = (a * (px * px)) + (b * px) + (c);
                    int ppx = (px * (400 / Interval)) + 400;
                    decimal pfx = -(fx * (400 / Interval)) + 400;
                    points[i] = new Point(ppx, Convert.ToInt32(pfx));
                    px = px + 1;
                }
            }
            else if (Interval <= 100)
            {
                for (int i = 0; i <= 800; i = i + (400 / (Interval / 10)))
                {
                    g.DrawString(Convert.ToString(-ic), new Font("Calibri", 11), new SolidBrush(Color.LawnGreen), i, y);
                    g.DrawString(Convert.ToString(ic), new Font("Calibri", 11), new SolidBrush(Color.LawnGreen), x, i);
                    ic = ic - 10;
                }
                for (int i = 0; i < Interval * 2; i++)
                {
                    decimal fx = (a * (px * px)) + (b * px) + (c);
                    int ppx = (px * (400 / Interval)) + 400;
                    decimal pfx = -(fx * (400 / Interval)) + 400;
                    points[i] = new Point(ppx, Convert.ToInt32(pfx)); 
                    px = px + 1;
                }
            }

            g.DrawLines(new Pen(Color.Blue, 2), points);
            PictureBox display = new PictureBox();
            display.Width = 800;
            display.Height = 800;
            display.Location = new Point(25,200);
            Controls.Add(display);
            display.Image = bmp;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Graph(Convert.ToInt32(textBox1.Text), Convert.ToDecimal(textBox2.Text), Convert.ToDecimal(textBox3.Text), Convert.ToDecimal(textBox4.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            Hide();
            f.Show();
        }
    }
}
