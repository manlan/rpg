using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    private Color originalColor;
    private Movement movement;
    public int id;

    void Start ()
    {
        id = Random.Range (1, 100);
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
        movement.GoTo (destination);
    }

    void OnMouseUpAsButton ()
    {
        //TODO: remove this. temporary.
        Application.setPlayer(this);
    }
}