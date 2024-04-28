using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int dano = 10;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Enemy enemy = collision.transform.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.ApplyDamege(dano);
        }
    }
}
