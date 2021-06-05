using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Daniel , Miriam y Javi

public class EnemDamageGuardia : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator anima;

    GameManager gameManager;
    AudioManager audioManager;
    int golpe = 2;
    Guardia guardia;
    ShooterGuardia shooterGuardia;
    private UiEnemies uiEnemies;

    private void Start()
    {

     
        rigidBody2D = GetComponent<Rigidbody2D>();
        guardia = GetComponent<Guardia>();
        shooterGuardia = GetComponentInChildren<ShooterGuardia>();
        anima = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        audioManager = GameManager.GetInstance().GetAudioManagerInstance().GetComponent<AudioManager>();
    }

    //metodo que llama a GuardiaDaño() si el GO colisionado posee el script VelocidadDisco
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //METEMOS QUE SOLO EL DISCO DEL JUG PUEDE HACER DAÑO
        if (collision.GetComponent<VelocidadDisco>())
        {
            GuardiaDaño();
        }
    }

    //metodo que cuenta las vidas de la UI del Guardia
    public void vidasUIGuardia(UiEnemies uie)
    {
        uiEnemies = uie;
        uiEnemies.VidaGuardia(2, golpe);
    }
    //metodo que se encarga del daño de los golpes de los guardias según la música y de sus animaciones.
    void GuardiaDaño()
    {
        
        if (GameManager.GetInstance().Musica() == GameManager.Music.heavy)
        {
            golpe = golpe - 2; 
        }
        else 
        {
            golpe = golpe - 1;
        }
        


        if (golpe<=0)
        //para animacion de matarlo
        {
            if(guardia && shooterGuardia)
            {
                guardia.enabled = false;
                shooterGuardia.enabled = false;
            }
            Invoke("MuerteGuardia", 1f);

            anima.SetBool("Muerte", true);
            anima.SetBool("Disparar", false);
            anima.SetBool("Correr", false);//llamas al parametro;
            anima.SetBool("Porra", false);//llamas al parametro;
                                             //llamas al parametro;


            rigidBody2D.velocity = Vector2.zero;
            Invoke("Destruir", 0.75f);
            //MuerteGuardia();
            GameManager.GetInstance().RemoveEnemy();
        }

        audioManager.Play("ImpactoGuardia");
    }
    
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
