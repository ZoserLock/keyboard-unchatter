using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace KeyboardUnchatter
{
    public class InputHook : IDisposable
    {
        internal struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            int scanCode;
            public int flags;
            int time;
            int dwExtraInfo;
        }

        public enum KeyStatus
        {
            None = 0,
            Down = 1,
            Up   = 2
        }

        internal delegate IntPtr HookHandlerDelegate(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE_LL = 14;

        private const int WM_KEYUP = 0x0101;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYUP = 0x0105;
        private const int WM_SYSKEYDOWN = 0x0104;

        private HookHandlerDelegate _keyboardHookHandlerDelegate;

        private IntPtr _keyboardHookID = IntPtr.Zero;

        public Func<KeyPress,bool> OnHandleKey;

        public InputHook()
        {
            _keyboardHookHandlerDelegate = new HookHandlerDelegate(KeyboardHookCallback);

            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    _keyboardHookID = NativeMethods.SetWindowsHookEx(WH_KEYBOARD_LL, _keyboardHookHandlerDelegate, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            bool allowContinue = true;

            KeyStatus keyStatus = KeyStatus.None;

            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP || wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                if(wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                {
                    keyStatus = KeyStatus.Up;
                }
                else if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
                {
                    keyStatus = KeyStatus.Down;
                }

                allowContinue = HandleKey(new KeyPress(lParam.vkCode, keyStatus));
            }

            if(allowContinue)
            {
                return NativeMethods.CallNextHookEx(_keyboardHookID, nCode, wParam, ref lParam);
            }

            return (System.IntPtr)1;
        }

        public bool HandleKey(KeyPress e)
        {
            if (OnHandleKey != null)
            {
                return OnHandleKey(e);
            }

            return true;
        }

        public class KeyPress : System.EventArgs
        {
            private Keys _key;
            private int _keyCode;
            private KeyStatus _status;

            public Keys Key
            {
                get { return _key; }
            }

            public int KeyCode
            {
                get { return _keyCode; }
            }

            public KeyStatus Status
            {
                get { return _status; }
            }

            public KeyPress(int evtKeyCode, KeyStatus status)
            {
                _key = ((Keys)evtKeyCode);
                _keyCode = evtKeyCode;
                _status  = status;
            }
        }

        public void Dispose()
        {
            NativeMethods.UnhookWindowsHookEx(_keyboardHookID);
        }

        #region Native methods

        [ComVisibleAttribute(false), System.Security.SuppressUnmanagedCodeSecurity()]
        internal class NativeMethods
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook, HookHandlerDelegate lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
            public static extern short GetKeyState(int keyCode);

        }

        #endregion
    }
}
