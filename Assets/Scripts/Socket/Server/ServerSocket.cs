using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;

namespace com.severgames.lib.Socket
{
	public class ServerSocket
	{
		private const int PORT = 54324;
		private TcpListener listener;
		private List<ClientHandler> client = new List<ClientHandler>();
		private int clientCount = 0;
		private List<Thread> threads = new List<Thread>();
	


		public  ServerSocket()
		{
			Thread main = new Thread(new ThreadStart(Server));
			main.Start();
			

		}

		public void moveP(String name,double forseX,double forseY,int num)
        {
			
        }

		

		public void sendMessageToAll(String mess,int no)
        {
			for (int i = 0; i < clientCount; i++)
			{
				if (i == no)
                {
					continue;
                }
				client[i].sendText(mess);
            }
        }
		public void sendMessageToAll(String mess)
		{
			for (int i = 0; i < clientCount; i++)
			{
				client[i].sendText(mess);
			}
		}
		public void sendMessage(String mess,int num)
        {
			client[num].sendText(mess);
        }



		public void Server()
        {
			Console.WriteLine("ytth");
            try
            {
				listener = new TcpListener(IPAddress.Any,PORT);
				listener.Start();

                while (true)
                {
					client.Add(new ClientHandler(listener.AcceptTcpClient(),clientCount));
                    if (clientCount == 0)
                    {
						client[0].setServer(this);
                    }
					threads.Add(new Thread(new ThreadStart(Server)));
					threads[clientCount].Start();
					clientCount++;

				}



            }catch(Exception)
            {

            }
        }

	}


}