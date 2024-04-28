using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int vidaMaxima = 50;
    public int vidaAtual;

    public BarraDeVida barraDeVida;

    public void Start()
    {
        vidaAtual = vidaMaxima;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMaxima);
    }
    public void ApplyDamege(int demage)
    {
        vidaAtual -= demage;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMaxima);

        if (vidaAtual<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
