using ProjectDelta.Context;
using System;
using System.Windows.Forms;

namespace ProjectDelta
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Inicializacao ini = new Inicializacao();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
