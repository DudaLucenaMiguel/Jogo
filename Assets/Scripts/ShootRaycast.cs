using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRayCast : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fire;
    public GameObject hitPoint;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ApplyShooting();
        }
        
    }

    public void ApplyShooting()
    {
        RaycastHit hit;

        if(Physics.Raycast(firePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawLine(firePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            GameObject a = Instantiate(fire, firePoint.position, Quaternion.identity);
            GameObject b = Instantiate(hitPoint, hit.point, Quaternion.identity);

            Destroy(a, 1);
            Destroy(b, 1);

            DamageScript enemy = hit.transform.GetComponent<DamageScript>();

            if(enemy != null)
            {
                enemy.ApplyDamege(2);
            }
        }
        
    }
}
