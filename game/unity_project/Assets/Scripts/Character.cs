using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

    public string nickname;
    private Color originalColor;

    void Start ()
    {
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

    void FixedUpdate ()
    {
        transform.Rotate (Vector3.up * 36 * Time.deltaTime);
    }
}