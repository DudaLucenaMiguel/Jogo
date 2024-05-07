using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    InimigoScript inimigo;
    PlayerScript player;
    int dano;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        inimigo = collision.transform.GetComponent<InimigoScript>();
        player = collision.transform.GetComponent<PlayerScript>();
        AplicarDano();
    }
    void AplicarDano()
    {
        if (inimigo != null)
        {
            inimigo.AplicarDanoNoInimigo(dano);
        }
        if (player != null)
        {
            player.AplicarDanoNoPlayer(dano);
        }

    }
}
