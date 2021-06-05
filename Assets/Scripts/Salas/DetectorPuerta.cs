using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Miriam
public class DetectorPuerta : MonoBehaviour
{
    public GameObject puerta;

    //Metodo que activa trigger al poseer el GO el ControlesPlayer.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ControlesPlayer>())
        {
            puerta.SetActive(true);
        }
    }

  
   
}
