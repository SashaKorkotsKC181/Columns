using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CourseWork
{
    class StandardFigure : Figure 
    {
        public StandardFigure(int y_, int x_)
        {
            Random rand = new Random();
            x = x_;
            y = y_;
            matrix = new int[3, 1]
            {
                {rand.Next(1, 5)},
                {rand.Next(1, 5)},
                {rand.Next(1, 5)},
            };
        }

    }
}







/*leftUpPointOfFigure = new Point(leftUpPointOfWorkspace.X + rand.Next() * side_, leftUpPointOfWorkspace.Y);
cobes[0] = new Cobe(new Point(leftUpPointOfFigure.X, leftUpPointOfFigure.Y), side_);
cobes[1] = new Cobe(new Point(leftUpPointOfFigure.X, leftUpPointOfFigure.Y + side_), side_);
cobes[2] = new Cobe(new Point(leftUpPointOfFigure.X, leftUpPointOfFigure.Y + side_ * 2), side_);*/