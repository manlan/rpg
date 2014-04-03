using UnityEngine;
using System.Collections;

public class MovementMessage : ServerMessage
{
    private readonly IntVector3 destination;
   
    public MovementMessage (IntVector3 destination)
    {
        this.destination = destination;
    }

    public override string BuildMessage ()
    {
        //                             \\
        //                             \\
        //                             \\
        //                             \\
        // create class for that:     \\//
        //                            \\/
        //                            \/
        //                    .-----------------.
        return string.Format ("{0}|move|{1}|{2}|{3};", new object[] {
            Application.currentPlayer ().id,
            destination.vector3.x,
            destination.vector3.y,
            destination.vector3.z
        });
    }

    public static void Process (string command)
    {
        string[] args = FromString (command);
        int id = int.Parse (args [0]);
        float x = float.Parse (args [2]);
        float y = float.Parse (args [3]);
        float z = float.Parse (args [4]);

        Application.InstantiateCharacter(id).MoveTo (new IntVector3 (x, y, z));
    }
}   


