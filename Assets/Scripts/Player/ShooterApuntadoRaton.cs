using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterApuntadoRaton : MonoBehaviour
{
    public GameObject discoHeavy,discoElectric,discoClasic;
    public float cadencia;
    float tiempoAux = 0;
    Vector3 mousePosition, playerPosition;
    public float angulo;
    char musica='c';
    public void Disparo()
    {
        musica= GameManager.GetInstance().Musica();
        if (tiempoAux <= 0)
        {
            bool disparo = GameManager.GetInstance().NumeroDiscos();
            if (disparo)
            {
                if(musica=='h')
                Instantiate<GameObject>(discoHeavy, transform.position, Quaternion.Euler(new Vector3(0, 0, angulo)));
                else if(musica=='e') Instantiate<GameObject>(discoElectric, transform.position, Quaternion.Euler(new Vector3(0, 0, angulo)));
                else if (musica == 'c') Instantiate<GameObject>(discoClasic, transform.position, Quaternion.Euler(new Vector3(0, 0, angulo)));
                tiempoAux = cadencia;
            }

        }
    }
    void Update()
    {
       
        //Guardamos la posición del ratón
        mousePosition = Input.mousePosition;
        //Guardamos la posición del jugador respecto de la cámara
        playerPosition = Camera.main.WorldToScreenPoint(transform.position);
        //Hace la división del y entre el x y devuelve el ángulo en radianes entre ambos por eso multiplicamos por rad2Deg
        angulo = Mathf.Atan2((mousePosition.y - playerPosition.y), (mousePosition.x - playerPosition.x)) * Mathf.Rad2Deg - 90;        
        // Es un contador, deja disparar al jugador cada tiempoAux segundos
        tiempoAux = tiempoAux - Time.deltaTime;
        
    }
}
