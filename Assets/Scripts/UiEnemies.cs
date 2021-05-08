using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiEnemies : MonoBehaviour
{
    [SerializeField]
    Image barraVidaG;
    // Start is called before the first frame update
    private void Update()
    {
        GameManager.GetInstance().UIEnemiesUpdate(this);
    }
    public void VidaGuardia(float golpeguardia, float golpeActuGuardia)
    {
    
        barraVidaG.fillAmount =golpeActuGuardia/golpeguardia;
    }
  
}

