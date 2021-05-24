using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoGanar : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D colision)
    {
        
      
        Destroy(this.gameObject);
        GameManager.GetInstance().Perder(false);

    }

}
