using System;
using System.Windows.Forms;

namespace windowsfirewalladd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void buttonX1_Click(object sender, EventArgs e)
        {
            SyhMhfz.setroles(textBoxX1,textBoxX2,textBoxX3,richTextBox1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SyhMhfz.baslikcreate(dataGridView1);
        }     
        private void kurallarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyhMhfz.getroles(dataGridView1);
        }
    }
}
