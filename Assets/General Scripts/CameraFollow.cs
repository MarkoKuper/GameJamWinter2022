using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
 /// This script make the camera follow a target yay;
 /// </summary>
    public Transform target; //Put the target to follow
    public float smoothing = 5f; //The smoothing of the camera when following
    Vector3 offset;  //How far the camera is

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime); //If the player move super fast it lerp back to it.
    }
}
