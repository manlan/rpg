using UnityEngine;
using System.Collections;

class NPCMessage : ServerMessage
{
    private string nickname;

    public NPCMessage (string nickname)
    {
        this.nickname = nickname;
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
    //                        .--------.
        return string.Format ("npc|{0};", nickname);
    }
}

