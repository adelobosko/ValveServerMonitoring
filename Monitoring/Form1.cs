using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Monitoring
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }



        public static byte[] SubArray(byte[] data, int index, int length)
        {
            byte[] result = new byte[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public class A2S_INFO
        {
            byte header;
            byte protocol;
            string name;
            string map;
            string folder;
            string game;
            short id;
            public byte players { get; set; }
            public byte max_players { get; set; }
            byte bots;
            byte server_type;
            byte environment;
            byte visibility;
            byte VAC;
            private static int IndexOf(byte[] data, byte b, int start = 0)
            {
                var i = -1;
                for (var j = start; j < data.Length; j++)
                    if (data[j] == b)
                    {
                        i = j;
                        break;
                    }
                return i;
            }

            public A2S_INFO(byte[] bs)
            {
                int i = IndexOf(bs, 0x49);
                header = bs[i];
                protocol = bs[i + 1];
                name = Encoding.UTF8.GetString(SubArray(bs, i + 2, IndexOf(bs, 0x00, i + 2) - (i + 2)));
                i = IndexOf(bs, 0x00, i + 2);
                map = Encoding.UTF8.GetString(SubArray(bs, i + 1, IndexOf(bs, 0x00, i + 1) - (i + 1)));
                i = IndexOf(bs, 0x00, i + 1);
                folder = Encoding.UTF8.GetString(SubArray(bs, i + 1, IndexOf(bs, 0x00, i + 1) - (i + 1)));
                i = IndexOf(bs, 0x00, i + 1);
                game = Encoding.UTF8.GetString(SubArray(bs, i + 1, IndexOf(bs, 0x00, i + 1) - (i + 1)));
                i = IndexOf(bs, 0x00, i + 1);
                id = BitConverter.ToInt16(new byte[2] { bs[i + 1], bs[i + 2] }, 0);
                players = bs[i + 3];
                max_players = bs[i + 4];
                bots = bs[i + 5];
                server_type = bs[i + 6];
                environment = bs[i + 7];
                visibility = bs[i + 8];
                VAC = bs[i + 9];
            }

            public string GetText()
            {
                string str = string.Format("Header: {0}\r\nProtocol: {1}\r\nName: {2}\r\nMap: {3}\r\nFolder: {4}\r\nGame: {5}\r\nID: {6}\r\nPlayers: {7}\r\nMax Players: {8}\r\nBots: {13}\r\nServer Type: {9}\r\nEnvironment: {10}\r\nVisibility: {11}\r\nVAC: {12}", Convert.ToInt32(header), Convert.ToInt32(protocol), name, map, folder, game, id, players, max_players, server_type, environment, visibility, VAC, bots);
                return str;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var client = new UdpClient();
                client.Client.SendTimeout = 500;
                client.Client.ReceiveTimeout = 500;
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(textBox_IP.Text), Int32.Parse(textBox_PORT.Text));
                client.Connect(ep);
                var r_bytes = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00 };
                client.Send(r_bytes, r_bytes.Length);

                // then receive data
                var receivedData = client.Receive(ref ep);

                //System.Text.Encoding.UTF8.GetString(receivedData)
                client.Close();
                var info = new A2S_INFO(receivedData);
                textBox_RES.Text = info.GetText();

                if (checkBox1.Checked) textBox_RES.Text += "\r\n" + ByteArrayToString(receivedData);
                Console.Beep(5000, 100);


            }
            catch
            {
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox2.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var client = new UdpClient();
                client.Client.SendTimeout = 500;
                client.Client.ReceiveTimeout = 500;
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(textBox_IP.Text), Int32.Parse(textBox_PORT.Text));
                client.Connect(ep);
                var r_bytes = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00 };
                client.Send(r_bytes, r_bytes.Length);


                var receivedData = client.Receive(ref ep);

                //System.Text.Encoding.UTF8.GetString(receivedData)
                client.Close();
                var info = new A2S_INFO(receivedData);
                textBox_RES.Text = info.GetText();

                if (checkBox1.Checked) textBox_RES.Text += "\r\n" + ByteArrayToString(receivedData);

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                    {
                        if (info.players < info.max_players) Console.Beep(5000, 300);
                        break;
                    }
                    case 1:
                    {
                        if (info.players < info.max_players - 1) Console.Beep(5000, 300);
                        break;
                    }
                    default:
                    {
                        int n = 15;
                        try
                        {
                            n = Convert.ToInt32(textBox1.Text);
                        }
                        catch { }
                        if (info.players < n) Console.Beep(5000, 300);
                        break;
                    }
                }
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 2: textBox1.Enabled = true; break;
                default: { textBox1.Enabled = false; break; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] receivedData2;

            try
            {
                var client = new UdpClient();
                client.Client.SendTimeout = 500;
                client.Client.ReceiveTimeout = 500;
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(textBox_IP.Text), Int32.Parse(textBox_PORT.Text));
                client.Connect(ep);
                var A2S_RULES = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x56, 0xFF, 0xFF, 0xFF, 0xFF };
                client.Send(A2S_RULES, A2S_RULES.Length);

                // then receive data
                receivedData2 = client.Receive(ref ep);
                client.Close();
                //System.Text.Encoding.UTF8.GetString(receivedData)

                //var info = new A2S_INFO(receivedData);
                //textBox_RES.Text = info.GetText();

                if (checkBox1.Checked) textBox_RES.Text += "\r\n\r\n" + ByteArrayToString(receivedData2);

                Console.Beep(5000, 100);



                /* client.Send(receivedData2, receivedData2.Length);
     
                 // then receive data
                 var receivedData3 = client.Receive(ref ep);
                 if (checkBox1.Checked) textBox_RES.Text += "\r\n\r\n" + ByteArrayToString(receivedData3);
                 Console.Beep(5000, 100);*/
            }
            catch
            {
                receivedData2 = null;
            }
            if (receivedData2 == null) return;

            try
            {
                var client = new UdpClient();
                client.Client.SendTimeout = 500;
                client.Client.ReceiveTimeout = 500;
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(textBox_IP.Text), Int32.Parse(textBox_PORT.Text));
                client.Connect(ep);
                receivedData2[4] = 0x56;
                client.Send(receivedData2, receivedData2.Length);

                // then receive data
                var receivedData3 = client.Receive(ref ep);
                client.Close();
                if (checkBox1.Checked) textBox_RES.Text += "\r\n\r\n" + ByteArrayToString(receivedData3);

                Console.Beep(5000, 100);
            }
            catch
            {
                /*working python code:

time = 8158533
day = int((time/24000)+1)
hour = int(float((time % 24000)/1000))
mins = int(float(float(time%1000)*60)/1000)
print day,hour,mins */
            }
        }
    }


}
