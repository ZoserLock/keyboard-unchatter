using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardUnchatter
{
    class KeyStatusList
    {
        public enum PressStatus
        {
            Down =0,
            Up =1,
        }
        public class KeyStatus
        {
            private int _keyCode;
            private DateTime _pressDownTime;
            private bool _blocked;
            private PressStatus _lastPressStatus;

            #region Get/Set
            public int KeyCode
            {
                get => _keyCode;
            }

            public DateTime PressDownTime
            {
                get => _pressDownTime;

            }
            public bool IsBlocked
            {
                get => _blocked;
            }

            internal PressStatus LastPressStatus
            {
                get => _lastPressStatus;
                set => _lastPressStatus = value;
            }

            #endregion

            public KeyStatus(int code)
            {
                _keyCode = code;
                _pressDownTime = DateTime.MinValue;
                _blocked = false;
            }

            public double GetLastPressTimeSpan()
            {
                var timeSpan = (DateTime.Now - _pressDownTime);
                return timeSpan.TotalMilliseconds;
            }

            public void Block()
            {
                _blocked = true;
            }

            public void Press()
            {
                _pressDownTime = DateTime.Now;
                _blocked = false;
            }
        }

        private Dictionary<int, KeyStatus> _keyStatus = new Dictionary<int, KeyStatus>();

        public KeyStatus GetKey(int keyCode)
        {
            KeyStatus status;

            if (_keyStatus.TryGetValue(keyCode, out status))
            {
                return status;
            }

            _keyStatus[keyCode] = new KeyStatus(keyCode);

            return  _keyStatus[keyCode];
        }

        public void Clear()
        {
            _keyStatus.Clear();
        }
    }
}
