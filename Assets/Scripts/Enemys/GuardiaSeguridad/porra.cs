using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porra : MonoBehaviour
{
    public float tiempo = 1;
    bool pegar = true;
    private CircleCollider2D collider;
    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        char music = GameManager.GetInstance().Musica();
        if (music == 'h')
        {
           
            if (pegar)
            {
                collider.isTrigger = true;
                pegar = false;
                Invoke("Pegar", 0);
                
            }

        }
        else 
        {
            CancelInvoke();
            collider.isTrigger = false;
            pegar = true;
        }
    }
        void Pegar()
        {

                gameObject.SetActive(true);
                Invoke("Nopegar", tiempo);
            
        }
        void Nopegar()
        {
            gameObject.SetActive(false);
            Invoke("Pegar", tiempo);
        }
    
}
