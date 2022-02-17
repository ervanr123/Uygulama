using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Drawing.Graphics GrCiz;
        Pen kalem = new Pen(Color.Purple, 2);

        Double[,] XKonumlar = new Double[8, 4]{ {0,0,0,1}, {1,0,0,1}, {1,0,1,1}, {0,0,1,1}, {0,1,0,1}, {1,1,0,1}, {1,1,1,1}, {0,1,1,1} };
        Double[,] XIslemler = new Double[8, 4];
        Double[,] IzmtrkAl = new Double[4, 4]{ {0.707 , -0.408, 0, 0}, {0 ,  0.816, 0, 0}, {-0.707, -0.408, 0, 0}, {0 , 0 , 0, 0} };
        Double[,] Otele = new Double[4, 4]{ {1, 0, 0, 0}, {0, 1, 0, 0}, {0, 0, 1, 0}, {0, 0, 0, 1} };
        Double[,] Olcekle = new Double[4, 4]{ { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
        Double[,] UcBX = new Double[2, 4] { { 0, 0, 0, 1 }, { 2.5, 0, 0, 1 } };
        Double[,] UcBY = new Double[2, 4] { { 0, 0, 0, 1 }, { 0, 2.5, 0, 1 } };
        int i, j, k;

        private void GrfkCiz()
        {
            GrCiz = this.CreateGraphics();
            kalem.Color = Color.BlueViolet;
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[0, 0]), KrdntHspY(XIslemler[0, 1]), KrdntHspX(XIslemler[1, 0]), KrdntHspY(XIslemler[1, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[1, 0]), KrdntHspY(XIslemler[1, 1]), KrdntHspX(XIslemler[2, 0]), KrdntHspY(XIslemler[2, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[2, 0]), KrdntHspY(XIslemler[2, 1]), KrdntHspX(XIslemler[3, 0]), KrdntHspY(XIslemler[3, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[3, 0]), KrdntHspY(XIslemler[3, 1]), KrdntHspX(XIslemler[0, 0]), KrdntHspY(XIslemler[0, 1]));

            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[4, 0]), KrdntHspY(XIslemler[4, 1]), KrdntHspX(XIslemler[5, 0]), KrdntHspY(XIslemler[5, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[5, 0]), KrdntHspY(XIslemler[5, 1]), KrdntHspX(XIslemler[6, 0]), KrdntHspY(XIslemler[6, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[6, 0]), KrdntHspY(XIslemler[6, 1]), KrdntHspX(XIslemler[7, 0]), KrdntHspY(XIslemler[7, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[7, 0]), KrdntHspY(XIslemler[7, 1]), KrdntHspX(XIslemler[4, 0]), KrdntHspY(XIslemler[4, 1]));

            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[0, 0]), KrdntHspY(XIslemler[0, 1]), KrdntHspX(XIslemler[4, 0]), KrdntHspY(XIslemler[4, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[1, 0]), KrdntHspY(XIslemler[1, 1]), KrdntHspX(XIslemler[5, 0]), KrdntHspY(XIslemler[5, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[2, 0]), KrdntHspY(XIslemler[2, 1]), KrdntHspX(XIslemler[6, 0]), KrdntHspY(XIslemler[6, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(XIslemler[3, 0]), KrdntHspY(XIslemler[3, 1]), KrdntHspX(XIslemler[7, 0]), KrdntHspY(XIslemler[7, 1]));
            GrCiz.Dispose();
        }

        private int KrdntHspX(double geciciX)
        {
            return Convert.ToInt32(600 + (100 * geciciX));
        }

        private int KrdntHspY(double geciciY)
        {
            return Convert.ToInt32(300 + (-100 * geciciY));
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                Otele[3, 0] = Convert.ToDouble(textBox1.Text);
            if (textBox2.Text != "")
                Otele[3, 1] = Convert.ToDouble(textBox2.Text);
            if (textBox3.Text != "")
                Otele[3, 2] = Convert.ToDouble(textBox3.Text);

            Double[,] Gecici = new Double[8, 4];

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Gecici[i, j] = 0;
                    for (k = 0; k < 4; k++)
                    {
                        Gecici[i, j] += XKonumlar[i, k] * Otele[k, j];
                    }
                }
            }

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    XIslemler[i, j] = 0;
                    for (k = 0; k < 4; k++)
                    {
                        XIslemler[i, j] += Gecici[i, k] * IzmtrkAl[k, j];
                    }
                }
            }

            kalem.Color = Color.Red;
            GrfkCiz();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            GrCiz = this.CreateGraphics();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Double[,] Gecici = new Double[8, 4];

            if (textBox6.Text != "")
                Olcekle[0, 0] = Convert.ToDouble(textBox6.Text);
            if (textBox5.Text != "")
                Olcekle[1, 1] = Convert.ToDouble(textBox5.Text);
            if (textBox4.Text != "")
                Olcekle[2, 2] = Convert.ToDouble(textBox4.Text);

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Gecici[i, j] = 0;
                    for (k = 0; k < 4; k++)
                    {
                        Gecici[i, j] += XKonumlar[i, k] * Olcekle[k, j];
                    }
                }
            }

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    XIslemler[i, j] = 0;
                    for (k = 0; k < 4; k++)
                    {
                        XIslemler[i, j] += Gecici[i, k] * IzmtrkAl[k, j];
                    }
                }
            }

            kalem.Color = Color.FromArgb(233, 147, 64);
            GrfkCiz();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double[,] GeciciUcBX = new Double[2, 4];

            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    GeciciUcBX[i, j] = 0;
                    for (k = 0; k < 4; k++)
                    {
                        GeciciUcBX[i, j] += UcBX[i, k] * IzmtrkAl[k, j];
                    }
                }
            }

            GrCiz = this.CreateGraphics();
            kalem.Color = Color.DarkGray;

            GrCiz.DrawLine(kalem, KrdntHspX(GeciciUcBX[0, 0]), KrdntHspY(GeciciUcBX[0, 1]), KrdntHspX(GeciciUcBX[1, 0]), KrdntHspY(GeciciUcBX[1, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(GeciciUcBX[0, 0]), KrdntHspY(GeciciUcBX[0, 1]), KrdntHspX(GeciciUcBX[1, 0] * -1), KrdntHspY(GeciciUcBX[1, 1]));
            GrCiz.DrawLine(kalem, KrdntHspX(UcBY[0, 0]), KrdntHspY(UcBY[0, 1]), KrdntHspX(UcBY[1, 0]), KrdntHspY(UcBY[1, 1]));
            GrCiz.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    XIslemler[i, j] = 0;
                    for (k = 0; k < 4; k++)
                    {
                        XIslemler[i, j] += XKonumlar[i, k] * IzmtrkAl[k, j];
                    }
                }
            }


            kalem.Color = Color.Purple;
            GrfkCiz();
        }

        
    }
}
