﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOff : MonoBehaviour
{
    public Material colorInicial;
    public  new Renderer renderer;
    public float velocidadFade = 0.1f;
    private float alpha = 1.0f;//componente del color A que cambiamos ya qye controla la opacidad
                               // Start is called before the first frame update
    void Start()
    {
        renderer=GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material = colorInicial;
        
            colorInicial.color = new Color(0, 0, 0, alpha);
            alpha -= velocidadFade = Time.deltaTime;
            if (alpha <= 0)
            { Destroy(this.gameObject); }
        
        
    }
}