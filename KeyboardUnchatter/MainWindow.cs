using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace KeyboardUnchatter
{
    public partial class MainWindow : Form
    {
        private Color _activeColor;
        private DataGridController _dataGridController;

        public MainWindow()
        {
            _activeColor = Color.FromArgb(255, 255, 102, 0);

            InitializeComponent();
            Program.KeyboardMonitor.OnKeyBlocked += OnKeyBlocked;
            Program.KeyboardMonitor.OnKeyPress += OnKeyPress;

            _notifyIcon.Visible = true;

            _thresholdTimeInput.Value = Properties.Settings.Default.chatterThreshold;
            _minimizeCheckBox.Checked = Properties.Settings.Default.openMinimized;
            _activateOnLaunchCheckBox.Checked = Properties.Settings.Default.activateOnLaunch;

            _dataGridController = new DataGridController(_mainDataGrid);

            if (Properties.Settings.Default.activateOnLaunch)
            {
                ActivateKeyboardMonitor();
            }
        }

        private void OnKeyPress(Keys key)
        {
            _dataGridController.AddKeyPress(key);
        }

        private void OnKeyBlocked(Keys key)
        {
            _dataGridController.AddKeyBlock(key);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Program.KeyboardMonitor.OnKeyBlocked -= OnKeyBlocked;
            Program.KeyboardMonitor.OnKeyPress -= OnKeyPress;
            _notifyIcon.Visible = false;
        }

        private void ShowProgramWindow()
        {
            if (!Visible)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            Activate();
        }

        #region Events

        private void OnActivateButtonClick(object sender, EventArgs e)
        {
            if (!Program.KeyboardMonitor.Active)
            {
                ActivateKeyboardMonitor();
            }
            else
            {
                DeactivateKeyboardMonitor();
            }
            ActiveControl = null;
        }

        private void ActivateKeyboardMonitor()
        {
            _buttonActivate.BackColor = _activeColor;
            _statusPanel.BackColor = _activeColor;
            _buttonActivate.Text = "Stop";
            _statusPanelLabel.Text = "Active";

            Program.KeyboardMonitor.Activate();
        }

        public void DeactivateKeyboardMonitor()
        {
            _buttonActivate.BackColor = SystemColors.Control;
            _statusPanel.BackColor = SystemColors.ControlDark;
            _buttonActivate.Text = "Activate";
            _statusPanelLabel.Text = "Not Active";

            Program.KeyboardMonitor.Deactivate();
        }

        private void OnMainWindowResize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                Hide();
            }
        }

        private void OnNotifyIconClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowProgramWindow();
            }
        }

        private void OnNotifyIconMenuStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem == _openMenuItem)
            {
                ShowProgramWindow();
            }

            if(e.ClickedItem == _exitMenuItem)
            {
                Close();
            }
        }

        private void OnThresholdTimeInputValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.chatterThreshold = _thresholdTimeInput.Value;
            Properties.Settings.Default.Save();
            Program.KeyboardMonitor.ChatterTimeMs = System.Convert.ToDouble(_thresholdTimeInput.Value);
        }

        private void OnMinimizeCheckBoxValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.openMinimized = _minimizeCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void OnActivateOnLaunchCheckBox(object sender, EventArgs e)
        {
            Properties.Settings.Default.activateOnLaunch = _activateOnLaunchCheckBox.Checked;
            Properties.Settings.Default.Save();
        }


        private void DataSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 1 || e.Column.Index == 2)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }

            if (e.Column.Index == 3)
            {
                var value1 = e.CellValue1.ToString().Replace("%","");
                var value2 = e.CellValue2.ToString().Replace("%", "");

                e.SortResult = int.Parse(value1.ToString()).CompareTo(int.Parse(value2.ToString()));
                e.Handled = true;
            }
        }
        #endregion

    }
}
