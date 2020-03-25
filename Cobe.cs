using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    class Cobe
    {
        Bitmap[] cobeColors = { Resource.Blue, Resource.Green, Resource.Pink, Resource.Purple, Resource.Red, Resource.Yellow };
        int side = 0;
        Point leftUpPointOfWorkspace;
        public Cobe(int side_, Point leftUpPointOfWorkspace_)
        {
            leftUpPointOfWorkspace = leftUpPointOfWorkspace_;
            side = side_;            
        }
        public void Draw(ref Graphics graf, int i, int j, int color_)
        {
            graf.DrawImage(cobeColors[color_], leftUpPointOfWorkspace.X + j * side, leftUpPointOfWorkspace.Y + i * side, side, side);
        }
        public void HideDrawingBackGround(ref Graphics graf, int i , int j, Color colorOfBackGound)
        {
            graf.FillRectangle(new SolidBrush(colorOfBackGound), leftUpPointOfWorkspace.X + j * side, leftUpPointOfWorkspace.Y + i * side, side, side);
        }
        public int GetSide
        {
            get {return side; }
        }
        public Point SetLeftUpPointOfWorkspace
        {
            set { leftUpPointOfWorkspace = value; }
        }
    }
}
