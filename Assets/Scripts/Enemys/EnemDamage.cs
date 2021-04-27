using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamage : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    public Animator anima;

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
        audioManager = gameManager.GetAudioManagerInstance();
        rigidBody2D = GetComponent<Rigidbody2D>();
        guardia = GetComponent<Guardia>();
        shooterGuardia = GetComponentInChildren<ShooterGuardia>();
        robotPoliciaMovimiento = GetComponent<RobotPoliciaMovimiento>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //METEMOS QUE SOLO EL DISCO DEL JUG PUEDE HACER DAÑO
        if (collision.GetComponent<VelocidadDisco>())
        {
            if (GetComponent<Guardia>()) GuardiaDaño();
            else if (GetComponent<RobotPoliciaMovimiento>()) RobotDaño();
            else TuristaDaño();
        }
    }
    void GuardiaDaño()
    {
        if (GameManager.GetInstance().Musica() == 'h') golpe = golpe - 2;
        else golpe = golpe - 1;

        audioManager.Play("ImpactoGuardia");        

        if (golpe <= 0)
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
    }
    void RobotDaño()
    {
        if (GameManager.GetInstance().Musica() == 'e') golpeRobot = golpeRobot-2;
        else golpeRobot = golpeRobot-1;
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
    }
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
