using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.VFX;

namespace com.severgames.lib.Socket
{
    class Client
    {
        const int port = 54324;
        string address = "127.0.0.1";
        private byte[] dataOut = new byte[128];
        private byte[] data = new byte[128];
        private NetworkStream stream;
        private String message;
        StringBuilder builder;
        bool isServer;


        private static Client instaint;
        public static Client getClient()
        {
            if (instaint == null)
            {
                instaint = new Client();
            }
            return instaint;
        }

        public Client()
        {
            isServer = false;
            
        }

        public void run(String ip)
        {
            address = ip;
            Thread main = new Thread(new ThreadStart(Clienti));
            main.Start();
        }

        private void Clienti()
        {
            TcpClient client = null;
            try
            {
                Debug.Log("полетели");
                client = new TcpClient(address, port);
                stream = client.GetStream();
                data = new byte[128];
                Thread th = new Thread(new ThreadStart(getMess));
                th.Start();
                sendText("QVersion:0.1 Name:Default");
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
                    Thread thh = new Thread(new ParameterizedThreadStart(work));
                    thh.Start(message);
                    Console.WriteLine(message);
                  
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        public void work(object mesf)
        {
            String mess = mesf.ToString();
            if (mess[0].Equals("S"))
            {
                if (mess[1].Equals("A"))
                {
                    isServer = true;
                }
            }
            if (mess[0].Equals("S"))
            {
                spawn(mess.Substring(mess[1], mess[2]));
            }
            if (mess[0].Equals("M"))
            {
                move(mess.Substring(mess[1], mess[2]), Convert.ToDouble(mess.Substring(mess[3], mess[4])), Convert.ToDouble(mess.Substring(mess[5], mess[6])));
            }
        }

        private void spawn(String name)
        {
            //TODO
        }

        private void move(String name,double x,double y)
        {

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