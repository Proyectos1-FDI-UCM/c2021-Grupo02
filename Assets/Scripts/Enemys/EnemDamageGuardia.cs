﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamageGuardia : MonoBehaviour
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
            GuardiaDaño();
        }
    }
    void GuardiaDaño()
    {
        if (GameManager.GetInstance().Musica() == GameManager.Music.heavy) golpe = golpe - 2;
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
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}