using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        //string ipaddress = "localhost";

        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip,8080);
            TcpClient client = default(TcpClient);
            try
            {
                server.Start();
                Console.WriteLine("Server started");
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }
            while(true)
            {
                client = server.AcceptTcpClient();
                string msg;

                byte[] readBuffer = new byte[100];
                NetworkStream network = client.GetStream();
                network.Read(readBuffer, 0, readBuffer.Length);
                string msg1 = Encoding.ASCII.GetString(readBuffer, 0, readBuffer.Length);
                StringBuilder buildermsg = new StringBuilder();
                Console.WriteLine(msg1);
                msg = Console.ReadLine();
                //byte[] sendBuffer = new byte[100];
               // sendBuffer = Encoding.ASCII.GetBytes(msg);
              //  network.Write(sendBuffer, 0, sendBuffer.Length);
                //Console.Read();

            }

        
        }
    }
}
