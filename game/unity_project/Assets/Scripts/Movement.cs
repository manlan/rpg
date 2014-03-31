using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private float velocity = 1.0f;
    private IntVector3 destination;

    void Start ()
    {
        destination = new IntVector3 (transform.position);
    }
    
    void Update ()
    {
        if (!transform.position.Equals (destination))
            transform.position = Vector3.Slerp (transform.position, destination.vector3, Time.deltaTime * velocity);
    }
    
    public void AskFor (IntVector3 dest)
    {
        if (destination.Equals (dest))
            return;

        Server.Write (new MovementMessage (dest));
        MoveTo(dest);
    }

    public void MoveTo (IntVector3 dest)
    {
        destination = dest;
    }
}