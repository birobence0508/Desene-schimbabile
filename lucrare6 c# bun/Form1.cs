using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lucrare6_c__bun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool[,] matrix;
        private int n = 10;
        private int size = 30;
        private int forma = 0;



        private void Form1_Load(object sender, EventArgs e)
        {
            GenerareMatrix();

        }
        private void Form1_Paint(object sender, PaintEventArgs desen)
        {
            desenmatrix(desen.Graphics);
            
        }
        private void GenerareMatrix()
        {
            matrix = new bool[n, n];

            if (forma == 0)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        matrix[i, j] = (i + j) % 2 == 0;
            }
            else if (forma == 1)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        matrix[i, j] = (i == j || i + j == n - 1);
            }
            else if (forma == 2)
            {
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        matrix[i, j] = rand.Next(2) == 0;
            }
            else if (forma == 3) 
            {
                int center = n / 2;
                int width = 1;
                for (int i = 0; i < n - 3; i++) 
                {
                    int start = center - width / 2;
                    int end = center + width / 2;
                    for (int j = start; j <= end; j++)
                    {
                        if (j >= 0 && j < n)
                            matrix[i, j] = true;
                    }
                    if (i % 2 == 0) width += 2; 
                }

                for (int i = n - 3; i < n; i++)
                {
                    for (int j = center - 1; j <= center + 1; j++)
                    {
                        if (j >= 0 && j < n)
                            matrix[i, j] = true;
                    }
                }
            }

        }
        private void desenmatrix(Graphics desen)
        {
            using (Brush blackbrush = new SolidBrush(Color.Black))
            using (Brush whitebrush=new SolidBrush(Color.White))
                using (Pen blackpen=new Pen(Color.Black))


                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {

                        int x = j * size,y = i * size;
                        Brush brush = matrix[i, j] ? blackbrush : whitebrush;
                        desen.FillRectangle(brush, x, y, size, size);
                        desen.DrawRectangle(blackpen, x, y, size, size);
                    }
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            forma = (forma + 1) % 4;
            GenerareMatrix();
            this.Invalidate();

            if (forma == 0)
            {
                label1.Text = "Tabal Sah";
            }
            if (forma == 1)
            {
                label1.Text = "Forma X";
            }
            if(forma == 2)
            {
                label1.Text = "Random";
            }
            if (forma == 3)
            {
                label1.Text = "Brad";
            }


        }

        
    }

}
