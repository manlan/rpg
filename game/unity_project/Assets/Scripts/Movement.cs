using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private float velocity = 1.0f;
    
    public void AskFor (IntVector3 destination)
    {
        Server.Write (new MovementMessage (destination));
        MoveTo (destination);
    }

    public void MoveTo (IntVector3 destination)
    {
        StopCoroutine ("Move");
        StartCoroutine ("Move", destination);
    }

    private IEnumerator Move (IntVector3 destination)
    {
        while (!isAt(destination)) {
            transform.position = Vector3.Slerp (transform.position, destination.vector3, Time.deltaTime * velocity);
            yield return null;
        }
    }

    private bool isAt(IntVector3 position) {
        return position.Equals(transform.position);
    }
}