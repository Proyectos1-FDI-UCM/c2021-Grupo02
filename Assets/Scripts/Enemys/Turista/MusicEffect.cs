using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEffect : MonoBehaviour
{
    public Animator anima;
    [SerializeField]
    float limitehorizontal = 3f;
    [SerializeField]
    float limitevertical = 1.5f;
    public Transform PuntoAleatorio, player;//te coge el componente Transform de todo el GO
    public float fuerzaTuristaHeavy = 10;
    [SerializeField]
    float fuerzaTuristaElectronica = 5;
    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D BoxCollider2D ;
    Vector3 posElectronic;
    bool heavy = false, electric = false, clasic = false;
    char musica;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
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
        if (player != null)
        {
            if (musica == 'c' && !clasic)
            {
                Cancelar();
                MusicaClasica();
                clasic = true;
                heavy = false;
                electric = false;
            }
            else if (musica == 'h' && !heavy)
            {
                Cancelar();
                MusicaHeavy();
                clasic = false;
                heavy = true;
                electric = false;
            }
            else if (musica == 'e' && !electric)
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
        if (GameManager.GetInstance().EstadoSala() && !metodo)
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
        transform.position = Vector2.MoveTowards(transform.position, PuntoAleatorio.position, fuerzaTuristaHeavy * Time.deltaTime);
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
        float x1 = Random.Range(-limitehorizontal , limitehorizontal );
        float y1 = Random.Range(-limitevertical, limitevertical);
        posElectronic = new Vector3(x1, y1, 0);

        if (transform.position.x > -limitehorizontal && transform.position.y > -limitevertical && transform.position.y < limitevertical)
        {
            Rigidbody2D.velocity = new Vector2(transform.position.x - posElectronic.x, transform.position.y - posElectronic.y) * -1 * fuerzaTuristaElectronica;//2=velocidad          
        }
        if (Rigidbody2D.velocity.x<0)
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
