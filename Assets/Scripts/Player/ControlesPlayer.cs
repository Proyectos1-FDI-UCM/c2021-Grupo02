using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPlayer : MonoBehaviour
{
    //Declaración de variables
    [SerializeField]
    float velocityScale;//velocidad de movimiento
    float forceX, forceY;
    Rigidbody2D rb;
    Vector2 fuerzas;
    Animator anim;
    ShooterApuntadoRaton shooter;
    float angulbala;

    //Accedemos al componente shooter para disparar una bala al pulsar la tecla espacio
    void Start()
    {
        shooter = GetComponentInChildren<ShooterApuntadoRaton>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
      
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        rb.isKinematic = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        rb.isKinematic = false;

    }
    void Update()
    {
       
        
        bool paralisis = GameManager.GetInstance().EstadoParalisis();
        if (!paralisis && !GameManager.GetInstance().EstadoJugador())
        {
            CancelInvoke();
            //Fuerza asociada al eje x
            forceX = Input.GetAxis("Horizontal");
            //Fuerza asociada al eje y
            forceY = Input.GetAxis("Vertical");
            // Vector para unificar fuerzas de ejes
            fuerzas = new Vector2(forceX, forceY);
            //es para que en los movimientos diagonales no tenga el doble de fuerza por ejeX y ejeY
            fuerzas.Normalize();
            Quaternion invertir = new Quaternion(0, 180, 0,0);
            if (Input.GetMouseButton(0))
            {
               
                shooter.Disparo();
                angulbala = GetComponentInChildren<ShooterApuntadoRaton>().angulo;
                //anim.SetBool("dispfront", true);

                // if(angulbala<22.5&&angulbala>=287.5) anim.SetInteger("Direction", 11);
                if (angulbala>=-202.5&&angulbala<-157.5) anim.SetBool("dispfront",true);
                else if (angulbala >= -112.5 && angulbala < -67.5) anim.SetBool("dispder", true);
                else if(angulbala >= -157.5&& angulbala < -112.5) anim.SetBool("diagoder", true);
                else if(angulbala >= -67.5 && angulbala < -22.5) anim.SetBool("disdigatrasder", true);
                else if (angulbala >= -22.5 && angulbala < 22.5) anim.SetBool("atras",true);
                else if (angulbala > 22.5 && angulbala < 67.5) anim.SetBool("dig", true);                        
                else if (angulbala >= -247.5 && angulbala < -202.5) anim.SetBool("sdigfront", true);
                else  anim.SetBool("sperfizqu", true);


                // anim.SetInteger("Direction", 11);
            }
           
            else
            {
                if (angulbala > 22.5 && angulbala < 67.5) anim.SetBool("dig", false);
                else if ((angulbala >= -112.5 && angulbala < -67.5)) anim.SetBool("dispder", false);
                else if (angulbala >= -202.5 && angulbala < -157.5) anim.SetBool("dispfront",false);
                else if (angulbala >= -157.5 && angulbala < -112.5) anim.SetBool("diagoder", false);
                else if ((angulbala >= -67.5 && angulbala < -22.5)) anim.SetBool("disdigatrasder",false);
                else if (angulbala >= -22.5 && angulbala < 22.5) anim.SetBool("atras", false);
                else if (angulbala >= -247.5 && angulbala < -202.5) anim.SetBool("sdigfront", false);
                else  anim.SetBool("sperfizqu", false);

            }

                if (forceX > 0 && forceY == 0) anim.SetInteger("Direction", 3);
                else if (forceX < 0 && forceY == 0) anim.SetInteger("Direction", 7);
                else if (forceX == 0 && forceY > 0) anim.SetInteger("Direction", 5);
                else if (forceX == 0 && forceY < 0) anim.SetInteger("Direction", 1);
                else if (forceX == 1 && forceY == 1) anim.SetInteger("Direction", 4);
                else if (forceX == -1 && forceY == 1) anim.SetInteger("Direction", 6);
                else if (forceX == -1 && forceY == -1) anim.SetInteger("Direction", 8);
                else if (forceX == 1 && forceY == -1) anim.SetInteger("Direction", 2);
            
            // if(angulbala<22.5f&&angulbala>=287.5f) anim.SetInteger("Direction", 12);
            // anim.SetInteger("Direction", 1);

           

            //El sprite se rota, hay un problema vuelve a la rotación inicial al principio
            //transform.up = fuerzas;

            if (Input.GetKeyDown("1"))
            {
                GameManager.GetInstance().MusicaClásica();
            }
            else if (Input.GetKeyDown("2"))
            {
                GameManager.GetInstance().MusicaHeavy();
            }
            else if (Input.GetKeyDown("3"))
            {
                GameManager.GetInstance().MusicaElectric();
            }
        }
        else
        {
            Invoke("Paralisis", 1);
            fuerzas = Vector2.zero;
        }
        
    }
    //Para movimientos físicos
    void FixedUpdate()
    {
        rb.velocity = fuerzas * velocityScale;
    }
    void Paralisis()
    {
        GameManager.GetInstance().CambiarEstadoParalisis();
    }
}
