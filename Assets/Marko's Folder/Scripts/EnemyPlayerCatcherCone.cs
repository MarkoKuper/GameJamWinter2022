using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerCatcherCone : MonoBehaviour
{
    public float distance  = 5.0f;
    public float theAngle = 45;
    public float segments = 10;
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastSweep();
        }
    }

    void RaycastSweep()
    {
        Vector2 startPos = transform.position; // umm, start position !
        Vector2 targetPos = Vector2.zero; // variable for calculated end position

        float startAngle = -theAngle * 0.5f; // half the angle to the Left of the forward
        float finishAngle = theAngle * 0.5f; // half the angle to the Right of the forward

        // the gap between each ray (increment)
        var inc = theAngle / segments;



        // step through and find each target point
        for (float i = startAngle; i < finishAngle; i += inc ) // Angle from forward
        {
            targetPos = (Quaternion.Euler(0, i, 0) * transform.up).normalized * distance;

            RaycastHit2D hit = Physics2D.Linecast(startPos, targetPos, 1 << LayerMask.NameToLayer("Action"));

            // linecast between points
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Hit " + hit.collider.gameObject.name);
                }
                else
                {
                    Debug.Log("Player Not Hit");
                }
            }
            
            // to show ray just for testing
            Debug.DrawLine(startPos, targetPos, Color.green);
        }
    }

}
