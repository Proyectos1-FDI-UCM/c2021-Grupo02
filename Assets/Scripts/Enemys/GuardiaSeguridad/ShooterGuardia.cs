using UnityEngine;
//Script asociado a la pistola del guardia de seguridad
public class ShooterGuardia : MonoBehaviour
{
    public GameObject prefab;      //GO a instanciar
    char musica;                   //Almacenara la musica que suene en ese momento
    char musicaVieja = ' ';
    public Transform player;
    float angle;
    Vector2 direction;
    public Animator animator;

    //Almacenara la musica antigua. Empezará siendo ninguna
    private void Update()
    {
        musica = GameManager.GetInstance().Musica();          //En musica se guarda la musica que suene en ese momento
        if (musica != musicaVieja && !GameManager.GetInstance().EstadoJugador())                            //Si la musica ha cambiado, es decir si la de ahora es diferente a la de antes
        {
            musicaVieja = musica;                             //La musica actual pas a ser la amtigua, para que al cambiar se note la diferencia
            if (musica == 'c' )
            {
                Cancelar();
                DisparoClasica();
            }               
            else if (musica == 'e')
            {
                Cancelar();
                DisparoElectrica();
            }
            else CancelInvoke();
        }
        //Calcula el ángulo que tiene que girar a partir de la distancia a la que se encuentra del jugador
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
    public void DisparoElectrica()  //Disparo del Guardia de seguridad con la musica electricas
    {
        //InvokeRepeating("Disparos", 0.5f, 0.5f);
        Invoke("Automatic", 0.5f);  //Dispara 2 balas por segundo
        //activar animacion disparo
    }
    public void DisparoClasica()  //Disparo del Guardia de seguridad con la musica clasica
    {
        
        Invoke("Automatic", 1f); //Dispara una bala cada segundo

    }  
    public void Automatic()
    {
            if (direction.magnitude < 4)
            {
                Instantiate<GameObject>(prefab, transform.position, Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, angle - 90)));   //Se crea un clon de la bala en la posicion del GO que posea este script
                animator.SetBool("Correr", false);//llamas al parametro;
                animator.SetBool("Porra", false);//llamas al parametro;
                animator.SetBool("Muerte", false);//llamas al parametro;
                animator.SetBool("Disparar", true);
            }              
        if(musica == 'e') Invoke("Automatic", 0.5f);
        else if(musica == 'c') Invoke("Automatic", 1f); ;
    }
    private void Cancelar()
    {
        CancelInvoke();  //Se cancelan las invocaciones anteriores para que no haya problemas
    }
    private void OnDisable()
    {
        Cancelar();
    }
}
