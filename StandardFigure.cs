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
        public StandardFigure(int[,] map_)
        {
            Random rand = new Random();
            x = rand.Next(0, map_.GetLength(1) - 1);
            y = 0;
            map = map_;
            matrix = new int[3, 1]
            {
                {rand.Next(1, 6)},
                {rand.Next(1, 6)},
                {rand.Next(1, 6)},
            };
        }        
    }
}