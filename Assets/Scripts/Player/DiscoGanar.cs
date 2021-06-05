using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Miriam , Pablo
public class DiscoGanar : MonoBehaviour
{
    // Si el jugador toca el disco el juego acaba
    void OnTriggerEnter2D(Collider2D colision)
    {
        Destroy(this.gameObject);
        GameManager.GetInstance().Perder(false);

    }

}
