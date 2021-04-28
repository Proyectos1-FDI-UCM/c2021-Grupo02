using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damageable : MonoBehaviour
{
    bool classic = false;
    bool heavy = true;
    bool electric = true;
    Rigidbody2D RB;
    Animator anim;
  
    //Música electrónica: la vida aumenta, es decir se cura 1 pila cada 8 segundos.
    //Música clásica: la vida del jugador disminuye de forma normal 1 pila cada 6 segundos.
    //Música heavy metal: la vida decrementará a una velocidad más rápida(1 pila cada 4 segundos).

    void Start()
    {
       InvokeRepeating( "Classic",0,0.6f);
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }
    void Update()
    {
        if (GameManager.GetInstance().JugMuerto())
        {
            anim.SetInteger("Direction", 20);
            Destroy(this.gameObject, 2f);

        }


        if (GameManager.GetInstance().Musica() == 'c')
        {
            if (classic == true)
            {
                classic = false;
                heavy = true;
                electric = true;
                CancelInvoke();
                InvokeRepeating("Classic",0,0.6f);
            }
           
        }
        else if (GameManager.GetInstance().Musica() == 'h')
        {
            if (heavy== true)
            {
               heavy = false;
                classic = true;
                electric = true;
                CancelInvoke();
                InvokeRepeating("Heavy",0, 0.4f);
            }
           
        }
        else if (GameManager.GetInstance().Musica() == 'e')
        {
            if (electric == true)
            {
               electric = false;
                classic = true;
                heavy = true;
                CancelInvoke();
                InvokeRepeating("Electric",0,0.6f);
            }
          
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
  

    public void Heavy()
     {
       
            
            GameManager.GetInstance().ReducirVidasConstante();
          
  
     }
    public void Electric()
    {
        
            GameManager.GetInstance().vidasElectric();
           

        
    }
    public void Classic()
    {

            GameManager.GetInstance().ReducirVidasConstante();
        
     
      
       
    }
    public void Cancelar()
    {
        CancelInvoke();
    }
}
   

