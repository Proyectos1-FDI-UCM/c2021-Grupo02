using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoHeavy : MonoBehaviour
{     
    CircleCollider2D circleCollider2D;
    bool heavy = false;
    [SerializeField]
    float horizontal=0, vertical=0;
    Vector2 ini;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        ini = transform.position;
    }
    void Update()
    {
        GameManager.Music musica = GameManager.GetInstance().Musica();
        if (musica == GameManager.Music.heavy && !heavy)
        {
            circleCollider2D.enabled = true;
            Heavy();
            heavy = true;
        }
        else if(musica == GameManager.Music.classic || musica == GameManager.Music.electronic)
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
        float x2 = Random.Range(ini.x-horizontal,ini.x+ horizontal);
        float y2 = Random.Range(ini.y-vertical, ini.y+vertical); 
        transform.position = new Vector2(x2, y2);
        
    }
}

