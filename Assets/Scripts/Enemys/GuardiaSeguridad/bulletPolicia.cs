using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Daniel 


// Script asociado a la bala
public class bulletPolicia : MonoBehaviour
{
    [SerializeField]
    float velocityScale, tiempoExplot;   //velocidad de la bala
    private Rigidbody2D rb;       //referencia al RigidBody2D
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //Acceso al componente RigidBody2D
        Invoke("ExplosionBala", tiempoExplot);
    }

    void ExplosionBala()
    {
        Destroy(this.gameObject);
    }
    //metodo que define el movimiento de la bala
    void FixedUpdate()
    {
        rb.velocity = transform.up * velocityScale;   //Movimiento físico de la bala
                                                 //transform.up es para que tome la direccion/rotacion del enemigo
    }

}
