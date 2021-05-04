using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamagePolicia : MonoBehaviour
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
            RobotDaño();
        }
    }
    
    void RobotDaño()
    {
        if (GameManager.GetInstance().Musica() == GameManager.Music.electronic) golpeRobot = golpeRobot-2;
        else golpeRobot = golpeRobot-1;

        audioManager.Play("ImpactoPolicia");

        if (golpeRobot <= 0)
        {
            if (robotPoliciaMovimiento) robotPoliciaMovimiento.enabled = false;
            anima.SetBool("Disparo", false);
            anima.SetBool("Embestir", false);
            anima.SetBool("Retroceder", false);
            anima.SetBool("Morir", true);
            Invoke("Destruir", 0.55f);
            GameManager.GetInstance().RemoveEnemy();
        }
    }
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
