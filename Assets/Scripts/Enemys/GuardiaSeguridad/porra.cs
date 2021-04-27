using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porra : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    //Activa y desactiva collider en las animaciones para que cuando ataque con la porra se active si lo detecta le hace daño al player
    void CambioCollider()
    {
        boxCollider2D.enabled = !boxCollider2D.enabled;
    }
}
