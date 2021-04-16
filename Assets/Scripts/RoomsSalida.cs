using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsSalida : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ControlesPlayer>())    //Solo se produce si el objeto que entra en el trigger es el jugador
        {
            GameManager.GetInstance().SalirSala();
        }
    }
}
