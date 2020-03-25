using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CourseWork
{
    abstract class Figure
    {        
        protected int x;
        protected int y;
        protected int[,] matrix;

        public void MoveDown()
        {
            y++;
        }

        public int[,] GetMatrix
        {
            get { return matrix; }
        }
        public int GetX
        {
            get { return x; }
        }
        public int GetY
        {
            get { return y; }
        }
    }
}
