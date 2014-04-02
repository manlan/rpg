public abstract class ServerMessage
{
    public abstract string BuildMessage();

    public static ServerMessage FromString(string message) {
        return null;
    }
}


