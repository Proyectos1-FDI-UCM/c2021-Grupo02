using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habita : MonoBehaviour
{
    [SerializeField]
    GameObject puerta1, puerta2;
    void Start()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ControlesPlayer>())    //Solo se produce si el objeto que entra en el trigger es el jugador
        {
            gameObject.layer = 0;
            GameManager.GetInstance().EntrarSala();
            Invoke("DoorClosed", 1);

        }
        if (collision.gameObject.GetComponent<RobotPoliciaMovimiento>()|| collision.gameObject.GetComponent<Guardia>())
        GameManager.GetInstance().AddEnemy();
        

       
       
       
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
