using System;
using System.Windows.Forms;
using System.Windows;
using System.Configuration;
using System.Collections.Specialized;
using System.Diagnostics;

namespace KeyboardUnchatter
{
    static class Program
    {
        private static InputHook _inputHook;
        private static KeyboardMonitor _keyboardMonitor;
        private static MainWindow _mainWindow;

        #region Get/Set
        public static InputHook InputHook
        {
            get => _inputHook;
        }

        public static KeyboardMonitor KeyboardMonitor
        {
            get => _keyboardMonitor;
        }

        #endregion

        [STAThread]
        static void Main()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (_inputHook = new InputHook())
            {
                _keyboardMonitor = new KeyboardMonitor();

                _mainWindow = new MainWindow();
                _mainWindow.FormClosed += Close;

                if(!Properties.Settings.Default.openMinimized)
                {
                    _mainWindow.Show();
                }

                Application.Run();
            }
        }

        private static void Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
