using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Monitoring
{
    public partial class MonitoringForm : Form
    {
        public MonitoringForm()
        {
            InitializeComponent();
        }

        private void MonitoringForm_Load(object sender, EventArgs e)
        {
            typeCheckToolStripComboBox.SelectedIndex = 0;
            typeCheckToolStripComboBox.SelectedIndexChanged += (o, args) =>
            {
                switch (typeCheckToolStripComboBox.SelectedIndex)
                {
                    case 1:
                    case 2:
                        checkNToolStripTextBox.Enabled = true;
                        break;
                    default:
                        checkNToolStripTextBox.Enabled = false;
                        break;
                }
            };
        }

        private void checkServerPlayers_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                var a2sInfo = WorkHelper.GetA2S_INFO(ipToolStripTextBox.Text, portToolStripTextBox.Text, out var logText);
                if (a2sInfo == null)
                    return;

                Invoke(new Action(() =>
                {
                    resultTextBox.Text += a2sInfo.GetText() + "\r\n";
                    logTextBox.Text += $"{logText}\r\n\r\n";

                    var n = 0;
                    try
                    {
                        n = Convert.ToInt32(checkNToolStripTextBox.Text);
                    }
                    catch { }
                    switch (typeCheckToolStripComboBox.SelectedIndex)
                    {
                        case 0:
                        {
                            if (a2sInfo.players < a2sInfo.max_players)
                                Console.Beep(5000, 300);
                            break;
                        }
                        case 1:
                        {
                            if (a2sInfo.players < a2sInfo.max_players - n)
                                Console.Beep(5000, 300);
                            break;
                        }
                        default:
                        {
                            if (a2sInfo.players < n)
                                Console.Beep(5000, 300);
                            break;
                        }
                    }
                }));
            }).Start();


        }

        private void serverAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a2sInfo = WorkHelper.GetA2S_INFO(ipToolStripTextBox.Text, portToolStripTextBox.Text, out var logText);
            if (a2sInfo == null)
                return;
            resultTextBox.Text += a2sInfo.GetText() + "\r\n";
            logTextBox.Text += $"{logText}\r\n\r\n";
        }

        private void serverStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = WorkHelper.GetServerStats(ipToolStripTextBox.Text, portToolStripTextBox.Text, out var logText);

            logTextBox.Text += $"{logText}\r\n\r\n";
            resultTextBox.Text += res + "\r\n";


        }

        private void checkPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkPlayersToolStripMenuItem.Checked = !checkPlayersToolStripMenuItem.Checked;
            checkServerPlayersTimer.Enabled = checkPlayersToolStripMenuItem.Checked;
        }

        private void checkServerStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkServerStatsToolStripMenuItem.Checked = !checkServerStatsToolStripMenuItem.Checked;
            serverStatsTimer.Enabled = checkServerStatsToolStripMenuItem.Checked;
        }



        private void serverStatsTimer_Tick(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                var res = WorkHelper.GetServerStats(ipToolStripTextBox.Text, portToolStripTextBox.Text, out _);
                if (res == "ERROR")
                    return;
                var timeStr = res.Replace("\r", "").Split('\n').Single(str => str.Contains("CurrentServerTime"))
                    .Split(':')[1];
                var time = int.Parse(timeStr);
                var day = time / 24000 + 1;
                var hour = (time % 24000) / 1000;
                var mins = ((time % 1000) * 60) / 1000;
                if (hour == 6 || (hour == 5 && mins >= 40 && mins <= 60))
                    Console.Beep(5000, 300);

                Invoke(new Action(() => { resultTextBox.Text = $"{day} {hour} {mins}"; }));
            }).Start();
        }
    }


}
