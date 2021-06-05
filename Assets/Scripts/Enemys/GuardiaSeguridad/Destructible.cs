using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Sara

// Este script va asociado a la bala
public class Destructible : MonoBehaviour
{

    //metodo que detecta un GO  el trigger si posee script ControlesPlayer
    void OnTriggerEnter2D(Collider2D objeto)
    {
        if(objeto.gameObject.GetComponent<ControlesPlayer>())  Destroy(this.gameObject);                                    //La bala se destruira al chocar con algo
                   
    }

}
