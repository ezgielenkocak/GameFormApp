using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizeHazirlikOyun
{
    public partial class FrmOyun : Form
    {
        public int skor = 0;
        Random rnd = new Random();
        public int sure = 60;
        public FrmOyun()
        {
            InitializeComponent();
        }

        private void FrmOyun_Load(object sender, EventArgs e)
        {
            tmrButon.Start();

        }

        private void tmrButon_Tick(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Size =new Size(rnd.Next(20, 100),50);
            btn.Location = new Point(rnd.Next(this.ClientSize.Width- panel1.Width -btn.Width), rnd.Next(this.ClientSize.Height - btn.Height));
            btn.Text =rnd.Next(1, 100).ToString();
            btn.BackColor = Color.FromArgb(rnd.Next(1,200),rnd.Next(1,200),rnd.Next());
            btn.Click += Btn_Click;

            this.Controls.Add(btn);

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            tmrSure.Start();
            skor++;
            Button btn =(Button)sender;
            lblSkor.Text = skor.ToString();
            btn.Dispose();

        }

        private void tmrSure_Tick(object sender, EventArgs e)
        {
            sure -= 1;
            lblSure.Text = sure.ToString();

            if (sure==0)
            {
                tmrSure.Stop();
                tmrButon.Stop();
                MessageBox.Show($"Oyun Bitti Skorunuz:{skor}");

            }
        }
    }
}
