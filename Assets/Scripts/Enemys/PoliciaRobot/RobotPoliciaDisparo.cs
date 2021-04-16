﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script asociado al "cañón" del robot
public class RobotPoliciaDisparo : MonoBehaviour
{
    public float cadencia;
    public GameObject rayoStoon, rayoDaño;
    public int velocidad;
    float tiempoAux = 0;
    //Contador para que disparen cada cadencia segundos
    private void Update()
    {
        tiempoAux = tiempoAux - Time.deltaTime;
    }
    //Si el contador lo permite dispara un rayo que hace 2 golpes de daño
    public void MusicaElectronica()
    {
        if (tiempoAux <= 0)
        {
            Instantiate(rayoDaño, transform.position, transform.rotation);
            tiempoAux = cadencia;
        }
    }
    //Si el contador lo permite dispara un rayo que hace 1 golpe de daño y stoonea al player
    public void MusicaClasica()
    {
        if (tiempoAux <= 0)
        {
            Instantiate(rayoStoon, transform.position, transform.rotation);
            tiempoAux = cadencia;
        }
    }
    //Comportamiento de música HeavyMetal
    void MusicaHeavyMetal()
    {

    }
}
