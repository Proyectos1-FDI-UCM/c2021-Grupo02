using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamage : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    public Animator anima;

    int golpeTurista = 1, golpe = 2;
    public int golpeRobot = 4;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
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

        if (golpe <= 0)
        //para animacion de matarlo
        {
            Invoke("MuerteGuardia", 1f);
            Debug.Log("SI QUE VA");
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
        Debug.Log(golpe);
    }
    void RobotDaño()
    {
        if (GameManager.GetInstance().Musica() == 'e') golpeRobot = golpeRobot-2;
        else golpeRobot = golpeRobot-1;
        if (golpeRobot <= 0)
        {
            Invoke("Destruir", 1.25f);
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
