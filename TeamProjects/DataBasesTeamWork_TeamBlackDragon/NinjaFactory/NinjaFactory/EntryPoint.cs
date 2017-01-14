﻿namespace NinjaFactory
{
    using System;
    using System.Windows.Forms;

    internal static class EntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NinjaFactoryApp());
        }
    }
}