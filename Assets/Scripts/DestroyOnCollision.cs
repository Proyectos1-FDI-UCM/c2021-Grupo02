using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D colision)
    {
        Debug.Log("Has obtenido el disco de oro!");
        Debug.Log("Has ganado!");

        Destroy(this.gameObject);
    }

  
}
