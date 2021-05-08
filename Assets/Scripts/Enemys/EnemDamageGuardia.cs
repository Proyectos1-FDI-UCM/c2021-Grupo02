using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamageGuardia : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator anima;

    GameManager gameManager;
    AudioManager audioManager;
    int golpe = 2;
    Guardia guardia;
    ShooterGuardia shooterGuardia;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //METEMOS QUE SOLO EL DISCO DEL JUG PUEDE HACER DAÑO
        if (collision.GetComponent<VelocidadDisco>())
        {
            GuardiaDaño();
        }
    }
    void GuardiaDaño()
    {
        if (GameManager.GetInstance().Musica() == GameManager.Music.heavy) GameManager.GetInstance().VidaGuardia(2);
        else GameManager.GetInstance().VidaGuardia(1);



        if (GameManager.GetInstance().GuardiaMuerto())
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
