using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script asociado a la puerta de los boundaries
public class Rooms : MonoBehaviour
{
    RobotPoliciaMovimiento robot;
    Guardia guardia;
    BoxCollider2D puerta;
    MusicEffect turista;
    private void Start()
    {
        puerta = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ControlesPlayer>())    //Solo se produce si el objeto que entra en el trigger es el jugador
        {
            GameManager.GetInstance().EntrarSala();
            puerta.enabled = false;
        }
    }
}
