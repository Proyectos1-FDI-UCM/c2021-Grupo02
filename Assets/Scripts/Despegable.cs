using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despegable : MonoBehaviour
{
    public Animator animboton;
    private Boton boton;
   
    // Start is called before the first frame update
    //segun si es false o true hacer la animacion.
    void Start()
    {
        animboton = GetComponent<Animator>();
        boton = GameObject.Find("Code").GetComponent<Boton>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boton.showMenu)
        {
            animboton.SetBool("Saliendo", true);
        }
        if (boton.showMenu==false)
        {
            animboton.SetBool("Saliendo", false);
        }
    }
}
