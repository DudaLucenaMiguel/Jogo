using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimplePatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint = 0;
    public float speed;
  
    void Start()
    {
        
    }
    void Update()
    {
        if(transform.position == patrolPoints[targetPoint].position)
        {
            targetPoint++;
            if (targetPoint >= patrolPoints.Length)
            {
                targetPoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        this.transform.LookAt(patrolPoints[targetPoint]);
    }
   
}
