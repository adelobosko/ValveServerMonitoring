namespace Monitoring
{
    partial class MonitoringForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkServerPlayersTimer = new System.Windows.Forms.Timer(this.components);
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ipToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.portToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.getInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeCheckToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.checkNToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.serverStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkServerStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverStatsTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkServerPlayersTimer
            // 
            this.checkServerPlayersTimer.Interval = 1000;
            this.checkServerPlayersTimer.Tick += new System.EventHandler(this.checkServerPlayers_Tick);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 27);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.resultTextBox);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.logTextBox);
            this.mainSplitContainer.Size = new System.Drawing.Size(801, 591);
            this.mainSplitContainer.SplitterDistance = 294;
            this.mainSplitContainer.TabIndex = 10;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTextBox.Location = new System.Drawing.Point(0, 0);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultTextBox.Size = new System.Drawing.Size(801, 294);
            this.resultTextBox.TabIndex = 6;
            // 
            // logTextBox
            // 
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Location = new System.Drawing.Point(0, 0);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(801, 293);
            this.logTextBox.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ipToolStripTextBox,
            this.portToolStripTextBox,
            this.getInfoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 27);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ipToolStripTextBox
            // 
            this.ipToolStripTextBox.Name = "ipToolStripTextBox";
            this.ipToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.ipToolStripTextBox.Text = "94.130.34.113";
            // 
            // portToolStripTextBox
            // 
            this.portToolStripTextBox.Name = "portToolStripTextBox";
            this.portToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.portToolStripTextBox.Text = "26900";
            // 
            // getInfoToolStripMenuItem
            // 
            this.getInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverAboutToolStripMenuItem,
            this.serverStatsToolStripMenuItem});
            this.getInfoToolStripMenuItem.Name = "getInfoToolStripMenuItem";
            this.getInfoToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.getInfoToolStripMenuItem.Text = "GetInfo";
            // 
            // serverAboutToolStripMenuItem
            // 
            this.serverAboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkPlayersToolStripMenuItem});
            this.serverAboutToolStripMenuItem.Name = "serverAboutToolStripMenuItem";
            this.serverAboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serverAboutToolStripMenuItem.Text = "ServerAbout";
            this.serverAboutToolStripMenuItem.Click += new System.EventHandler(this.serverAboutToolStripMenuItem_Click);
            // 
            // checkPlayersToolStripMenuItem
            // 
            this.checkPlayersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeCheckToolStripComboBox,
            this.checkNToolStripTextBox});
            this.checkPlayersToolStripMenuItem.Name = "checkPlayersToolStripMenuItem";
            this.checkPlayersToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.checkPlayersToolStripMenuItem.Text = "CheckPlayers";
            this.checkPlayersToolStripMenuItem.Click += new System.EventHandler(this.checkPlayersToolStripMenuItem_Click);
            // 
            // typeCheckToolStripComboBox
            // 
            this.typeCheckToolStripComboBox.Items.AddRange(new object[] {
            "< max",
            "< max - N",
            "< N"});
            this.typeCheckToolStripComboBox.Name = "typeCheckToolStripComboBox";
            this.typeCheckToolStripComboBox.Size = new System.Drawing.Size(121, 23);
            // 
            // checkNToolStripTextBox
            // 
            this.checkNToolStripTextBox.Name = "checkNToolStripTextBox";
            this.checkNToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // serverStatsToolStripMenuItem
            // 
            this.serverStatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkServerStatsToolStripMenuItem});
            this.serverStatsToolStripMenuItem.Name = "serverStatsToolStripMenuItem";
            this.serverStatsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serverStatsToolStripMenuItem.Text = "ServerStats";
            this.serverStatsToolStripMenuItem.Click += new System.EventHandler(this.serverStatsToolStripMenuItem_Click);
            // 
            // checkServerStatsToolStripMenuItem
            // 
            this.checkServerStatsToolStripMenuItem.Name = "checkServerStatsToolStripMenuItem";
            this.checkServerStatsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkServerStatsToolStripMenuItem.Text = "checkServerStats";
            this.checkServerStatsToolStripMenuItem.Click += new System.EventHandler(this.checkServerStatsToolStripMenuItem_Click);
            // 
            // serverStatsTimer
            // 
            this.serverStatsTimer.Interval = 1000;
            this.serverStatsTimer.Tick += new System.EventHandler(this.serverStatsTimer_Tick);
            // 
            // MonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 618);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MonitoringForm";
            this.Text = "MonitoringForm";
            this.Load += new System.EventHandler(this.MonitoringForm_Load);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer checkServerPlayersTimer;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox ipToolStripTextBox;
        private System.Windows.Forms.ToolStripTextBox portToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem getInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverStatsToolStripMenuItem;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ToolStripMenuItem checkPlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox typeCheckToolStripComboBox;
        private System.Windows.Forms.ToolStripTextBox checkNToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem checkServerStatsToolStripMenuItem;
        private System.Windows.Forms.Timer serverStatsTimer;
    }
}

