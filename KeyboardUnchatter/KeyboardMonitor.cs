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

        private double _chatterTimeMs = 30;

        public event Action<Keys> OnKeyPress;
        public event Action<Keys> OnKeyBlocked;

        #region Get/Set

        public bool Active
        {
            get => _active;
            set => _active = value;
        }

        public double ChatterTimeMs
        {
            get => _chatterTimeMs;
            set => _chatterTimeMs = value;
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
                var lastPressStatus = key.LastPressStatus;
                key.LastPressStatus = KeyStatusList.PressStatus.Down;

                if (lastPressStatus == KeyStatusList.PressStatus.Up &&  key.IsBlocked)
                {
                    Debug.Log("Key"+ key.KeyCode+" is blocked. Discarding");
                    return false;
                }

                double timeSpan = key.GetLastPressTimeSpan();

                if(timeSpan < _chatterTimeMs)
                {
                    Debug.Log("Key" + key.KeyCode + " timeSpawn is below limit. Blocking");
                    key.Block();
                    RegisterChatterPress(keyPress.Key);
                    return false;
                }
            }

            if (keyPress.Status == InputHook.KeyStatus.Up)
            {
                var lastPressStatus = key.LastPressStatus;
                key.LastPressStatus = KeyStatusList.PressStatus.Up;

                bool keyWasBlocked = key.IsBlocked;
                key.Press();

                if (keyWasBlocked && key.GetBlockTimeSpan() < _chatterTimeMs)
                {
                    Debug.Log("Key" + key.KeyCode + " was blocked");
                    return false;
                }
                else
                {
                    Debug.Log("Key" + key.KeyCode + " pressed");
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
