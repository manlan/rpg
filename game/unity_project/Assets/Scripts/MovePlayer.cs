using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    void OnMouseUpAsButton ()
    {
        OnMouseDrag ();
    }
    
    void OnMouseDrag ()
    {   
        try {
            Application.currentPlayer().AskServerToMoveTo (FindDestination ());
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
