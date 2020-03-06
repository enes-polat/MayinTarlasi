using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WFA_MayinTarlasi
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int[] mayins = new int[20];
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(361, 397);


            for (int i = 0; i < 20; i++)
            {
                int mayin = rnd.Next(1, 101);
                if (!mayins.Contains(mayin))
                    mayins[i] = mayin;
                else
                    i--;
            }


            for (int i = 1; i < 101; i++)
            {
                PictureBox pcb = new PictureBox();
                pcb.Width = 30;
                pcb.Height = 30;
                pcb.Margin = new Padding(1);
                pcb.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));

                if (mayins.Contains(i))
                {
                    pcb.Tag = true;
                }

                pcb.Click += Pcb_Click;

                flwContainer.Controls.Add(pcb);
            }

            timer1.Start();
        }

        private void Pcb_Click(object sender, EventArgs e)
        {
            PictureBox pcb = (PictureBox)sender;
            if (pcb.Tag != null)
            {
                timer1.Stop();
                foreach (PictureBox item in flwContainer.Controls)
                {
                    if (item.Tag != null)
                    {
                        item.BackColor = Color.Black;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                    }
                }
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //this.Text = this.Size.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control item in flwContainer.Controls)
            {
                item.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            }
        }
    }
}
