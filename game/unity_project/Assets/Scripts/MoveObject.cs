using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
    public GameObject pointer;
    public Character character;
    private Movement characterMovement;

    // pointer

    void Start ()
    {
        characterMovement = character.GetComponent<Movement> ();
        pointer = Instantiate (pointer, Vector3.zero, Quaternion.Euler (Vector3.right * 90)) as GameObject;
        pointer.SetActive (false);
    }
    
    void OnMouseOver ()
    {
        try {
            pointer.transform.position = MouseHitPoint () + Vector3.up * 3;
            pointer.SetActive (true);
        } catch (MouseDoesNotHitException ignore) {
        }
    }
    
    void OnMouseExit ()
    {
        pointer.SetActive (false);
    }



    // movement 
  
    void OnMouseUpAsButton ()
    {
        OnMouseDrag ();
    }
    
    void OnMouseDrag ()
    {   
        try {
            characterMovement.AskFor (FindDestination ());
        } catch (MouseDoesNotHitException ignore) {
        }
    }

    private IntVector3 FindDestination ()
    {
        Vector3 hitPoint = MouseHitPoint ();
        return new IntVector3 (hitPoint.x, 1 + hitPoint.y, hitPoint.z);
    }

    private Vector3 MouseHitPoint ()
    {
        RaycastHit hit = new RaycastHit ();
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
       
        if (!collider.Raycast (ray, out hit, 1000.0f))
            throw new MouseDoesNotHitException ();

        return hit.point;
    }

    class MouseDoesNotHitException : System.Exception
    {
    }
}
