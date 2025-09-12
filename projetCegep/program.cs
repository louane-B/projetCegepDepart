using System;
using System.Windows.Forms;
using ProjetCegep.vues;

namespace ProjetCegep
{
    static class Program
    {
        /// <sumary>
        ///  Point d’entrée principal de l’application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGestionCegep());
        }

    }
}