using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Scripts asociado al robot
public class RobotPoliciaMovimiento : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    int velocidad;
    RobotPoliciaDisparo rpd;
    Rigidbody2D rb;
    float tiempoAux, angle, tiempoChoque;
    int sentido = 1;
    bool jugador, clasica = false, electrica = true, heavy = true;
    Vector2 direction, anguloEmbestida;
    public Animator anim;
    GameManager.Music mus,musicaVieja;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (mus == GameManager.Music.heavy && collision.transform.GetComponent<ControlesPlayer>() && tiempoChoque <= 0)
        {
            GameManager.GetInstance().reducirVidas();
            tiempoChoque = 1.2f;
        }
        else if (collision.transform.GetComponent<MusicEffect>() || collision.transform.GetComponent<Guardia>()) Debug.Log("Aparta");
        else Invoke("CambiarSentidoChoque", 0);
    }
 
    void OnCollisionExit2D(Collision2D other)
    {
        rb.isKinematic = false;

    }
    //Accedemos al rigidbody para variar la velocidad, añadimos un enemy en el GameManager, y al script de disparo
    private void Start()
    {
        //Comportamiento con el que inicia
        Invoke("Clasica", 0);
        clasica = false;
        tiempoAux = 0;
        mus = GameManager.GetInstance().Musica();
        musicaVieja = mus;
        //anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rpd = GetComponentInChildren<RobotPoliciaDisparo>();
        
    }
    private void Update()
    {
        if (!GameManager.GetInstance().EstadoJugador())
        {
            //Actualiza el contador
            tiempoAux = tiempoAux - Time.deltaTime;
            tiempoChoque = tiempoChoque - Time.deltaTime;
            
            mus = GameManager.GetInstance().Musica();
            //Calcula la distancia entre el player y el enemigo;
            direction = player.position - transform.position;
            //Calcula el ángulo que tiene que girar a partir de la distancia a la que se encuentra del jugador
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //Obtenemos el estado del jugador, vivo/muerto
            jugador = GameManager.GetInstance().EstadoJugador();

            if (GameManager.GetInstance().EstadoSala() && !jugador)
            {
                if (mus != musicaVieja)
                {
                    CancelInvoke();
                    Invoke("CambiarSentido", 0);
                }
                else if (mus == GameManager.Music.classic&& clasica && tiempoAux <= 0)
                {
                    CancelInvoke();
                    clasica = false;
                    electrica = true;
                    heavy = true;
                    Invoke("Clasica", 1);
                }
                else if (mus == GameManager.Music.heavy && heavy && tiempoAux <= 0)
                {
                    CancelInvoke();
                    clasica = true;
                    electrica = true;
                    heavy = false;
                    Invoke("Heavy", 1);
                }
                else if (mus == GameManager.Music.electronic && electrica && tiempoAux <= 0)
                {
                    CancelInvoke();
                    clasica = true;
                    electrica = false;
                    heavy = true;
                    Invoke("Electronica", 1);
                }
            }
        }
        else CancelInvoke();
    }
    void CambiarSentidoChoque()
    {
        tiempoAux = 1.2f;
    }
    void CambiarSentido()
    {
        musicaVieja = mus;    
        sentido = -1;
        tiempoAux = 1.2f;
        if (rb.velocity.x > 0)
        {
            anim.SetBool("Disparo", false);
            anim.SetBool("Embestir", false);
            anim.SetBool("Retroceder", true);
            anim.SetBool("Morir", false);
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < 0)
        {          
            anim.SetBool("Disparo", false);
            anim.SetBool("Embestir", false);
            anim.SetBool("Retroceder", true);
            anim.SetBool("Morir", false);
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        Invoke("CambiarSentido", 0.001f);
        Invoke("CambioSentido", 1);  
    }
    void Clasica()
    {
        if(rb.velocity.x > 0)
        {
            anim.SetBool("Disparo", true);
            anim.SetBool("Embestir", false);
            anim.SetBool("Retroceder", false);
            anim.SetBool("Morir", false);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(rb.velocity.x < 0) {
            anim.SetBool("Disparo", true);
            anim.SetBool("Embestir", false);
            anim.SetBool("Retroceder", false);
            anim.SetBool("Morir", false);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (sentido == 1 && tiempoAux <= 0 && direction.magnitude < 9 && direction.magnitude > 4)
        {
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
        }
        else if (direction.magnitude < 4 && direction.magnitude > 2)
        {
            rpd.MusicaClasica(angle);
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
        }
        //Si el sentido es negativo, tendrá velocidad negativa y el ángulo opuesto
        else if (sentido == -1)
        {
            rb.velocity = -new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
        }     
        Invoke("Clasica", 0.001f);
    }
    void Heavy()
    {
        if(rb.velocity != Vector2.zero && direction.magnitude < 10) { 
            if (rb.velocity.x > 0)
            {
                anim.SetBool("Disparo", false);
                anim.SetBool("Embestir", true);
                anim.SetBool("Retroceder", false);
                anim.SetBool("Morir", false);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (rb.velocity.x < 0)
            {
                anim.SetBool("Disparo", false);
                anim.SetBool("Embestir", true);
                anim.SetBool("Retroceder", false);
                anim.SetBool("Morir", false);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if(tiempoChoque >=0)
        {
            if (player.transform.position.x - transform.position.x >= 0)
            {
                anim.SetBool("Disparo", false);
                anim.SetBool("Embestir", false);
                anim.SetBool("Retroceder", true);
                anim.SetBool("Morir", false);
                rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * -velocidad * sentido * Time.deltaTime;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (player.transform.position.x - transform.position.x < 0)
            {
                anim.SetBool("Disparo", false);
                anim.SetBool("Embestir", false);
                anim.SetBool("Retroceder", true);
                anim.SetBool("Morir", false);
                rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * -velocidad * sentido * Time.deltaTime;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (player.transform.position.x - transform.position.x >= 0)
            {
                anim.SetBool("Disparo", false);
                anim.SetBool("Embestir", true);
                anim.SetBool("Retroceder", false);
                anim.SetBool("Morir", false);  
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (player.transform.position.x - transform.position.x < 0)
            {
                anim.SetBool("Disparo", false);
                anim.SetBool("Embestir", true);
                anim.SetBool("Retroceder", false);
                anim.SetBool("Morir", false);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (rb.velocity  == Vector2.zero && tiempoAux <=0) {
            anguloEmbestida = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        }
        if (tiempoChoque <= 0) rb.velocity = anguloEmbestida * 8 * velocidad * sentido * Time.deltaTime;
        else rb.velocity = Vector2.zero;
        Invoke("Heavy", 0.001f);

       
    }
    void Electronica()
    {
        if (rb.velocity.x > 0)
        {
            anim.SetBool("Disparo", true);
            anim.SetBool("Embestir", false);
            anim.SetBool("Retroceder", false);
            anim.SetBool("Morir", false);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < 0)
        {
            anim.SetBool("Disparo", true);
            anim.SetBool("Embestir", false);
            anim.SetBool("Retroceder", false);
            anim.SetBool("Morir", false);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (sentido == 1 && tiempoAux <= 0 && direction.magnitude < 8 && direction.magnitude > 4)
        {
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
        }
        else if (direction.magnitude < 4 && direction.magnitude > 2)
        {
            rpd.MusicaElectronica(angle);
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido * Time.deltaTime;
        }
        //Si el sentido es negativo, tendrá velocidad negativa y el ángulo opuesto
        else if (sentido == -1)
        {
            rb.velocity = -transform.right * velocidad * sentido * Time.deltaTime;
        }
        else rb.velocity = Vector2.zero;
        Invoke("Electronica", 0.001f);
    }
    public void Parar()
    {
        rb.velocity = Vector2.zero;
        CancelInvoke();
    }
    void CambioSentido()
    {
        CancelInvoke();
        sentido = -sentido;
    }
    private void OnDisable()
    {
        CancelInvoke();
        rb.velocity = Vector2.zero;
    }
}
