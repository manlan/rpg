using UnityEngine;
using System.Collections;

public abstract class ServerMessage
{
    public abstract string BuildMessage ();

    public static string[] FromString (string message)
    {
        return message.Split('|');
    }
}


