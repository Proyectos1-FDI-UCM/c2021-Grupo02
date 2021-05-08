using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiEnemies : MonoBehaviour
{
    [SerializeField]
    Image barraVidaG;
    EnemDamageGuardia enemDamageGuardia;

    private void Start()
    {

        enemDamageGuardia = GetComponentInParent<EnemDamageGuardia>();
    }
    private void Update()
    {
        enemDamageGuardia.vidasUIGuardia(this);
    }
    public void VidaGuardia(float golpeguardia, float golpeActuGuardia)
    {
        barraVidaG.fillAmount =golpeActuGuardia/golpeguardia;
    }
  
}

