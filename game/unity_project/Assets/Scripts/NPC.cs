using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{

    public string nickname;
    public GameObject onMouseOverLight;
    
    void Start ()
    {
        OnMouseExit ();
    }

    void OnMouseEnter ()
    {
        onMouseOverLight.SetActive (true);
    }

    void OnMouseExit ()
    {
        onMouseOverLight.SetActive (false);
    }
}
