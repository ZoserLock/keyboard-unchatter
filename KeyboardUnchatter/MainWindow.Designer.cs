namespace KeyboardUnchatter
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this._statusPanel = new System.Windows.Forms.Panel();
            this._statusPanelLabel = new System.Windows.Forms.Label();
            this._buttonActivate = new System.Windows.Forms.Button();
            this._mainDataGrid = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PressCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChatterCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FailureRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dataGridGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._activateOnLaunchCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._minimizeCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this._thresholdTimeInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._notifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._statusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainDataGrid)).BeginInit();
            this._dataGridGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._thresholdTimeInput)).BeginInit();
            this._notifyIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _statusPanel
            // 
            this._statusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._statusPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this._statusPanel.Controls.Add(this._statusPanelLabel);
            this._statusPanel.Location = new System.Drawing.Point(0, 1);
            this._statusPanel.Name = "_statusPanel";
            this._statusPanel.Size = new System.Drawing.Size(620, 41);
            this._statusPanel.TabIndex = 0;
            // 
            // _statusPanelLabel
            // 
            this._statusPanelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._statusPanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._statusPanelLabel.Location = new System.Drawing.Point(0, 4);
            this._statusPanelLabel.Name = "_statusPanelLabel";
            this._statusPanelLabel.Size = new System.Drawing.Size(620, 37);
            this._statusPanelLabel.TabIndex = 0;
            this._statusPanelLabel.Text = "Not Active";
            this._statusPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _buttonActivate
            // 
            this._buttonActivate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._buttonActivate.Location = new System.Drawing.Point(238, 387);
            this._buttonActivate.Name = "_buttonActivate";
            this._buttonActivate.Size = new System.Drawing.Size(137, 27);
            this._buttonActivate.TabIndex = 2;
            this._buttonActivate.Text = "Activate";
            this._buttonActivate.UseVisualStyleBackColor = true;
            this._buttonActivate.Click += new System.EventHandler(this.OnActivateButtonClick);
            // 
            // _mainDataGrid
            // 
            this._mainDataGrid.AllowUserToAddRows = false;
            this._mainDataGrid.AllowUserToDeleteRows = false;
            this._mainDataGrid.AllowUserToResizeRows = false;
            this._mainDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mainDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._mainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._mainDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.PressCount,
            this.ChatterCount,
            this.FailureRate});
            this._mainDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._mainDataGrid.Location = new System.Drawing.Point(6, 19);
            this._mainDataGrid.MultiSelect = false;
            this._mainDataGrid.Name = "_mainDataGrid";
            this._mainDataGrid.RowHeadersVisible = false;
            this._mainDataGrid.Size = new System.Drawing.Size(583, 204);
            this._mainDataGrid.TabIndex = 3;
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            // 
            // PressCount
            // 
            this.PressCount.HeaderText = "Press Count";
            this.PressCount.Name = "PressCount";
            // 
            // ChatterCount
            // 
            this.ChatterCount.HeaderText = "Chatter Count";
            this.ChatterCount.Name = "ChatterCount";
            // 
            // FailureRate
            // 
            this.FailureRate.HeaderText = "Failure Rate";
            this.FailureRate.Name = "FailureRate";
            // 
            // _dataGridGroupBox
            // 
            this._dataGridGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridGroupBox.Controls.Add(this._mainDataGrid);
            this._dataGridGroupBox.Location = new System.Drawing.Point(12, 152);
            this._dataGridGroupBox.Name = "_dataGridGroupBox";
            this._dataGridGroupBox.Size = new System.Drawing.Size(595, 229);
            this._dataGridGroupBox.TabIndex = 4;
            this._dataGridGroupBox.TabStop = false;
            this._dataGridGroupBox.Text = "Key Statistics";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._activateOnLaunchCheckBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._minimizeCheckBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._thresholdTimeInput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 98);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // _activateOnLaunchCheckBox
            // 
            this._activateOnLaunchCheckBox.AutoSize = true;
            this._activateOnLaunchCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._activateOnLaunchCheckBox.Location = new System.Drawing.Point(112, 26);
            this._activateOnLaunchCheckBox.Name = "_activateOnLaunchCheckBox";
            this._activateOnLaunchCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activateOnLaunchCheckBox.TabIndex = 7;
            this._activateOnLaunchCheckBox.UseVisualStyleBackColor = true;
            this._activateOnLaunchCheckBox.CheckedChanged += new System.EventHandler(this.OnActivateOnLaunchCheckBox);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Activate on Launch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ms";
            // 
            // _minimizeCheckBox
            // 
            this._minimizeCheckBox.AutoSize = true;
            this._minimizeCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._minimizeCheckBox.Location = new System.Drawing.Point(112, 48);
            this._minimizeCheckBox.Name = "_minimizeCheckBox";
            this._minimizeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._minimizeCheckBox.TabIndex = 4;
            this._minimizeCheckBox.UseVisualStyleBackColor = true;
            this._minimizeCheckBox.CheckedChanged += new System.EventHandler(this.OnMinimizeCheckBoxValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Launch Minimized";
            // 
            // _thresholdTimeInput
            // 
            this._thresholdTimeInput.Location = new System.Drawing.Point(112, 68);
            this._thresholdTimeInput.Name = "_thresholdTimeInput";
            this._thresholdTimeInput.Size = new System.Drawing.Size(47, 20);
            this._thresholdTimeInput.TabIndex = 2;
            this._thresholdTimeInput.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._thresholdTimeInput.ValueChanged += new System.EventHandler(this.OnThresholdTimeInputValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chatter Threshold";
            // 
            // _notifyIcon
            // 
            this._notifyIcon.ContextMenuStrip = this._notifyIconMenuStrip;
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "Keyboard Unchatter";
            this._notifyIcon.Visible = true;
            this._notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnNotifyIconClick);
            // 
            // _notifyIconMenuStrip
            // 
            this._notifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openMenuItem,
            this.toolStripMenuItem1,
            this._exitMenuItem});
            this._notifyIconMenuStrip.Name = "_notifyIconMenuStrip";
            this._notifyIconMenuStrip.Size = new System.Drawing.Size(104, 54);
            this._notifyIconMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnNotifyIconMenuStripItemClicked);
            // 
            // _openMenuItem
            // 
            this._openMenuItem.Name = "_openMenuItem";
            this._openMenuItem.Size = new System.Drawing.Size(103, 22);
            this._openMenuItem.Text = "Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // _exitMenuItem
            // 
            this._exitMenuItem.Name = "_exitMenuItem";
            this._exitMenuItem.Size = new System.Drawing.Size(103, 22);
            this._exitMenuItem.Text = "Exit";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 426);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._dataGridGroupBox);
            this.Controls.Add(this._buttonActivate);
            this.Controls.Add(this._statusPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "MainWindow";
            this.Text = "Keyboard Unchatter";
            this.Resize += new System.EventHandler(this.OnMainWindowResize);
            this._statusPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainDataGrid)).EndInit();
            this._dataGridGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._thresholdTimeInput)).EndInit();
            this._notifyIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _statusPanel;
        private System.Windows.Forms.Button _buttonActivate;
        private System.Windows.Forms.DataGridView _mainDataGrid;
        private System.Windows.Forms.GroupBox _dataGridGroupBox;
        private System.Windows.Forms.Label _statusPanelLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox _minimizeCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _thresholdTimeInput;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.ContextMenuStrip _notifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _openMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _exitMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn PressCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChatterCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FailureRate;
        private System.Windows.Forms.CheckBox _activateOnLaunchCheckBox;
        private System.Windows.Forms.Label label4;
    }
}

