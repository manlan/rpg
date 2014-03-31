public class MovementMessage : ServerMessage
{
    private readonly IntVector3 destination;

    public MovementMessage (IntVector3 destination)
    {
        this.destination = destination;
    }

    public string BuildMessage ()
    {
        //                             \\
        //                             \\
        //                             \\
        //                             \\
        // create class for that:     \\//
        //                            \\/
        //                            \/
        //                    .-----------------.
        return string.Format ("move|{0}:{1}:{2};", new object[] {
            destination.vector3.x,
            destination.vector3.y,
            destination.vector3.z
        });
    }
}   


