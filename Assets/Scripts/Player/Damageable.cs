using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Daniel , Miriam
public class Damageable : MonoBehaviour
{
    [SerializeField]
    GameObject paralizado;
    
    Animator anim;
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
    //Metodo para que al jugador se le reduzca vida
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<VelocidadDisco>()&&!collision.GetComponent<Habita>())
        {
            if (!GameManager.GetInstance().JugMuerto())
            {
                //reducción de pilas cuando una bala de un enemigo colisona con el jugador
                if (collision.GetComponent<VelocidadRayoDaño>()) GameManager.GetInstance().reducir2Vidas();
                else if (collision.GetComponent<VelocidadRayoStoon>())
                {
                    Instantiate(paralizado, transform.position, transform.rotation, transform);
                    GameManager.GetInstance().CambiarEstadoParalisis();
                    GameManager.GetInstance().reducirVidas();
                }
                else if(collision.GetComponent<bulletPolicia>() || collision.GetComponent<porra>())GameManager.GetInstance().reducirVidas(); 
            }
        }
      
    }
}
   

