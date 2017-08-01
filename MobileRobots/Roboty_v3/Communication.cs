using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Roboty_v3
{
    public class Communication
    {
        private TcpClient Client;
        private BinaryWriter Writer;
        private BinaryReader Reader;
        private byte[] Data_Tab,Data_send;
        private string Data_Received;
        

        public Communication()
        {
            Data_Tab = new byte[28];
            Data_send = new byte[8];
        }

        public bool set_connection(string IP, int Port)
        {
            Client = new TcpClient();
            Client.ReceiveTimeout = 100;
            
            try
            {
                Console.WriteLine("Attempting to connect to: " + IP + ":" + Port);
                if (!Client.Connected)
                {

                    Client.Connect(IP, Port);//"127.0.0.1"//IP_host
                    Console.WriteLine("Connected!");
                    Writer = new BinaryWriter(Client.GetStream());
                    Reader = new BinaryReader(Client.GetStream());
                    return true;
                }
                else
                {
                    Console.WriteLine("Connected!");
                    Writer = new BinaryWriter(Client.GetStream());
                    Reader = new BinaryReader(Client.GetStream());
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Connection attempt failed.");
                Console.Beep();
                Client.Close();
                return false;
            }
        }
            




        public bool send(string message)
        {
            for (int i = 0; i <= 7; i++)
            {
                Data_send[i]= Convert.ToByte(Convert.ToChar(message.Substring(i, 1)));
            }
                try
                {
                    Writer.Write(Data_send,0,8);
                    return true;
                }
                catch (Exception)
                {
                    Client.Close();
                    return false;
                }

        }

        public string receive()
        {
            
           
            try
            {
                Reader.Read(Data_Tab,0,28);
                Data_Received = "";
                for (int i = 0; i <= 27; i++)
                {
                    Data_Received += (char)Data_Tab[i];
                }
                Console.WriteLine();
                return Data_Received;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Client.Close();
                return "Fail";
            }

        }
        public void clear_client_obj()
        {

            try
            {
                Client.Close();
            }
            catch (Exception) { }

            try
            {
                Writer.Close();
            }
            catch (Exception) { }

            try
            {
                Reader.Close();
            }
            catch (Exception) { }

            
        }

    }
}
