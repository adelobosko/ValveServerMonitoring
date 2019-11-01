using System;
using System.Text;

namespace Monitoring
{
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

        public A2S_INFO(byte[] bs)
        {
            var i = WorkHelper.IndexOf(bs, 0x49);
            header = bs[i];
            protocol = bs[i + 1];
            name = Encoding.UTF8.GetString(WorkHelper.SubArray(bs, i + 2, WorkHelper.IndexOf(bs, 0x00, i + 2) - (i + 2)));
            i = WorkHelper.IndexOf(bs, 0x00, i + 2);
            map = Encoding.UTF8.GetString(WorkHelper.SubArray(bs, i + 1, WorkHelper.IndexOf(bs, 0x00, i + 1) - (i + 1)));
            i = WorkHelper.IndexOf(bs, 0x00, i + 1);
            folder = Encoding.UTF8.GetString(WorkHelper.SubArray(bs, i + 1, WorkHelper.IndexOf(bs, 0x00, i + 1) - (i + 1)));
            i = WorkHelper.IndexOf(bs, 0x00, i + 1);
            game = Encoding.UTF8.GetString(WorkHelper.SubArray(bs, i + 1, WorkHelper.IndexOf(bs, 0x00, i + 1) - (i + 1)));
            i = WorkHelper.IndexOf(bs, 0x00, i + 1);
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
}