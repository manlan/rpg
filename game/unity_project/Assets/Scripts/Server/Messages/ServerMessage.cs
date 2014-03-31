public abstract class ServerMessage
{
    public abstract string BuildMessage();

    public static ServerMessage FromString(string message) {
        string[] pieces = message.Split('|');
        string id = pieces[0];
        string[] args = pieces[1].Split(':');
        return null;
    }
}


