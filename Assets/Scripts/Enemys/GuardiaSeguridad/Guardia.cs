﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script asociado a los enemigos
public class Guardia : MonoBehaviour
{
    [SerializeField]
    float velocidad = 5;      //Velocidad del enemigo
    [SerializeField]
    Transform player;       //Acceso al transform del player
    Rigidbody2D rb;                //Variable tipo rigidbody2d
    int sentido = 1;               //Sentido del movimiento
    float porrazo;
                   //Almacenara la musica que suene en ese momento       //Almacenara la musica antigua. Empezará siendo ninguna
    bool metodo = false, giro = false;
    public Animator animator;
    Vector2 direction;
    GameManager.Music mus,musicaVieja;

    
    void Start()
    {
        //Se accede al metodo  AddEnemy del gm para que se cuente al numero de enemigos
        rb = GetComponent<Rigidbody2D>();                     //Acceso al rigidBody2D
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        rb.isKinematic = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        rb.isKinematic = false;
    }
    private void Update()
    {
        porrazo = porrazo - Time.deltaTime;
        mus = GameManager.GetInstance().Musica();
        if (GameManager.GetInstance().EstadoSala() && !metodo)
        {
            metodo = true;
            Persecucion();
        }
        //En musica se guarda la musica que suene en ese momento
        if (mus != musicaVieja)                            //Si la musica ha cambiado, es decir si la de ahora es diferente a la de antes
        {
            musicaVieja = mus;                             //La musica actual pas a ser la amtigua, para que al cambiar se note la diferencia
            CambioSentido();                                  //El enemigo irá en setido contrario
            Invoke("CambioSentido", 1f);                      //Tras un segundo el enemigo volverá a ir en la dirección normal. Si cambias el sentido 2 veces t qdas igual
        }
    }
    public void Persecucion()     //Metodo que se encarga de la persecucion
    {
        if (player != null)       //Solo si el transform del jugador no esta destruido
        {

            // Calculo la distancia para cuando este a dos o menos unidades de distancia no siga corriendo
            direction = player.position - transform.position;
            if (direction.magnitude > 4 && direction.magnitude < 9 && mus != GameManager.Music.heavy)// a distancia
            {
                animator.SetBool("Correr", true);//llamas al parametro;
                animator.SetBool("Porra", false);//llamas al parametro;
                animator.SetBool("Muerte", false);//llamas al parametro;
                animator.SetBool("Disparar", false);//llamas al parametro;
                
                rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
                if (sentido == -1 && giro)
                {
                    giro = false;
                    transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
                }
                else if (direction.x < 0 && sentido == 1)
                {
                    giro = true;
                    transform.localScale = new Vector3(-1, 1, 1);//si se mueve hacia eje X negativo izquierda
                }
                else if (direction.x > 0 && sentido == 1)
                {
                    giro = true;
                    //llamas al parametro;
                    transform.localScale = new Vector3(1, 1, 1);//si se mueve hacia eje X positivo derecha
                }
            }
            else if (mus == GameManager.Music.heavy)//cuerpo a cuerpo
            {
                rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
                if (sentido == -1 && giro)
                {
                    giro = false;
                    transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
                }
                else if (direction.magnitude < 1.5f && porrazo <= 0 && sentido == 1)
                { //hacer lo de la porra pegar cuerpo a cuerpo}
                    giro = true;
                    if (direction.x < 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);//si se mueve hacia eje X negativo izquierda
                    }
                    else if (direction.x > 0 && porrazo <= 0)
                    { 
                        transform.localScale = new Vector3(1, 1, 1);//si se mueve hacia eje X positivo derecha
                    }
                    animator.SetBool("Correr", false);//llamas al parametro;
                    animator.SetBool("Porra", true);//llamas al parametro;
                    animator.SetBool("Muerte", false);//llamas al parametro;
                    animator.SetBool("Disparar", false);//llamas al parametro;
                    Invoke("Porrazo", 1f);
                }  
                else if(sentido == 1){
                    if (direction.x < 0)
                    {                  
                        transform.localScale = new Vector3(-1, 1, 1);//si se mueve hacia eje X negativo izquierda
                    }
                    else if (direction.x > 0 && porrazo <= 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);//si se mueve hacia eje X positivo derecha
                    }
                    giro = true;
                    animator.SetBool("Correr", true);//llamas al parametro;
                    animator.SetBool("Porra", false);//llamas al parametro;
                    animator.SetBool("Muerte", false);//llamas al parametro;
                    animator.SetBool("Disparar", false);
                }
                //Invoco persecuccion cada poco para que vaya mas fluido el movimiento
            }
            Invoke("Persecucion", 0.1f);
        }
    }
    private void Porrazo()
    {
        porrazo = 1;
    }
    void CambioSentido()
    {
        sentido = -sentido; //Sentido contrario
    }
    private void OnDisable()
    {
        CancelInvoke();
        rb.velocity = Vector2.zero;
    }
}
