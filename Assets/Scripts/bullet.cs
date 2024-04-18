using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;
    public int demage = 10;
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        DamageScript enemy = collision.transform.GetComponent<DamageScript>();

        if (enemy != null)
        {
            enemy.ApplyDamege(demage);
        }
    }
}
