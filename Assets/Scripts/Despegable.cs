using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despegable : MonoBehaviour
{     
     Animator animboton;
    [SerializeField ]
     static bool GameIsPaused = true;//por defecto
    private int contador = 0;
   
    // Start is called before the first frame update
    //segun si es false o true hacer la animacion.
    void Start()
    {
        animboton = GetComponent<Animator>();
       
     
    }

    // Update is called once per frame
    void Update()
    {if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused) //si no está pausado no queremos meter cuadro de texto
            {
                Resume();//esconder cuadro de texto

            }
            else//gameispaused=true , si esta pausado queremos cuadro de texto de pausa
            {
                Pause();

            }
        }
        
            
               
            
    }
     void Resume()//si esta parado que se esconda el cuadro de texto y vuelva a la normalidad , si saliendo = false , significa que tiene que esconderse el cuadro de texto
     {
            animboton.SetBool("Saliendo", false);
            Time.timeScale = 1f;//lo se , es para que no se pare
            GameIsPaused = true;
     }
     void Pause()
     {
            animboton.SetBool("Saliendo", true);
            Time.timeScale = 0f;
            GameIsPaused = false;
     }
}
