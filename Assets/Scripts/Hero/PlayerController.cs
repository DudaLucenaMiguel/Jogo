using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController CC;

    //variaveis de rotação;
    float smoothTime = 0.05f;
    float currentVelocity;

    //variaves para atenção no inimigo
    //public float turnSpeed = 10;
    //public Transform enemy;
    //public float raioDeAtencao;


    //variaveis de movimento
    public float velocidadeDoPlayer = 10;
    Vector3 direcao;
    float horizontal;
    float vertical;

    //variaveis de tiro
    public Transform gatilho;
    public GameObject projetilPreFab;
    public float velocidadeDoPorjetil = 10;
    public float frequenciaDeTiro = 1;
    float timer;
    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        Rotacionar();
        Movimentar();

        //float distanciaPlayerEnemy = Vector3.Distance(transform.position, enemy.position);
       
        if(timer > frequenciaDeTiro && Input.GetKeyDown(KeyCode.Space))
        {
            Atirar();
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }
    public void Movimentar()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        direcao = new Vector3(horizontal * velocidadeDoPlayer * Time.deltaTime, 0, vertical * velocidadeDoPlayer * Time.deltaTime);

        CC.Move(direcao);
    }
    public void Rotacionar()
    {
        if (direcao.magnitude >= smoothTime)
        {
            var targetAngle = Mathf.Atan2(direcao.x, direcao.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime*Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    void OlharParaOInimigo()
    {
        //Vector3 direction = (enemy.position - transform.position).normalized;
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }
    void Atirar()
    {
            var bullet = Instantiate(projetilPreFab, gatilho.position, gatilho.rotation);
            bullet.GetComponent<Rigidbody>().velocity = gatilho.forward * velocidadeDoPorjetil;
    }
}

