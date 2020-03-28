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
        protected int[,] map;
        public void MoveRight()
        {
            x++;
        }
        public void MoveLeft()
        {
            x--;
        }
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
        public bool CheckMoveRight(int[,] map_)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (x + 1 + j >= map.GetLength(1) || map_[y + i, x + 1 + j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckMoveLeft(int[,] map_)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (x - 1 + j < 0 || map_[y + i, x - 1 + j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CheckMoveDown()
        {
            if (y + matrix.GetLength(0) < map.GetLength(0) && map[y + matrix.GetLength(0), x] == 0)
            {
                return true;
            }
            else return false;
        }
    }
}
