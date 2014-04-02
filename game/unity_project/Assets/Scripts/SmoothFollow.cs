/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/
using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    float distance = 8.0f;
    float height = 12.0f;

    float heightDamping = 2.0f;
    float rotationDamping = 3.0f;

    void LateUpdate ()
    {
        if (!target)
            return;
    
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;
        
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;
    
        currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);


        Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
    
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    
        transform.LookAt (target);
    }
}