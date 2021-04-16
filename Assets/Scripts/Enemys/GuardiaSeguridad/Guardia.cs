using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script asociado a los enemigos
public class Guardia: MonoBehaviour
{ 
    public float velocidad = 1;      //Velocidad del enemigo
    public Transform player;       //Acceso al transform del player
    Rigidbody2D rb;                //Variable tipo rigidbody2d
    int sentido = 1;               //Sentido del movimiento
    char musica;                   //Almacenara la musica que suene en ese momento
    char musicaVieja = ' ';        //Almacenara la musica antigua. Empezará siendo ninguna
    bool metodo = false;
    void Start()
    {
                       //Se accede al metodo  AddEnemy del gm para que se cuente al numero de enemigos
        rb = GetComponent<Rigidbody2D>();                     //Acceso al rigidBody2D
    }
    private void Update()
    {
        musica = GameManager.GetInstance().Musica();
      
        if(GameManager.GetInstance().EstadoSala() && !metodo)
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
            Vector2 direction = player.position - transform.position;
            if (direction.magnitude > 4 && musica != 'h')
            {
                //Posicion del enemigo = Vector2.MoveTowards (PERSEGUIDOR, TARGET, VELOCIDAD)   Si la velocidad es negativa hara el movimiento contrario, por eso lo del sentido
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidad * sentido * Time.deltaTime); //MoveTowards (hace el seguimiento)
            }
            else if (musica == 'h')
            { 
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidad * sentido * Time.deltaTime);
            }
            if (sentido == 1) transform.up = player.position - transform.position;
            else transform.up = -player.position - transform.position;//rotacion
                                                                     //rb.velocity = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y) * -velocidad;
            Invoke("Persecucion", 0.05f); //Invoco persecuccion cada poco para que vaya mas fluido el movimiento
              
        }
    }
    void CambioSentido()
    {
        sentido = -sentido; //Sentido contrario
    }
}
