﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
namespace CLiennt
{
    
        class Program
        {
            private static TcpClient _clientSocket = null;
            private static Stream _nstream = null;
            private static StreamWriter _sWriter = null;
            private static StreamReader _sReader = null;
            static void Main(string[] args)
            {
                try
                {
                    
                    using (_clientSocket = new TcpClient("127.0.0.1", 7777))
                    {
                        using (_nstream = _clientSocket.GetStream())
                        {
                            
                           _sWriter = new StreamWriter(_nstream) { AutoFlush = true };
                        while (true)
                        {
                            Console.WriteLine("Write your message here Please note that if you want to save a book you should provide it in json format string in order to complate the saving command ");
                            string clientMsg = Console.ReadLine();

                            _sWriter.WriteLine(clientMsg);



                            _sReader = new StreamReader(_nstream);
                            string rdMsgFromServer = _sReader.ReadLine();
                            if (rdMsgFromServer != null)
                            {
                                Console.WriteLine(".....................................................");
                                Console.WriteLine("Client recieved Message from Server:" + rdMsgFromServer);
                                Console.WriteLine(".....................................................");

                            }
                            else
                            {
                                Console.WriteLine("Client recieved null message from Server ");
                            }
                        }
                        }
                    }
                    Console.WriteLine("Press enter to stop the client!");
                    Console.ReadKey();

            }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
            }

        }
    
}
