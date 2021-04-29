using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script asociado al "cañón" del robot
public class RobotPoliciaDisparo : MonoBehaviour
{
    [SerializeField]
    GameObject rayoStoon, rayoDaño;
    [SerializeField]
    float cadencia;
    [SerializeField]
    int velocidad;
    float tiempoAux = 0;
    //Contador para que disparen cada cadencia segundos
    private void Update()
    {
        tiempoAux = tiempoAux - Time.deltaTime;
    }
    //Si el contador lo permite dispara un rayo que hace 2 golpes de daño
    public void MusicaElectronica(float rotationZ)
    {
        if (tiempoAux <= 0)
        {
            Instantiate(rayoDaño, transform.position, Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, rotationZ)));
            tiempoAux = cadencia;
        }
    }
    //Si el contador lo permite dispara un rayo que hace 1 golpe de daño y stoonea al player
    public void MusicaClasica(float rotationZ)
    {
        if (tiempoAux <= 0)
        {
            Instantiate(rayoStoon, transform.position, Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, rotationZ)));
            tiempoAux = cadencia;
        }
    }
}
