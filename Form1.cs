using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        Figure currentFigure;
        Cobe cobe;
        Point center;
        const int cobeSide = 30;
        const int numberOfCobsDownInPictureBox = 4;
        const int numberOfCobsDownSide = 6;
        const int numberOfCobsLeftSide = 12;
        int[,] map;
        Point leftUpPointOfWorkspace;
        public Form1()
        {
            InitializeComponent();
            center = new Point(this.DisplayRectangle.Width / 2, MenuOfForm1.Height + (this.DisplayRectangle.Height - MenuOfForm1.Height - 5) / 2);
            leftUpPointOfWorkspace = new Point(center.X - numberOfCobsDownSide / 2 * cobeSide, center.Y - numberOfCobsLeftSide / 2 * cobeSide);
            map = new int[numberOfCobsLeftSide, numberOfCobsDownSide];
            cobe = new Cobe(cobeSide, leftUpPointOfWorkspace);
            currentFigure = new StandardFigure(map);
            timer.Tick += new EventHandler(update);
            KeyUp += new KeyEventHandler(ControlOfCurrentFigure);
        }

        private void update(object sender, EventArgs e)
        {
            Refresh();
            if (!currentFigure.CheckMoveDown())
                currentFigure = new StandardFigure(map);
            else
            {
                CleanMap();
                currentFigure.MoveDown();
            }
        }

        public void  Map()
        {
            for (int i = 0; i < currentFigure.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < currentFigure.GetMatrix.GetLength(1); j++)
                {                    
                    map[currentFigure.GetY + i, currentFigure.GetX + j] = currentFigure.GetMatrix[i, j];
                }

            }
        }
        public void CleanMap()
        {
            for (int i = 0; i < currentFigure.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < currentFigure.GetMatrix.GetLength(1); j++)
                {
                    map[currentFigure.GetY + i, currentFigure.GetX + j] = 0;
                }
            }
        }
        public void DrawMap(Graphics graf)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                     if (map[i, j] != 0)
                         cobe.Draw(ref graf, i, j, map[i, j]);
                }
            }
        }
        private void ControlOfCurrentFigure(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    if (currentFigure.CheckMoveLeft(map))
                    {
                        CleanMap();
                        currentFigure.MoveLeft();
                        Refresh();
                    }
                    break;
                case Keys.Right:
                    if (currentFigure.CheckMoveRight(map))
                    {
                        CleanMap();
                        currentFigure.MoveRight();
                        Refresh();
                    }
                    break;

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Map();
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void DrawGrid(Graphics graf)
        {
            for (int i = 0; i <= map.GetLength(1); i++)
            {
                graf.DrawLine(new Pen(Color.Gray), new Point(leftUpPointOfWorkspace.X + i * cobeSide, leftUpPointOfWorkspace.Y), new Point(leftUpPointOfWorkspace.X + i * cobeSide, leftUpPointOfWorkspace.Y + numberOfCobsLeftSide * cobeSide));
            }
            for (int i = 0; i <= map.GetLength(0); i++)
            {
                graf.DrawLine(new Pen(Color.LightGray), new Point(leftUpPointOfWorkspace.X, leftUpPointOfWorkspace.Y + i * cobeSide), new Point(leftUpPointOfWorkspace.X + numberOfCobsDownSide * cobeSide, leftUpPointOfWorkspace.Y + i * cobeSide));
            }

        }
        private void DrawPictureBoxs()
        {
            leftPictureBox.Location = new Point(center.X - (numberOfCobsDownSide / 2 + numberOfCobsDownInPictureBox) * cobeSide, center.Y - numberOfCobsLeftSide / 2 * cobeSide);
            //leftPictureBox.Size = new System.Drawing.Size(numberOfCobsDownSide / 2 * cobeSide, numberOfCobsLeftSide * cobeSide + downPictureBox.Height);
            rightPictureBox.Location = new Point(center.X + numberOfCobsDownSide / 2 * cobeSide, center.Y - numberOfCobsLeftSide / 2 * cobeSide);
            //leftPictureBox.Size = rightPictureBox.Size;
            downPictureBox.Location = new Point(center.X - numberOfCobsDownSide / 2 * cobeSide, center.Y + numberOfCobsLeftSide / 2 * cobeSide);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            center = new Point(this.DisplayRectangle.Width / 2, MenuOfForm1.Height + (this.DisplayRectangle.Height - MenuOfForm1.Height - downPictureBox.Height) / 2);
            leftUpPointOfWorkspace = new Point(center.X - numberOfCobsDownSide / 2 * cobeSide, center.Y - numberOfCobsLeftSide / 2 * cobeSide);
            cobe.SetLeftUpPointOfWorkspace = leftUpPointOfWorkspace;            
            DrawPictureBoxs();
            Refresh();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            if (timer.Enabled)
                pauseToolStripMenuItem.Text = "&Pause";
            else
                pauseToolStripMenuItem.Text = "&Start";
        }

    }
}
