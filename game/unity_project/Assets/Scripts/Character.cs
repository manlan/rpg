using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    private Color originalColor;
    private Movement movement;
    public int id = Random.Range (1, 100);

    void Awake ()
    {
        movement = new Movement (this);
        originalColor = transform.renderer.materials [1].color;
    }
    
    void OnCollisionEnter ()
    {
        transform.renderer.materials [1].color = Color.red;
    }

    void OnCollisionExit ()
    {
        transform.renderer.materials [1].color = originalColor;
    }

    public void MoveTo (IntVector3 destination)
    {
        movement.MoveTo (destination);
    }

    public void AskServerToMoveTo (IntVector3 destination)
    {
        movement.AskServerToMoveTo (destination);
    }

    void OnMouseUpAsButton ()
    {
        //TODO: remove this. temporary.
        Application.setPlayer (this);
    }
}