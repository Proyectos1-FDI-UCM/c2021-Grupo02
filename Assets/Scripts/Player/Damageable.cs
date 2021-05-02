using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damageable : MonoBehaviour
{
    Animator anim;

    //Música electrónica: la vida aumenta, es decir se cura 1 pila cada 8 segundos.
    //Música clásica: la vida del jugador disminuye de forma normal 1 pila cada 6 segundos.
    //Música heavy metal: la vida decrementará a una velocidad más rápida(1 pila cada 4 segundos).

    void Start()
    {
        anim = GetComponent<Animator>();
        

    }
    void Update()
    {
        if (GameManager.GetInstance().JugMuerto())
        {
            anim.SetInteger("Direction", 20);
            Destroy(this.gameObject, 2f);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<VelocidadDisco>()&&!collision.GetComponent<Habita>())
        {
            if (!GameManager.GetInstance().JugMuerto())
            {
                if (collision.GetComponent<VelocidadRayoDaño>()) GameManager.GetInstance().reducir2Vidas();
                else if (collision.GetComponent<VelocidadRayoStoon>())
                {
                    GameManager.GetInstance().CambiarEstadoParalisis();
                    GameManager.GetInstance().reducirVidas();
                }
                else if(collision.GetComponent<bulletPolicia>() || collision.GetComponent<porra>())GameManager.GetInstance().reducirVidas(); 
            }
        }
      
    }
}
   

