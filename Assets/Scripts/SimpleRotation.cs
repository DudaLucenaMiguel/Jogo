using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public float rotationAmount = 2f;
    public int ticksPerSecond = 60;
    public bool pause = false;
    

    
    void Update()
    {
        
    }
    private void Start()
    {
        Rotate();
    }
    private IEnumerable Rotate()
    {
        WaitForSeconds wait = new WaitForSeconds(1 / ticksPerSecond);
        while(true)
        {
            if(!pause)
            {
                transform.Rotate(Vector3.up * rotationAmount);
            }
            yield return wait;
        }
    }
}


