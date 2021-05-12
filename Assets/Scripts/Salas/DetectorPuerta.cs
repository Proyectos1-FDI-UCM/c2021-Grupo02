using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorPuerta : MonoBehaviour
{
    public GameObject puerta;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ControlesPlayer>())
        {
            puerta.SetActive(true);
        }
    }

  
   
}
