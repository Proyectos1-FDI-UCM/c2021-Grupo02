using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoHeavy : MonoBehaviour
{     
    CircleCollider2D circleCollider2D;
    bool heavy = false;
    [SerializeField]
    float horizontal=0, vertical=0;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        char musica = GameManager.GetInstance().Musica();
        if (musica == 'h' && !heavy)
        {
            circleCollider2D.enabled = true;
            Heavy();
            heavy = true;
        }
        else if(musica == 'e' || musica == 'c')
        { 
            circleCollider2D.enabled = false;
            heavy = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MusicEffect>())
        {
            collision.GetComponent<MusicEffect>().Cancelar();
  
        }
    }
    public void Heavy()
    {
        

        float x2 = Random.Range(-horizontal, horizontal);
        float y2 = Random.Range(-vertical, vertical); 
        transform.position = new Vector2(x2, y2);
        
    }
}

