using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;


namespace KeyboardUnchatter
{
    public class KeyboardMonitor
    {
        private bool _active = false;

        private KeyStatusList _keyStatusList = new KeyStatusList();

        private const double kChatterTimeMs = 30;

        public event Action<Keys> OnKeyPress;
        public event Action<Keys> OnKeyBlocked;

        #region Get/Set

        public bool Active
        {
            get => _active;
            set => _active = value;
        }

        #endregion

        public KeyboardMonitor()
        {
            Program.InputHook.OnHandleKey = HandleKey;
        }

        public void Activate()
        {
            if(!_active)
            {
                _keyStatusList.Clear();
                _active = true;
            }
        }

        public void Deactivate()
        {
            _active = false;
        }

        private bool HandleKey(InputHook.KeyPress keyPress)
        {
            if(!_active)
            {
                return true;
            }
            
            var key = _keyStatusList.GetKey(keyPress.KeyCode);

            if (keyPress.Status == InputHook.KeyStatus.Down)
            {
                if (key.IsBlocked)
                {
                    return false;
                }

                double timeSpan = key.GetLastPressTimeSpan();

                if(timeSpan < kChatterTimeMs)
                {
                    key.Block();
                    RegisterChatterPress(keyPress.Key);
                    Debug.WriteLine("Blocking chatter key On Down: "+ keyPress.Key + " timeSpan: " + timeSpan);
                    return false;
                }
            }

            if (keyPress.Status == InputHook.KeyStatus.Up)
            {

                bool keyWasBlocked = key.IsBlocked;
                key.Press();

                if (keyWasBlocked)
                {
                    return false;
                }
                else
                {
                    RegisterPress(keyPress.Key);
                }
            }

            return true;
        }

        private void RegisterPress(Keys key)
        {
            if (OnKeyPress != null)
            {
                OnKeyPress(key);
            }
        }

        private void RegisterChatterPress(Keys key)
        {
            if (OnKeyPress != null)
            {
                OnKeyPress(key);
            }

            if (OnKeyBlocked != null)
            {
                OnKeyBlocked(key);
            }
        }
    }
}
