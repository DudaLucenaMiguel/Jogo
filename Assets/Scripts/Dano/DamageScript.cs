using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int life = 10;

    public void ApplyDamege(int demage)
    {
        life -= demage;

        if(life<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
