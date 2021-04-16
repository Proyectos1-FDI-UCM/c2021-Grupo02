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
    float tiempoAux;
    int sentido = 1;
    char musica = 'c', musicaVieja = 'c';

    //Accedemos al rigidbody para variar la velocidad, añadimos un enemy en el GameManager, y al script de disparo
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rpd = GetComponentInChildren<RobotPoliciaDisparo>();
    }
    private void Update()
    {
        //Actualiza el contador
        tiempoAux = tiempoAux - Time.deltaTime;
        bool metodo = false;
        if (GameManager.GetInstance().EstadoSala() && !metodo)
        {
            Perseguir();
            metodo = true;
        }
    }
    public void Perseguir()
    {
        //Obtenemos el estado del jugador, vivo/muerto
        bool jugador = GameManager.GetInstance().EstadoJugador();
        //Si jugador vivo
        if (!jugador)
        {
            //Da una char que dirá que música está sonando
            musica = GameManager.GetInstance().Musica();
            //Calcula la distancia entre el player y el enemigo;
            Vector2 direction = player.position - transform.position;
            //Calcula el ángulo que tiene que girar a partir de la distancia a la que se encuentra del jugador
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //Si la música ha cambiado cambia el sentido durante un segundo      
            if (musica != musicaVieja)
            {
                musicaVieja = musica;
                sentido = -1;
                tiempoAux = 1.2f;
                Invoke("CambioSentido", 1);
            }
            //Si el sentido es positivo y ha pasado ese retardo para que no dispare a su espalda podrá disparar la bala correspondiente
            else if (sentido == 1 && tiempoAux <= 0 && direction.magnitude < 4)
            {
                if (musica == 'c') rpd.MusicaClasica();
                else if (musica == 'e') rpd.MusicaElectronica();
            }

            //Si el sentido es negativo, tendrá velocidad negativa y el ángulo opuesto
            if (sentido == -1)
            {
                rb.velocity = -transform.right * velocidad * sentido;
                rb.rotation = angle + 180;
            }
            //Si el sentido es dirección al jugador, se moverá hacia él y mirará hacia él
            else if (direction.magnitude > 2)
            {
                rb.velocity = transform.right * velocidad * sentido;
                rb.rotation = angle;
            }
            //Si está a dos unidades de distancia o menos su velocidad es 0
            else rb.velocity = Vector2.zero;
        }
        //Si el jugador muere que se quede quieto el robot
        else rb.velocity = Vector2.zero;
        Invoke("Perseguir", 0.1f);
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
