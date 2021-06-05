using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    //Metodo que se utiliza para que detecte el collider cuando se coja el disco de oro y se destruya este
    void OnTriggerEnter2D(Collider2D colision)
    {
        Debug.Log("Has obtenido el disco de oro!");
        Debug.Log("Has ganado!");

        Destroy(this.gameObject);
    }

  
}
