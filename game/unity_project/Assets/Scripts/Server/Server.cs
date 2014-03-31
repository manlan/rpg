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
        client.Connect ("127.0.0.1", 8765);
        StartReading();
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

    private class StateObject
    {
        public const int BufferSize = 3;
        public readonly byte[] buffer;
        public readonly StringBuilder result;
        
        public StateObject ()
        {
            this.buffer = new byte[BufferSize];
            this.result = new StringBuilder ();
        }
    }

    private static void StartReading ()
    {
        Receive (new StateObject ());
    }

    static void Receive (StateObject state)
    {
        client.BeginReceive (state.buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
    }
    
    private static void ReceiveCallback (IAsyncResult asyncResult)
    {
        StateObject state = (StateObject) asyncResult.AsyncState;
    
        // receives the data.
        int bytesRead = client.EndReceive (asyncResult);
        string receivedString = Encoding.ASCII.GetString (state.buffer, 0, bytesRead);
        state.result.Append (receivedString);

        // put commands read in this buffer in a queue.
        Debug.Log (state.result.ToString ());
      
        // continues reading recursively.
        Receive (state);       
    }
}
