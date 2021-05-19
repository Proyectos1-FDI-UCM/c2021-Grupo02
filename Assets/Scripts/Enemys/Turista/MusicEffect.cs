using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEffect : MonoBehaviour
{
    [SerializeField]
    Animator anima;
    [SerializeField]
    float limitehorizontal = 3f;
    [SerializeField]
    float limitevertical = 1.5f;
    [SerializeField]
    Transform PuntoAleatorio, player;//te coge el componente Transform de todo el GO
    [SerializeField]
    float fuerzaTuristaHeavy = 10;
    [SerializeField]
    float fuerzaTuristaElectronica = 5;
    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D BoxCollider2D ;
    Vector3 posElectronic;
    bool heavy = false, electric = false, clasic = false;
    GameManager.Music musica;
    Vector2 ini;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        ini = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EfectoHeavy>()) Rigidbody2D.velocity = Vector2.zero;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Rigidbody2D.isKinematic = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        Rigidbody2D.isKinematic = false;
    }
    public void Empezar()
    {
        //Al morir que solo haga la animación y se cancele el movimiento eléctrico
        if (Rigidbody2D.velocity == Vector2.zero) Cancelar();
        if (player != null)
        {
            if (musica == GameManager.Music.classic && !clasic)
            {
                Cancelar();
                MusicaClasica();
                clasic = true;
                heavy = false;
                electric = false;
            }
            else if (musica == GameManager.Music.heavy && !heavy)
            {
                Cancelar();
                MusicaHeavy();
                clasic = false;
                heavy = true;
                electric = false;
            }
            else if (musica == GameManager.Music.electronic && !electric)
            {
                Cancelar();
                MusicaElectronica();
                clasic = false;
                heavy = false;
                electric = true;
            }
        }
        else Cancelar();
    }
    // Update is called once per frame
    void Update()
    {
        musica = GameManager.GetInstance().Musica();
        bool metodo = false;
        if (/*GameManager.GetInstance().EstadoSala()*//* &&*/ !metodo)
        {
            Empezar();
            metodo = true;
        }
    }
    public void Cancelar()
    {
        CancelInvoke();
    }
    public void MusicaHeavy()
    {
        anima.SetBool("Dream", false);
        anima.SetBool("Heavy", true);
        BoxCollider2D.enabled = true;
        Rigidbody2D.velocity = new Vector2(transform.position.x - PuntoAleatorio.position.x, transform.position.y - PuntoAleatorio.position.y) * -1 * fuerzaTuristaHeavy;
        if ((PuntoAleatorio.position - transform.position).magnitude > 1) Invoke("MusicaHeavy", 0.01f);
        if (transform.position.x < 0)
        {
            anima.SetBool("Mov", false);
            anima.SetBool("MovIzq", true);
        }
        else
        {
            anima.SetBool("Mov", true);
            anima.SetBool("MovIzq", false);
        }
    }
    public void MusicaClasica()
    {
        anima.SetBool("Heavy", false);
        anima.SetBool("Electrica", false);
        anima.SetBool("Mov", false);
        BoxCollider2D.enabled = false;
        anima.SetBool("Dream", true);
        Rigidbody2D.velocity = Vector2.zero;
    }
    public void MusicaElectronica()
    {
        anima.SetBool("Heavy", false);
        anima.SetBool("Electrica", true);
        anima.SetBool("Dream", false);
        BoxCollider2D.enabled = true;//el turista se mueve de manera aleatoria entre 4 posibilidades , arriba , abajo , izq y der
        float x1 = Random.Range(ini.x-limitehorizontal , ini.x+limitehorizontal );
        float y1 = Random.Range(ini.y-limitevertical,ini.y+ limitevertical);
        posElectronic = new Vector3(x1, y1, 0);

        if (transform.position.x > ini.x-limitehorizontal && transform.position.y > ini.y-limitevertical && transform.position.y < ini.y+limitevertical&&transform.position.x<ini.x+limitehorizontal)
        {
            Rigidbody2D.velocity = new Vector2(transform.position.x - posElectronic.x, transform.position.y - posElectronic.y) * -1 * fuerzaTuristaElectronica;//2=velocidad          
        }
        else
        {
            Rigidbody2D.velocity=new Vector2(transform.position.x - ini.x, transform.position.y - ini.y) * -1 * fuerzaTuristaElectronica;
        }
        if (Rigidbody2D.velocity.x < 0)
        {
            anima.SetBool("Mov", false);
            anima.SetBool("MovIzq", true);
        }
        else
        {
            anima.SetBool("Mov", true);
            anima.SetBool("MovIzq", false);
        }
        Invoke("MusicaElectronica", 1);//así invoca otro movimiento aleatorio en ejeX y ejeY cada segundo
    }
}
