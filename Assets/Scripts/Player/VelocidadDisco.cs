using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadDisco : MonoBehaviour
{
    //Variables públicas para decidir desde el editor la velocidad del disco y lo que tarda en explotar
    [SerializeField]
    float velocidadDisco, tiempoExplot;
    Rigidbody2D rb;
    //Accedemos al rigidbody para darle velocidad al disco e invocamos un método que destrozará el disco después de tiempoExplot segundos
    private void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * velocidadDisco;      
        Invoke("ExplosionBala", tiempoExplot);
    }
    void ExplosionBala()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(!collision.GetComponent<Damageable>()&&!collision.GetComponent<Habita>())
        Destroy(this.gameObject);
    }
}
