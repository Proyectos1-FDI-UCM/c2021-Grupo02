using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Scripts asociado al robot
public class RobotPoliciaMovimiento : MonoBehaviour
{
    public Transform player;
    public int velocidad;
    RobotPoliciaDisparo rpd;
    Rigidbody2D rb;
    float tiempoAux, angle;
    int sentido = 1;
    char musica = 'c', musicaVieja = 'c';
    bool jugador, clasica = true, electrica = false, heavy = false;
    Vector2 direction;
    Animator anim;

    //Accedemos al rigidbody para variar la velocidad, añadimos un enemy en el GameManager, y al script de disparo
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rpd = GetComponentInChildren<RobotPoliciaDisparo>();
        
    }
    private void Update()
    {
        //Actualiza el contador
        tiempoAux = tiempoAux - Time.deltaTime;
        //Da una char que dirá que música está sonando
        musica = GameManager.GetInstance().Musica();
        //Calcula la distancia entre el player y el enemigo;
        direction = player.position - transform.position;
        //Calcula el ángulo que tiene que girar a partir de la distancia a la que se encuentra del jugador
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Obtenemos el estado del jugador, vivo/muerto
        jugador = GameManager.GetInstance().EstadoJugador();

        if (GameManager.GetInstance().EstadoSala() && !jugador)
        {
            if (musica != musicaVieja)
            {
                musicaVieja = musica;
                sentido = -1;
                tiempoAux = 1.2f;
                Invoke("CambioSentido", 1);
            }
            else if (musica == 'c' && clasica){
                clasica = false;
                electrica = true;
                heavy = true;
                Invoke("Clasica", 1.2f); 
            }
            else if(musica == 'h' && heavy){
                clasica = true;
                electrica = true;
                heavy = false;
                Invoke("Heavy", 1.2f);
            }
            else if (musica == 'e' && electrica){
                clasica = true;
                electrica = false;
                heavy = true;
                Invoke("Electronica", 1.2f);
            }
        }
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

        if (sentido == 1 && tiempoAux <= 0 && direction.magnitude < 4 && direction.magnitude > 2)
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

        if (sentido == 1 && tiempoAux <= 0 && direction.magnitude < 4 && direction.magnitude > 2)
        {
            rpd.MusicaElectronica(angle);
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * velocidad * sentido;
        }
        //Si el sentido es negativo, tendrá velocidad negativa y el ángulo opuesto
        else if (sentido == -1)
        {
            rb.velocity = -transform.right * velocidad * sentido;
        }
        else rb.velocity = Vector2.zero;
    }
    public void Parar()
    {
        rb.velocity = Vector2.zero;
        CancelInvoke();
    }
    void CambioSentido()
    {      
        sentido = -sentido;   
    }
    
}
