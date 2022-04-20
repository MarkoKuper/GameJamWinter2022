using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 20;

    public Waypoints myRoute;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        
        target = myRoute.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, dir), Time.deltaTime * rotationSpeed);
                                                                                                                  
        if (Vector3.Distance(transform.position, target.position) <= 0.25f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= myRoute.points.Length - 1)
        {
            EndOfPath();
            return;
        }

        waypointIndex++;
        target = myRoute.points[waypointIndex];
    }

    void EndOfPath()
    {
        //PlayerStats.instance.ReduceLives(); ;
        //WaveSpawner.instance.enemiesAlive--;
        waypointIndex = 0;
        target = myRoute.points[0];

    }
}
