using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habita : MonoBehaviour
{
    public GameObject puerta1, puerta2;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  if(collision.gameObject.GetComponent<Guardia>() && collision.gameObject.GetComponent<RobotPoliciaMovimiento>())
        //{
            
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<RobotPoliciaMovimiento>()|| collision.gameObject.GetComponent<Guardia>())
        GameManager.GetInstance().AddEnemy();
        

        if (collision.gameObject.GetComponent<ControlesPlayer>())    //Solo se produce si el objeto que entra en el trigger es el jugador
        {
            GameManager.GetInstance().EntrarSala();
            Invoke("DoorClosed",1);
            
        }
       
       
    }
    void DoorClosed()
    {
        puerta1.SetActive(true);
    }


private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (GameManager.GetInstance().Enemiesmuertos())    //Solo se produce si el objeto que entra en el trigger es el jugador
        {
            GameManager.GetInstance().SalirSala();
            puerta2.SetActive(false);
        }
    }

}
