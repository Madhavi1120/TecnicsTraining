using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        var serverIp = "192.168.1.5"; 
        var serverPort = 1234;

        var client = new TcpClient();
        client.Connect(serverIp, serverPort);
        while(true)
        {
            var stream = client.GetStream();
            Console.Write(">> ");
            var messageToServer = Console.ReadLine();
            var messageBytes = Encoding.UTF8.GetBytes(messageToServer);
            stream.Write(messageBytes, 0, messageBytes.Length);
            var bytesToRead = new byte[client.ReceiveBufferSize];
            var bytesRead = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.UTF8.GetString(bytesToRead, 0, bytesRead));
        }

        client.Close();
    }
}

