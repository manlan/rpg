using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System;
using System.Net;
using System.Threading;
using System.Text;

public class Server
{
    private readonly static Socket client = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
    public static void Start ()
    {
        client.Connect ("192.168.0.109", 8765);
        StartReading ();
    }

    //
    //
    //
    //
    // writing
    
    public static void Write (ServerMessage msg)
    {
        client.Send (Encoding.ASCII.GetBytes (msg.BuildMessage ()));
    }

    //
    //
    //
    //
    // reading

    private class SocketIncoming
    {
        public readonly static Queue commandQueue = new Queue ();
        public const int BufferSize = 256;
        public readonly byte[] buffer;
        public String commands;
        
        public SocketIncoming ()
        {
            this.buffer = new byte[BufferSize];
            this.commands = String.Empty;
        }

        public void StoreNewChunk (IAsyncResult asyncResult)
        {
            int byteChunk = client.EndReceive (asyncResult);
            string chunk = Encoding.ASCII.GetString (buffer, 0, byteChunk);
            this.commands += chunk;
        }

        public void EnqueueCommandsReceived ()
        {
            if (!commands.Contains (";")) {
                Debug.Log ("No command received");
                return;
            }

            string[] commandArray = commands.Split (';');
            
            foreach (string c in commandArray) {
                string command = c.Trim ();
                if (!String.IsNullOrEmpty (command))
                    commandQueue.Enqueue(command);
            }

            this.commands = commandArray [commandArray.Length - 1];
        }
    }

    private static void StartReading ()
    {
        Receive (new SocketIncoming ());
    }

    static void Receive (SocketIncoming incomming)
    {
        client.BeginReceive (incomming.buffer, 0, SocketIncoming.BufferSize, 0, ReceiveCallback, incomming);
    }
    
    private static void ReceiveCallback (IAsyncResult asyncResult)
    {
        SocketIncoming incomming = (SocketIncoming)asyncResult.AsyncState;
   
        incomming.StoreNewChunk (asyncResult);
        incomming.EnqueueCommandsReceived ();
        Receive (incomming);       
    }

    public static void ProcessNext ()
    {
        if (SocketIncoming.commandQueue.Count > 0)
            MovementMessage.Process ((string) SocketIncoming.commandQueue.Dequeue());

    }

}
