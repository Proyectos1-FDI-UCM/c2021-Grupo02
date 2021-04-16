using UnityEngine;
//Script asociado a la pistola del guardia de seguridad
public class ShooterGuardia : MonoBehaviour
{
    public GameObject prefab;      //GO a instanciar
    char musica;                   //Almacenara la musica que suene en ese momento
    char musicaVieja = ' ';
    public Transform player; 

    //Almacenara la musica antigua. Empezará siendo ninguna
    private void Update()
    {
        musica = GameManager.GetInstance().Musica();          //En musica se guarda la musica que suene en ese momento
        if (musica != musicaVieja)                            //Si la musica ha cambiado, es decir si la de ahora es diferente a la de antes
        {
            musicaVieja = musica;                             //La musica actual pas a ser la amtigua, para que al cambiar se note la diferencia
            if (musica == 'c' )
            {
                DisparoClasica();
            }               
            else if (musica == 'e')
            {
                DisparoElectrica();
            }
            else CancelInvoke();


        }
    }
    public void DisparoElectrica()  //Disparo del Guardia de seguridad con la musica electricas
    {
        Cancelar();
        InvokeRepeating("Automatic", 0.5f, 0.5f);  //Dispara 2 balas por segundo
    }
    public void DisparoClasica()  //Disparo del Guardia de seguridad con la musica clasica
    {
        Cancelar();
        InvokeRepeating("Automatic", 1f, 1f); //Dispara una bala cada segundo
    }
    //Metodo que se encarga del disparo automatico de los enemigos
    public void Automatic()
    {
        if (player != null)
        {
            //Calculo la distancia entre el jugador y el cañón y si están a más de 4 no dispara
            Vector2 direction = player.position - transform.position;
            if (direction.magnitude < 4)
                Instantiate<GameObject>(prefab, transform.position, transform.rotation);   //Se crea un clon de la bala en la posicion del GO que posea este script
        }
    }
    private void Cancelar()
    {
        CancelInvoke();  //Se cancelan las invocaciones anteriores para que no haya problemas
    }


}
