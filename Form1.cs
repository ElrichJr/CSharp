using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Last_Attempt_at_Lab_4
{
    public partial class Form1 : Form
    {
        Media M = new Media();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (M.OpenMediaFile(textBox1.Text) != 0)
            {
                MessageBox.Show("Opening failure");
            }
            if (M.play() != 0)
            {
                MessageBox.Show("Playing failed");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.InitialDirectory = "c:\\";
            a.Filter = "mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            a.FilterIndex = 2;
            if (a.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = a.FileName;
            textBox1.Text = filename;
        }
    }
}
