using System;
using System.Windows.Forms;

namespace Labirintius
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var maze = Loader.LoadFromXml(openFileDialog1.FileName);
                var result = Finder.PathFinder(maze);
            }
        }
    }
}
