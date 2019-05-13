using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _2011_nat_Discuri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        SolidBrush b;

        Bitmap bmp = new Bitmap(100,100);
        GraphicsPath gPath;

        Random rand = new Random();

        bool suprapuse = false;
        bool sesuprapune = false;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(raza_textb.Text != "")
            {
                try
                {
                    sesuprapune = false;

                    g = Graphics.FromImage(bmp);
                    b = new SolidBrush(pictureBox2.BackColor);            

                    Point point = pictureBox1.PointToClient(Cursor.Position);

                    Rectangle rect = new Rectangle(point.X - Convert.ToInt32(raza_textb.Text) / 2, point.Y - Convert.ToInt32(raza_textb.Text) / 2,
                                                   Convert.ToInt32(raza_textb.Text), Convert.ToInt32(raza_textb.Text));                 

                    if (suprapuse)
                    {
                        gPath.AddEllipse(rect);
                        g.FillEllipse(b, rect);

                        pictureBox1.Image = bmp;
                    }
                    else
                    {
                        GraphicsPath gPath2 = new GraphicsPath();
                        gPath2.AddEllipse(rect);

                        Region r1 = new Region(gPath);

                        r1.Intersect(gPath2);

                        if(!r1.IsEmpty(g))
                        {
                            sesuprapune = true;
                        }
                        if (!sesuprapune)
                        {
                            gPath.AddEllipse(rect);
                            g.FillEllipse(b, rect);

                            pictureBox1.Image = bmp;
                        }                 
                    }
                }
                catch
                {
                    MessageBox.Show("!_!");
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gPath = new GraphicsPath();

            pictureBox1.BackColor = Color.White;

            radioButton1.Checked = true;
        }

        private void exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                suprapuse = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                suprapuse = true;
            }
        }

        private void newImage_Button_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = bmp;

            gPath = new GraphicsPath();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog(); ;

            if (dr == DialogResult.OK) pictureBox2.BackColor = colorDialog1.Color;        
        }
    }
}
