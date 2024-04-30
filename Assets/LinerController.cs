using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerController : MonoBehaviour
{
    LineRenderer linhaDeTiro;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        linhaDeTiro = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
