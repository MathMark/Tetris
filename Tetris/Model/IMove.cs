using System;
using System.Drawing;

namespace Tetris
{

    interface IMove
    {
        void MoveToLeft();
        void MoveToRight();
        void MoveToDown();
        void Rotate();
    }
 
    
}
