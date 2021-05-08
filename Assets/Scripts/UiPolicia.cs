using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPolicia : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Image barraVidaG;
    // Start is called before the first frame update
    private void Update()
    {
        GameManager.GetInstance().UIVidaPolicia(this);
    }
    public void VidaPoli(float golpepoli, float golpeActupoli)
    {

        barraVidaG.fillAmount = golpeActupoli / golpepoli;
    }
}
