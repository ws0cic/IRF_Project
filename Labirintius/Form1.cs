using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Labirintius
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Maze maze1 = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var maze = Loader.LoadFromXml(openFileDialog1.FileName);

                maze.Solution = Finder.PathFinder(maze);
                maze.Dimension = maze.Solution.Length;
                maze.IsResoluble = Finder.Shortest(maze.Solution) != -1;

                for (int i = 0; i < maze.Dimension; i++)
                {
                    for (int j = 0; j < maze.Dimension; j++)
                    {
                        Color color = Color.Aqua;
                        if (maze.Solution[i][j].HasValue && maze.Solution[i][j].Value == -1)
                            color = Color.Green;
                        else if (maze.Solution[i][j].HasValue)
                            color = Color.Yellow;
                        else
                            color = Color.Blue;
                        Draw(i, j, color);
                    }
                }

                maze1 = maze;
            }
        }

        public void Draw(int x, int y, Color color)
        {
            int size = 30;

            SolidBrush myBrush = new SolidBrush(color);
            Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(x * size, y * size, size, size));
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maze1 != null && maze1.IsResoluble)
            {
                int num = maze1.Solution[maze1.Dimension - 1][maze1.Dimension - 1].Value;
                int per = 255 / num;

                for (int i = 0; i < maze1.Dimension; i++)
                {
                    for (int j = 0; j < maze1.Dimension; j++)
                    {

                        Color color = Color.Aqua;
                        if (maze1.Solution[i][j].HasValue && maze1.Solution[i][j].Value == -1)
                            color = Color.Green;
                        else if (maze1.Solution[i][j].HasValue)
                            color = Color.FromArgb(maze1.Solution[i][j].Value * per, 100, 100);
                        else
                            color = Color.Blue;
                        Draw(i, j, color);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maze1 != null)
            {
                var csv = new StringBuilder();
                for (int i = 0; i < maze1.Dimension; i++)
                {
                    string line = string.Empty;
                    for (int j = 0; j < maze1.Dimension; j++)
                    {
                        var value = maze1.Solution[i][j] ?? -2;
                        if (string.IsNullOrEmpty(line))
                            line += value.ToString();
                        else
                            line += ";" + value.ToString();
                    }
                    csv.AppendLine(line);
                }
                //after your loop
                File.WriteAllText("solution.csv", csv.ToString());
            }
        }
    }
}
