using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///A random number is generated and then shown at the end of the subsequent message.
            Random rand = new Random();
            int randomNumber = rand.Next(0, 100);
            MessageBox.Show("SHAZAM! I peer deep into your soul. The number I've chosen is " + randomNumber + "...  Magic, everyone! Magic!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
