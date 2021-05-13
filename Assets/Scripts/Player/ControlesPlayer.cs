using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPlayer : MonoBehaviour
{
    //Declaración de variables
    [SerializeField]
    float velocityScale;//velocidad de movimiento
    float forceX, forceY, tiempoAux = 0;
    Rigidbody2D rb;
    Vector2 fuerzas;
    Animator anim;
    ShooterApuntadoRaton shooter;
    float angu;
    float[] angul = new float[10];
    float angulbala = 0;
    //Accedemos al componente shooter para disparar una bala al pulsar la tecla espacio
    void Start()
    {
        shooter = GetComponentInChildren<ShooterApuntadoRaton>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        angul[0] = 90;
        for (int i = 1; i < angul.Length - 1; i++)
        {
            if (i == 1) angul[i] = angul[i - 1] - 22.5f;
            else angul[i]= angul[i - 1] - 45;
        }
        angul[angul.Length - 1] = -360;
      
    }
   
    void Update()
    {
        tiempoAux = tiempoAux - Time.deltaTime;
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
            if (forceX > 0 && forceY == 0) anim.SetInteger("Direction", 3);
            else if (forceX < 0 && forceY == 0) anim.SetInteger("Direction", 7);
            else if (forceX == 0 && forceY > 0) anim.SetInteger("Direction", 5);
            else if (forceX == 0 && forceY < 0) anim.SetInteger("Direction", 1);
            else if (forceX == 1 && forceY == 1) anim.SetInteger("Direction", 4);
            else if (forceX == -1 && forceY == 1) anim.SetInteger("Direction", 6);
            else if (forceX == -1 && forceY == -1) anim.SetInteger("Direction", 8);
            else if (forceX == 1 && forceY == -1) anim.SetInteger("Direction", 2);

            if (Input.GetMouseButton(0))
            {
                shooter.Disparo();
                angu = GetComponentInChildren<ShooterApuntadoRaton>().angulo;
                angulbala = angu;
                tiempoAux = 0.2f;
                if (angulbala>= angul[7] && angulbala< angul[6]) anim.SetBool("dispfront",true);
                else if (angulbala >= angul[5] && angulbala < angul[4]) anim.SetBool("dispder", true);
                else if(angulbala >= angul[6] && angulbala < angul[5]) anim.SetBool("diagoder", true);
                else if(angulbala >= angul[4] && angulbala < angul[3]) anim.SetBool("disdigatrasder", true);
                else if (angulbala >= angul[3] && angulbala < angul[2]) anim.SetBool("atras",true);
                else if (angulbala >= angul[2] && angulbala < angul[1]) anim.SetBool("dig", true);                        
                else if (angulbala >= angul[8] && angulbala < angul[7]) anim.SetBool("sdigfront", true);
                else if(angulbala >= angul[1] && angulbala < angul[0] || angulbala >= angul[9] && angulbala < angul[8]) anim.SetBool("sperfizqu", true);
            }        
            //Contador para que se quede la animación de disparo en esa dirección durante 0.2 segundos
            else if(tiempoAux <=0)
            {
              anim.SetBool("dispfront", false);
              anim.SetBool("dispder", false);
              anim.SetBool("diagoder", false);
              anim.SetBool("disdigatrasder",false);
              anim.SetBool("atras", false);
              anim.SetBool("dig", false);
              anim.SetBool("sdigfront", false);
              anim.SetBool("sperfizqu",false);
            }
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
        else if(paralisis)
        {
            Invoke("Paralisis", 1);  
        }
        else
        {
            fuerzas = Vector2.zero;
            CancelInvoke();
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
