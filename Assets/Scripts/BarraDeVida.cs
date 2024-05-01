using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image vidaRestante;
    public Transform camera;

    private void Awake()
    {
        camera = Camera.main.transform;
    }
    void Update()
    {
        transform.LookAt(transform.position + camera.forward);
    }
    public void AlterarBarraDeVida(int vidaAtual, int vidaMaxima)
    {
        vidaRestante.fillAmount = (float) vidaAtual / vidaMaxima;
    }
}
