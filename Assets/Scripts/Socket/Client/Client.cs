using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

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
        private Netword network;
        private String[] mes;
        private float[] temp;


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
            temp = new float[2];
            
        }

        public void setNetwork(Netword n)
        {
            network = n;
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
                    Debug.Log("Set Server");
                }
            }
            if (mess[0].Equals("S"))
            {
                spawn(mess.Substring(mess[1], mess[2]));
            }

            if (mess.Split(' ')[0].Equals("M"))
            {
                
                mes = mess.Split(' ');
                
                temp[0] = Convert.ToInt32(mes[2]);
                temp[1] = Convert.ToInt32(mes[3]);
                Debug.Log(temp[0]+" J "+temp[1]);
                network.Move(mes[1], temp[0], temp[1]);

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