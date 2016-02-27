using System;
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

            MainForm mainForm = new MainForm();
            presenter presenter = new presenter(mainForm);
            Application.Run(mainForm);
           // Application.Run(new MainWindow());
        }
    }
}
