using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Este script va asociado a la bala
public class Destructible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D objeto)
    {
        Destroy(this.gameObject);                                    //La bala se destruira al chocar con algo
                   
    }

}
