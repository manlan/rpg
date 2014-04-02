using UnityEngine;
using System.Collections;

public class Movement
{
    private float velocity = 1.0f;
    private readonly Character character;

    public Movement (Character character)
    {
        this.character = character;
    }


    //


    public void GoTo (IntVector3 destination)
    {
        Server.Write (new MovementMessage (destination));
        MoveTo (destination);
    }

    private void MoveTo (IntVector3 destination)
    {
        character.StopAllCoroutines(); //FIXME: Dangerous
        character.StartCoroutine (Move(destination));
    }

    private IEnumerator Move (IntVector3 destination)
    {
        while (!isAt(destination)) {
            character.transform.position = Vector3.Slerp (character.transform.position, destination.vector3, Time.deltaTime * velocity);
            yield return null;
        }
    }

    private bool isAt (IntVector3 position)
    {
        return position.Equals (character.transform.position);
    }
}