using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamagePolicia : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator anima;

  
    AudioManager audioManager;
    private UiPolicia uiPoli;
    int golpe = 4;
    RobotPoliciaMovimiento robotPoliciaMovimiento;
    private void Start()
    {
       
        
        rigidBody2D = GetComponent<Rigidbody2D>();
        robotPoliciaMovimiento = GetComponent<RobotPoliciaMovimiento>();
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
            RobotDaño();
        }
    }
    public void vidasUIRobot(UiPolicia uie)
    {
        uiPoli = uie;
        uiPoli.VidaPoli(4, golpe);
    }
    void RobotDaño()
    {
        if (GameManager.GetInstance().Musica() == GameManager.Music.electronic) golpe = golpe - 2;
        else golpe--;

        if (golpe<=0)
        {
            if (robotPoliciaMovimiento) robotPoliciaMovimiento.enabled = false;
            anima.SetBool("Disparo", false);
            anima.SetBool("Embestir", false);
            anima.SetBool("Retroceder", false);
            anima.SetBool("Morir", true);
            Invoke("Destruir", 0.55f);
            GameManager.GetInstance().RemoveEnemy();
        }

        audioManager.Play("ImpactoPolicia");
    }
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}
