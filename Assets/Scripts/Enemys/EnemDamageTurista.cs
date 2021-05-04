using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamageTurista : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator anima;

    GameManager gameManager;
    AudioManager audioManager;
    int golpeTurista = 1;

    private void Start()
    {
        gameManager = GameManager.GetInstance();
        rigidBody2D = GetComponent<Rigidbody2D>();
        anima = GetComponentInChildren<Animator>();
        audioManager = gameManager.GetAudioManagerInstance().GetComponent<AudioManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //METEMOS QUE SOLO EL DISCO DEL JUG PUEDE HACER DAÑO
        if (collision.GetComponent<VelocidadDisco>())
        {
            TuristaDaño();
        }
    }

    void TuristaDaño()
    {
        

        rigidBody2D.velocity = Vector2.zero;
        anima.SetBool("Muerto", true);
        anima.SetBool("Heavy", false);
        anima.SetBool("Electrica", false);
        anima.SetBool("Dream", false);
        anima.SetBool("Mov", false);
        golpeTurista = golpeTurista -1;
        GameManager.GetInstance().Perder(true);
        Invoke("Destruir", 0.85f);
        
        audioManager.Play("ImpactoGuardia");
    }
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
