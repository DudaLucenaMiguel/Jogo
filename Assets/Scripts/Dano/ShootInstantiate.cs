using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInstantiate : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    public float bulletSpeed = 10;

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed;
        }
    }
}
