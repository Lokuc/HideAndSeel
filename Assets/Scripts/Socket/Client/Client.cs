using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

namespace com.severgames.lib.Socket
{
    class Client
    {
        const int port = 54324;
        const string address = "127.0.0.1";
        private byte[] dataOut = new byte[128];
        private byte[] data = new byte[128];
        private NetworkStream stream;
        private String message;
        StringBuilder builder;

        static void Main(string[] args)
        {
            new Client();
        }

        public Client()
        {
            Thread main = new Thread(new ThreadStart(Clienti));
            main.Start();
        }

        private void Clienti()
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                stream = client.GetStream();
                data = new byte[128];
                Thread th = new Thread(new ThreadStart(getMess));
                th.Start();

                while (true)
                {
                    // ввод сообщения
                    

                    
                    builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    message = builder.ToString();
                    Console.WriteLine(message);
                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }


        public void sendText(String text)
        {
            Thread t = new Thread(new ParameterizedThreadStart(sendTextT));
            t.Start(text);


        }

        private void getMess()
        {
            while (true)
            {
                string message = Console.ReadLine();
                sendText(message);
            }
        }

        private void sendTextT(object text)
        {

            dataOut = Encoding.Unicode.GetBytes(text.ToString());
            try
            {
                stream.Write(dataOut, 0, dataOut.Length);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

    }

}