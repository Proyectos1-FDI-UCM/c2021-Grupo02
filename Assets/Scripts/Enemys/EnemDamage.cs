using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemDamage : MonoBehaviour
{
    Rigidbody2D turistaRigidBody;
    public Animator anima;
    int golpeTurista = 1;
    int golpe = 2;
    public int golpeRobot = 4;

    private void Start()
    {
        turistaRigidBody = GetComponent<Rigidbody2D>();
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
        if (GameManager.GetInstance().Musica() == 'h') golpe=golpe -2;
        else golpe = golpe-1;
        
        if (golpe <= 0)
        {
            Destroy(gameObject);
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
        turistaRigidBody.velocity = Vector2.zero;
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
