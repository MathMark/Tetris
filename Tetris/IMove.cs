using System;
using System.Drawing;

namespace Tetris
{
    public delegate Point[] ReturnCoordinates();
    public delegate void MoveLeft();
    public delegate void MoveRight();
    public delegate void MoveDown();
    public delegate void Rotate();

    interface IMove
    {
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void Rotate();
    }
}
