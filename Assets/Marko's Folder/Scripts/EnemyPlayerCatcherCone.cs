using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerCatcherCone : MonoBehaviour
{
    public float distance  = 5.0f;
    public float theAngle = 45;
    public float segments = 10;

    public SliderFill sliderFill;

    public AudioClip spottedPlayer;

    public bool thisHitPlayer;

    void Update()
    {
        
        RaycastSweep();
    }

    void RaycastSweep()
    {
        Vector2 startPos = transform.position; // umm, start position !
        Vector2 targetPos = new Vector2(0, 0); // variable for calculated end position

        float startAngle = -theAngle * 0.5f; // half the angle to the Left of the forward
        float finishAngle = theAngle * 0.5f; // half the angle to the Right of the forward

        // the gap between each ray (increment)
        var inc = theAngle / segments;

        // step through and find each target point
        for (float i = startAngle; i < finishAngle; i += inc ) // Angle from forward
        {
            
            Quaternion rayRotation = Quaternion.Euler(0, 0, i);
            targetPos = transform.position + (rayRotation * transform.up).normalized * distance;

            RaycastHit2D hit = Physics2D.Linecast(startPos, targetPos, 1 << LayerMask.NameToLayer("Action"));

            // linecast between points
            if (hit.collider != null)
            {

                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    if (sliderFill.playerSpotted == false)
                    {
                        sliderFill.TogglePlayerSpotted();
                        //AudioManager.instance.PlaySound(spottedPlayer, 1f);
                        thisHitPlayer = true;


                    }
                    Debug.Log("Hit " + hit.collider.gameObject.name);
                    break;
                }
                
            }
            else if(hit.collider == null && sliderFill.playerSpotted == true  && thisHitPlayer) 
            {
                //if (i > finishAngle + inc)
                {
                    sliderFill.TogglePlayerSpotted();
                    thisHitPlayer = false;
                }
            }
            
            Debug.DrawLine(startPos, targetPos, Color.green);
        }
        
    }

    //bool CheckAngle(float i, float finishAngle, float inc)
    //{
    //    bool angleIsBigger;
        
    //}

}
