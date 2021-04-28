using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image[] pila = new Image[10];
    [SerializeField]
    Image disco;
    [SerializeField]
    Sprite[] vacia = new Sprite[11];
    [SerializeField]
    Sprite discoClasic, discoHeavy, discoElectric;
    [SerializeField]
    Text numeroDiscos;
    [SerializeField]
    Animator cintaClasicAni, cintaHeavyAni, cintaElectricAni;
    [SerializeField]
    RectTransform PilasPanel, PanelDiscos, cintaClasic, cintaHeavy, cintaElectric;
    
    private void Update()
    {
        GameManager.GetInstance().UIManagerUpdate(this);
    }
    // Dibuja y escribe las vidas, discos y balas disponibles
    public void VariarDiscos(int Discos, char musica)
    {
        numeroDiscos.text = "x" + Discos.ToString();
        if(musica == 'c')
        {
            disco.sprite = discoClasic;
            cintaClasicAni.enabled = true;
            cintaHeavyAni.enabled = false;
            cintaHeavy.rotation = Quaternion.Euler(Vector2.zero);
            cintaElectricAni.enabled = false;
            cintaElectric.rotation = Quaternion.Euler(Vector2.zero);
        }
        else if (musica == 'h')
        {
            disco.sprite = discoHeavy;
            cintaClasicAni.enabled = false;
            cintaClasic.rotation = Quaternion.Euler(Vector2.zero);
            cintaHeavyAni.enabled = true;
            cintaElectricAni.enabled = false;            
            cintaElectric.rotation = Quaternion.Euler(Vector2.zero);        
        }
        else if(musica == 'e')
        {
            disco.sprite = discoElectric;
            cintaClasicAni.enabled = false;
            cintaClasic.rotation = Quaternion.Euler(Vector2.zero);
            cintaHeavyAni.enabled = false;
            cintaHeavy.rotation = Quaternion.Euler(Vector2.zero);   
            cintaElectricAni.enabled = true;        
        }      
    }
    // Actualiza el número de vidas dibujado
    public void UpdateLives(int vidas)
    {
        //Rellena todas las pilas según la vida que tenga el player
        for (int i = 0; i <= 10; i++)
        {
            //Llena todas las pilas si el numero de vidas es menor de su decena,
            //es decir ej si tiene 70 de vida, llena las pilas 1,2,3,4,5,6 y en la 7 se para y entra en el siguiente else if
            if (i < (vidas / 10))
            {
                pila[i].sprite = vacia[0];
            }
            //Si es su decena mira a ver que cantidad de vida tiene para rellenarla con el sprite correspondiente
            //El 100 se considera entero de vida y cuenta como excepción
            else if( i != 10 && i == (vidas / 10)) { 
            if (vidas % 10 == 1) pila[i].sprite = vacia[9];
            else if (vidas != 0 && vidas % 10 == 2) pila[i].sprite = vacia[8];
            else if (vidas != 0 && vidas % 10 == 3) pila[i].sprite = vacia[7];
            else if (vidas != 0 && vidas % 10 == 4) pila[i].sprite = vacia[6];
            else if (vidas != 0 && vidas % 10 == 5) pila[i].sprite = vacia[5];
            else if (vidas != 0 && vidas % 10 == 6) pila[i].sprite = vacia[4];
            else if (vidas != 0 && vidas % 10 == 7) pila[i].sprite = vacia[3];
            else if (vidas != 0 && vidas % 10 == 8) pila[i].sprite = vacia[2];
            else if (vidas != 0 && vidas % 10 == 9) pila[i].sprite = vacia[1];
            else if (vidas != 0 && vidas % 10 == 0) pila[i].sprite = vacia[10];
            }
            //Dibuja las pilas vacías que estén por encima de la decena 
            else if(i != 10)
            {
                    pila[i].sprite = vacia[10];  
            }
        }
    }   
}
