using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace com.severgames.lib.Socket
{
    public class ClientHandler 
	{

		TcpClient client;
		int num;
		NetworkStream stream;
		private byte[] data = new byte[128];
        private byte[] dataOut = new byte[128];
        private static ServerSocket server;

		public ClientHandler(TcpClient client,int num)
		{
			this.num = num;
			this.client = client;
			Thread main = new Thread(new ThreadStart(Server));
			main.Start();
			

		}
        public void setServer(ServerSocket s)
        {
            server = s;
        }

        

        public void Server()
        {
            try
            {
				stream = client.GetStream();
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    Thread thh = new Thread(new ParameterizedThreadStart(work));
                    thh.Start(message);
                    Console.WriteLine(message);
                }
            }
            catch(Exception)
            { 

            }
			
        }

        public void sendText(String text)
        {
            Thread t = new Thread(new ParameterizedThreadStart(sendTextT));
            t.Start(text);

            
        }

        private void work(object mesf)
        {
            String mess = mesf.ToString();
            if (mess[0].Equals("S"))
            {
                
            }else {
                server.sendMessageToAll(mess, num);
            }

            //todo
            if(mess[0].Equals("M"))
            {
                server.moveP(mess.Substring(mess[1],mess[2]),Convert.ToDouble(mess.Substring(mess[3],mess[4])), Convert.ToDouble(mess.Substring(mess[5], mess[6])),num);
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