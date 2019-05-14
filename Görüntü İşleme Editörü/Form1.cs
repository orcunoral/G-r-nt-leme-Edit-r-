using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_sharp
{   
     public partial class Form1 : Form
     {
        Bitmap bmpIlk;
        int kontrol = 0;/// <summary>
                        /// Fotoğraf okunmadan butonların çalışmasını engelliyor.
                        /// </summary>

        public Form1()
        {
            InitializeComponent();
        }

        private void acToolStripMenuItem_Click(object sender, EventArgs e)//Dosyadan Aç
        {
            //Picture Boxta resim gösterimi
            OpenFileDialog  dosya = new OpenFileDialog();
            dosya.Filter = "Image(*.bmp; *.jpg)|*.bmp;*.jpg|All files(*.*)|*.*||";
            if (dosya.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            bmpIlk = new Bitmap(dosya.FileName);
            pictureBox1.Image = bmpIlk;
            pictureBox1.Refresh();
            kontrol = 1;
        }

        private void button2_Click(object sender, EventArgs e)//Sağ Button
        {
            if (kontrol == 1)
            {
                double PI = 3.141593;

                int Aci = 90;
                Color OkunanRenk;
                int ilkGenislik = pictureBox1.Width;
                int ilkYukseklik = pictureBox1.Height;
                Bitmap pic = new Bitmap(ilkGenislik, ilkYukseklik);
                Bitmap temp = new Bitmap(pictureBox1.Image);
                double x2 = 0, y2 = 0;
                int x0 = ilkGenislik / 2;
                int y0 = ilkYukseklik / 2;
                double RadyanAci = Aci * 2 * PI / 360;
                for (int x1 = 0; x1 < ilkGenislik; x1++)
                {
                    for (int y1 = 0; y1 < ilkYukseklik; y1++)
                    {
                        OkunanRenk = temp.GetPixel(x1, y1);
                        x2 = Math.Cos(RadyanAci) * (x1 - x0) - Math.Sin(RadyanAci) * (y1 - y0) + x0;
                        y2 = Math.Sin(RadyanAci) * (x1 - x0) + Math.Cos(RadyanAci) * (y1 - y0) + y0;
                        if (x2 > 0 && x2 < ilkGenislik && y2 > 0 && y2 < ilkYukseklik)
                            pic.SetPixel((int)x2, (int)y2, OkunanRenk);

                    }
                }
                pictureBox1.Image = pic;
                pictureBox1.Refresh();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)//Sol button
        {
            if (kontrol == 1)
            {
                double PI = 3.141593;
                int Aci =-90;
                Color OkunanRenk;
                int ilkGenislik = pictureBox1.Width;
                int ilkYukseklik = pictureBox1.Height;
                Bitmap pic = new Bitmap(ilkGenislik, ilkYukseklik);
                Bitmap temp = new Bitmap(pictureBox1.Image);
                double x2 = 0, y2 = 0;
                int x0 = ilkGenislik / 2;
                int y0 = ilkYukseklik / 2;
                double RadyanAci = Aci * 2 * PI / 360;
                for (int x1 = 0; x1 < ilkGenislik; x1++)
                {
                    for (int y1 = 0; y1 < ilkYukseklik; y1++)
                    {
                        OkunanRenk = temp.GetPixel(x1, y1);
                        x2 = Math.Cos(RadyanAci) * (x1 - x0) - Math.Sin(RadyanAci) * (y1 - y0) + x0;
                        y2 = Math.Sin(RadyanAci) * (x1 - x0) + Math.Cos(RadyanAci) * (y1 - y0) + y0;
                        if (x2 > 0 && x2 < ilkGenislik && y2 > 0 && y2 < ilkYukseklik)
                            pic.SetPixel((int)x2, (int)y2, OkunanRenk);

                    }
                }
                pictureBox1.Image = pic;
                pictureBox1.Refresh();
            }
        }

        private void btnInvert_Click(object sender, EventArgs e)//Negative Invert Button
        {
            if (kontrol == 1)
            {
                Bitmap resim = new Bitmap(pictureBox1.Image);
                for (int y = 0; (y < resim.Height ); y++)
                {
                    for (int x = 0; (x < resim.Width ); x++)
                    {
                        Color renk = resim.GetPixel(x, y);
                        renk = Color.FromArgb(255, (255 - renk.R), (255 - renk.G), (255 - renk.B));
                        resim.SetPixel(x, y, renk);
                    }
                    pictureBox1.Image = resim;
                    pictureBox1.Refresh();
                }
            }
        }

        private void btnMirror_Click(object sender, EventArgs e)//Aynalama Button
        {
            if (kontrol == 1)
            {
                Color OkunanRenk;
                int ResimGenisligi = pictureBox1.Width;
                int ResimYuksekligi = pictureBox1.Height;
                Bitmap bmp = new Bitmap(ResimGenisligi, ResimYuksekligi);
                Bitmap temp = new Bitmap(pictureBox1.Image);
                int x0 = ResimGenisligi / 2;
                int y0 = ResimYuksekligi / 2;
                int x2 = 0, y2 = 0;
                for (int x1 = 0; x1 < ResimGenisligi; x1++)
                {
                    for (int y1 = 0; y1 < ResimYuksekligi; y1++)
                    {
                        OkunanRenk = temp.GetPixel(x1, y1);
                        x2 = -x1 + 2 * x0;
                        y2 = y1;
                        if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                            bmp.SetPixel((int)x2, (int)y2, OkunanRenk);
                    }
                }
                pictureBox1.Image = bmp;
                pictureBox1.Refresh();
            }
        }

        private void btnGray_Click(object sender, EventArgs e)//Gri Tonlama
        {
            if (kontrol == 1)
            {
                Bitmap resim = new Bitmap(pictureBox1.Image);
                for (int x = 0; x < resim.Width; x++)
                {
                    for (int y = 0; y < resim.Height; y++)
                    {
                        Color ilkRenk = resim.GetPixel(x, y);
                        int griTon = (int)((ilkRenk.R * 0.3) + (ilkRenk.G * 0.59) + (ilkRenk.B * 0.11));
                        Color yeniRenk = Color.FromArgb(ilkRenk.A, griTon, griTon, griTon);
                        resim.SetPixel(x, y, yeniRenk); 
                    }
                }
                pictureBox1.Image = resim;
                pictureBox1.Refresh();
            }
        }

        private void btnRed_Click(object sender, EventArgs e)//Red Channel
        {
            if (kontrol == 1)
            {
                Color OkunanRenk;
                int ResimGenisligi = pictureBox1.Width;
                int ResimYuksekligi = pictureBox1.Height;
                Bitmap resim = new Bitmap(pictureBox1.Image);
                for (int x = 0; x < ResimGenisligi; x++)
                {
                    for (int y = 0; y < ResimYuksekligi; y++)
                    {
                        OkunanRenk = resim.GetPixel(x, y);
                        int a = OkunanRenk.A;
                        int r = OkunanRenk.R;
                        resim.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));
                    }
                }
                pictureBox1.Image = resim;
                pictureBox1.Refresh();
            }
        }

        private void btnGreen_Click(object sender, EventArgs e)//Green Channel
        {
            if (kontrol == 1)
            {
                Color OkunanRenk;
                int ResimGenisligi = pictureBox1.Width;
                int ResimYuksekligi = pictureBox1.Height;
                Bitmap resim = new Bitmap(pictureBox1.Image);
                for (int x = 0; x < ResimGenisligi; x++)
                {
                    for (int y = 0; y < ResimYuksekligi; y++)
                    {
                        OkunanRenk = resim.GetPixel(x, y);
                        int a = OkunanRenk.A;
                        int g = OkunanRenk.G;
                        
                        resim.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));
                    }
                }
                pictureBox1.Image = resim;
                pictureBox1.Refresh();
            }
        }

        private void btnBlue_Click(object sender, EventArgs e)//Blue Channel
        {
            if (kontrol == 1)
            {
                Color OkunanRenk;
                int ResimGenisligi = pictureBox1.Width;
                int ResimYuksekligi = pictureBox1.Height;
                Bitmap resim = new Bitmap(pictureBox1.Image);
                for (int x = 0; x < ResimGenisligi; x++)
                {
                    for (int y = 0; y < ResimYuksekligi; y++)
                    {
                        OkunanRenk = resim.GetPixel(x, y);
                        int a = OkunanRenk.A;
                        int b = OkunanRenk.B;
                        resim.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));
                    }
                }
                pictureBox1.Image = resim;
                pictureBox1.Refresh();
            }
        }

        private void btnResize_Click(object sender, EventArgs e)//Ölçeklendirme
        {
            if (kontrol == 1)
            {
                Bitmap yeniBmp;
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Genişlik ve yükseklik değerlerini yazınız.", "Dikkat");
                }
                else
                {
                    int Size_X, Size_Y;
                    Size_X = Convert.ToInt32(textBox1.Text);
                    Size_Y = Convert.ToInt32(textBox2.Text);
                    yeniBmp = new Bitmap(pictureBox1.Image, Size_X, Size_Y);
                    pictureBox1.Image = yeniBmp;
                    pictureBox1.Refresh();
                }
            }
        }

        private void tekrarAçToolStripMenuItem_Click(object sender, EventArgs e)//Reopen
        {
            pictureBox1.Image = bmpIlk;
            pictureBox1.Refresh();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)//Kaydetme
        {
            if (kontrol == 1)
            {
                SaveFileDialog dosya = new SaveFileDialog();
                dosya.Filter = "Image(*.jpg)|*.jpg|All files(*.*)|*.*||";
                if (dosya.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                pictureBox1.Image.Save(dosya.FileName);
            }
        }

        private void btnHistogram_Click(object sender, EventArgs e)//Histogram
        {
            if (kontrol == 1)
            {
                chart1.Series.Clear();
                chart1.Series.Add("RED").Color = Color.Red;
                chart2.Series.Clear();
                chart2.Series.Add("GREEN").Color = Color.Green;
                chart3.Series.Clear();
                chart3.Series.Add("BLUE").Color = Color.Blue;
                chart4.Series.Clear();
                chart4.Series.Add("GRAY").Color=Color.Gray;
                Bitmap resim;
                resim = (Bitmap)pictureBox1.Image;
                int[,] RandG = new int[256,256];
                int[,] BandGray = new int[256, 256];
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    for (int j = 0; j < pictureBox1.Height; j++)
                    {
                        Color renk = resim.GetPixel(i, j);
                        int R = renk.R;
                        int G = renk.G;
                        int B = renk.B;
                        int griTon = (int)((renk.R * 0.3) + (renk.G * 0.59) + (renk.B * 0.11));
                        RandG[R, 0]++;
                        RandG[0, G]++;
                        BandGray[B, 0]++;
                        BandGray[0, griTon]++;
                    }
                }
                for (int k = 0; k < 256; k++)
                {
                    chart1.Series["RED"].Points.AddXY(k, RandG[k,0]);
                    chart1.Series["RED"].Points[k].Color = Color.Red;
                    chart2.Series["GREEN"].Points.AddXY(k, RandG[0,k]);
                    chart2.Series["GREEN"].Points[k].Color = Color.Green;
                    chart3.Series["BLUE"].Points.AddXY(k, BandGray[k,0]);
                    chart3.Series["BLUE"].Points[k].Color = Color.Blue;
                    chart4.Series["GRAY"].Points.AddXY(k, BandGray[0,k]);
                    chart4.Series["GRAY"].Points[k].Color = Color.Gray;
                }
            }
        }
    }
}
