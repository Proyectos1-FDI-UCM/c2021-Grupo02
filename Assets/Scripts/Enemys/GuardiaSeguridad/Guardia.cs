using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script asociado a los enemigos
public class Guardia : MonoBehaviour
{
    public float velocidad = 5;      //Velocidad del enemigo
    public Transform player;       //Acceso al transform del player
    Rigidbody2D rb;                //Variable tipo rigidbody2d
    int sentido = 1;               //Sentido del movimiento
    char musica;                   //Almacenara la musica que suene en ese momento
    char musicaVieja = ' ';        //Almacenara la musica antigua. Empezará siendo ninguna
    bool metodo = false;
    public Animator animator;
    Vector2 direction;
    void Start()
    {
        //Se accede al metodo  AddEnemy del gm para que se cuente al numero de enemigos
        rb = GetComponent<Rigidbody2D>();                     //Acceso al rigidBody2D
    }
    private void Update()
    {
        musica = GameManager.GetInstance().Musica();

        if (GameManager.GetInstance().EstadoSala() && !metodo)
        {
            metodo = true;
            Persecucion();
        }
        //En musica se guarda la musica que suene en ese momento

        if (musica != musicaVieja)                            //Si la musica ha cambiado, es decir si la de ahora es diferente a la de antes
        {
            musicaVieja = musica;                             //La musica actual pas a ser la amtigua, para que al cambiar se note la diferencia
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
            if (direction.magnitude > 4 && direction.magnitude < 9 && musica != 'h')// a distancia
            {
                animator.SetBool("Correr", true);//llamas al parametro;
                animator.SetBool("Porra", false);//llamas al parametro;
                animator.SetBool("Muerte", false);//llamas al parametro;
                animator.SetBool("Disparar", false);//llamas al parametro;
                //Posicion del enemigo = Vector2.MoveTowards (PERSEGUIDOR, TARGET, VELOCIDAD)   Si la velocidad es negativa hara el movimiento contrario, por eso lo del sentido
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidad * sentido * Time.deltaTime); //MoveTowards (hace el seguimiento)

                if (direction.x < 0)
                {
                    if (musica == 'c')//es clasica dispara cada 1 s
                    {
                        //Invoke("Disparos", 1f);
                    }
                    else if (musica == 'e')
                    {
                        //Invoke("Disparos", 0.5f);
                    }

                    //llamas al parametro;

                    transform.localScale = new Vector3(-1, 1, 1);//si se mueve hacia eje X negativo izquierda
                }
                else if (direction.x > 0)
                {
                    if (musica == 'c')//es clasica dispara cada 1 s
                    {
                        //Invoke("Disparos", 1f);
                    }
                    else if (musica == 'e')
                    {
                        //Invoke("Disparos", 0.5f);
                    }
                    //llamas al parametro;

                    transform.localScale = new Vector3(1, 1, 1);//si se mueve hacia eje X positivo derecha
                }

                ////MUSICA CLASICA
                //animator.SetBool("Correr", true);//llamas al parametro;
                //animator.SetBool("Porra", false);//llamas al parametro;
                //animator.SetBool("Muerte", false);//llamas al parametro;
                //animator.SetBool("Disparar", false);//llamas al parametro;
            }
           
            else if (musica == 'h')//cuerpo a cuerpo
            {

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidad * sentido * Time.deltaTime);

                if (direction.magnitude < 4)
                { //hacer lo de la porra pegar cuerpo a cuerpo}
                    if (direction.x < 0)
                    {
                        animator.SetBool("Correr", false);//llamas al parametro;
                        animator.SetBool("Porra", true);//llamas al parametro;
                        animator.SetBool("Muerte", false);//llamas al parametro;
                        animator.SetBool("Disparar", false);//llamas al parametro;

                        transform.localScale = new Vector3(-1, 1, 1);//si se mueve hacia eje X negativo izquierda
                    }
                    else if (direction.x > 0)
                    {
                        animator.SetBool("Correr", false);//llamas al parametro;
                        animator.SetBool("Porra", true);//llamas al parametro;
                        animator.SetBool("Muerte", false);//llamas al parametro;
                        animator.SetBool("Disparar", false);//llamas al parametro;

                        transform.localScale = new Vector3(1, 1, 1);//si se mueve hacia eje X positivo derecha
                    }

                }                                                          //rb.velocity = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y) * -velocidad;
                //Invoco persecuccion cada poco para que vaya mas fluido el movimiento
            }

            Invoke("Persecucion", 0.1f);
        }
    }
    void Disparos()
    {
        animator.SetBool("Correr", false);//llamas al parametro;
        animator.SetBool("Porra", false);//llamas al parametro;
        animator.SetBool("Muerte", false);//llamas al parametro;
        animator.SetBool("Disparar", true);
    }

    void CambioSentido()
    {
        sentido = -sentido; //Sentido contrario
    }
}
