using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPolicia : MonoBehaviour
{
    [SerializeField]
    Image barraVidaG;
    EnemDamagePolicia enemDamagePolicia;
    private void Start()
    {
        enemDamagePolicia = GetComponentInParent<EnemDamagePolicia>();
    }
    private void Update()
    {
        enemDamagePolicia.vidasUIRobot(this);
    }
    public void VidaPoli(float golpepoli, float golpeActupoli)
    {

        barraVidaG.fillAmount = golpeActupoli / golpepoli;
    }
}
