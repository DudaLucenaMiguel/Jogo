using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDoProximoDano : MonoBehaviour
{
    public Image proximoAtaque;
    public Transform camera;

    private void Awake()
    {
        camera = Camera.main.transform;
    }
    void Update()
    {
        transform.LookAt(transform.position + camera.forward);
    }
    public void AlterarBarraDeProximoDano(float timer, float frequencia)
    {
        proximoAtaque.fillAmount = (float)timer / frequencia;
    }
}
