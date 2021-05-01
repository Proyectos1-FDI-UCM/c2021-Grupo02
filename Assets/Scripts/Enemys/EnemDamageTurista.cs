using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamageTurista : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator anima;

    GameManager gameManager;
    AudioManager audioManager;
    int golpeTurista = 1, golpe = 2;
    public int golpeRobot = 4;
    Guardia guardia;
    ShooterGuardia shooterGuardia;
    RobotPoliciaMovimiento robotPoliciaMovimiento;

    private void Start()
    {
        gameManager = GameManager.GetInstance();
        audioManager = gameManager.GetAudioManagerInstance().GetComponent<AudioManager>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        guardia = GetComponent<Guardia>();
        shooterGuardia = GetComponentInChildren<ShooterGuardia>();
        robotPoliciaMovimiento = GetComponent<RobotPoliciaMovimiento>();
        anima = GetComponentInChildren<Animator>();
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
        audioManager.Play("ImpactoGuardia");

        rigidBody2D.velocity = Vector2.zero;
        anima.SetBool("Muerto", true);
        anima.SetBool("Heavy", false);
        anima.SetBool("Electrica", false);
        anima.SetBool("Dream", false);
        anima.SetBool("Mov", false);
        golpeTurista = golpeTurista -1;
        GameManager.GetInstance().Perder(true);
        Invoke("Destruir", 0.85f);
    }
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
