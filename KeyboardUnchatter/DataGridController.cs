using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardUnchatter
{
    public class DataGridController
    {
        public class KeyData
        {
            private Keys _key;
            private int _keyPressedCount = 0;
            private int _keyBlockedCount = 0;

            public Keys Key
            {
                get => _key;
            }

            public int KeyBlockedCount
            {
                get => _keyBlockedCount;
                set => _keyBlockedCount = value;
            }

            public int KeyPressedCount
            {
                get => _keyPressedCount;
                set => _keyPressedCount = value;
            }

            public KeyData(Keys key)
            {
                _key = key;
            }
        }

        private DataGridView _dataGrid;

        Dictionary<int, KeyData> _keyDataStatus = new Dictionary<int, KeyData>();

        public DataGridController(DataGridView dataGrid)
        {
            _dataGrid = dataGrid;
        }

        public void AddKeyPress(Keys key)
        {
            KeyData keyData;

            if(!_keyDataStatus.TryGetValue((int)key,out keyData))
            {
                keyData = new KeyData(key);

                _keyDataStatus[(int)key] = keyData;
            }

            _keyDataStatus[(int)key].KeyPressedCount++;

            UpdateGridCell(keyData);
        }

        public void AddKeyBlock(Keys key)
        {
            KeyData keyData;

            if (!_keyDataStatus.TryGetValue((int)key, out keyData))
            {
                keyData = new KeyData(key);

                _keyDataStatus[(int)key] = keyData;
            }

            _keyDataStatus[(int)key].KeyBlockedCount++;

            UpdateGridCell(keyData);
        }

        private void UpdateGridCell(KeyData keyData)
        {
            bool cellUpdated = false;
            for (int a = 0; a < _dataGrid.Rows.Count; ++a)
            {
                var row = _dataGrid.Rows[a];

                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == keyData.Key.ToString())
                {
                    int press = keyData.KeyPressedCount;
                    int block = keyData.KeyBlockedCount;

                    _dataGrid.Rows[a].SetValues(new string[] { keyData.Key.ToString(), press.ToString(), block.ToString(), (Math.Floor((float)block/(float)press*100)).ToString() +"%" });
                    cellUpdated = true;
                }
            }

            if (!cellUpdated)
            {
                int press = keyData.KeyPressedCount;
                int block = keyData.KeyBlockedCount;
                _dataGrid.Rows.Add(new string[] { keyData.Key.ToString(), press.ToString(), block.ToString(), (Math.Floor((float)block / (float)press)*100).ToString() + "%" });
            }
        }
    }
}
