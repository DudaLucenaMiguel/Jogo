using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    //variaveis de rotação;
    private float smoothTime = 0.05f;
    private float currentVelocity;

    
    //variaveis de movimento
    CharacterController Control;
    Vector3 move;
    public float speed = 10;
    private float horizontal;
    private float vertical;
    void Start()
    {
        Control = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        ApplyMovement();
        ApplyRotation();
    }
    public void ApplyMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        move = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);

        Control.Move(move);
    }
    public void ApplyRotation()
    {
        if (move.magnitude >= smoothTime)
        {
            var targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        

    }
}

