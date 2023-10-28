using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public bool useDamping = true;
    [Range(0.5f, 10f)]
    public float dampingSnappyness = 3;

    // Start is called before the first frame update
    void Start()
    {
        if(target== null)
		{
            Debug.LogWarning("No target assigned to camera follow! Please assign a target in the Inspector window.");
            enabled = false;
            return;
		}
    }

    // Use LateUpdate to move the camera! it happens after all other update functions
    void LateUpdate()
    {
        Vector3 destination = target.position + Vector3.back * 10;

        if (useDamping)
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * dampingSnappyness);
        else
            transform.position = destination;
    }
}
