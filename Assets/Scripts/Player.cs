using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    CharacterController CC;

    //variaveis de movimento
    public float velocidadeDoPlayer = 10;
    Vector3 direcao;
    public float velocidadeDeGiro = 200;
    float smoothTime = 0.05f;
    float currentVelocity;

    //variaveis de tiro
    public Transform gatilho;
    public GameObject projetilPreFab;
    public float velocidadeDoPorjetil = 20;
    public int danoCausado;
    public float frequenciaDeTiro = 0;
    [System.NonSerialized]  public float timer;
    
    //variaveis de vida
    public int vidaMaxima = 100;
    public int vidaAtual;
    public BarraDeVida barraDeVida;
    [System.NonSerialized] public int danoSofrido;
    public InimigoScript[] Inimigos;

    void Start()
    {
        CC = GetComponent<CharacterController>();

        Inimigos = new InimigoScript [4];
        for(int i = 0; i<Inimigos.Length; i++)
        {
            Inimigos[i] = GameObject.Find("Inimigo"+i).GetComponent<InimigoScript>();
        }
           
        vidaAtual = vidaMaxima;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMaxima);
    }

    void Update()
    {
        for (int i = 0; i < Inimigos.Length; i++)
        {
            Inimigos[i].danoSofrido = danoCausado;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
           Mirar();
        }
        else
        {
            Rotacionar();
            Movimentar();
        }
        if(timer > frequenciaDeTiro)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse1))
            {
                Atirar();
                timer = 0;
            }
        }
        timer += Time.deltaTime;
    }
    public void Movimentar()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direcao = new Vector3(horizontal, 0, vertical);
        CC.Move(direcao * velocidadeDoPlayer * Time.deltaTime);
    }
    public void Rotacionar()

    {
        if (direcao.magnitude >= smoothTime)
        {
            var targetAngle = Mathf.Atan2(direcao.x, direcao.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    void Mirar()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizontalInput * velocidadeDeGiro * Time.deltaTime);
    }
    void Atirar()
    {
        var bullet = Instantiate(projetilPreFab, gatilho.position, gatilho.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocidadeDoPorjetil, ForceMode.Impulse);
    }
    public void ApplyDamege(int dano)
    {
        dano = danoSofrido;
        vidaAtual -= dano;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMaxima);

        if (vidaAtual <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
