using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Presenter;

namespace Tetris
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindow mainWindow = new MainWindow();
            presenter presenter = new presenter(mainWindow);
            Application.Run(mainWindow);
           // Application.Run(new MainWindow());
        }
    }
}
