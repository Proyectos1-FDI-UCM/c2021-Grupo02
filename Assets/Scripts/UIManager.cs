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
    RectTransform PilasPanel, PanelDiscos, cintaClasic, cintaHeavy, cintaElectric, winScreen, loseScreen, MenuPausa, menuControlesRect, menuSonidoRect;
    [SerializeField]
    static bool GameIsPaused = false;
    private int contador = 0;
   
    

    private void Update()
    {
        GameManager.GetInstance().UIManagerUpdate(this);
        if (Input.GetKeyDown(KeyCode.Escape)) Desplegable();
    }
    // Dibuja y escribe las vidas, discos y balas disponibles
    public void VariarDiscos(int Discos, GameManager.Music musica)
    {
        numeroDiscos.text = "x" + Discos.ToString();
        if(musica == GameManager.Music.classic)
        {
            disco.sprite = discoClasic;
            cintaClasicAni.enabled = true;
            cintaHeavyAni.enabled = false;
            cintaHeavy.rotation = Quaternion.Euler(Vector2.zero);
            cintaElectricAni.enabled = false;
            cintaElectric.rotation = Quaternion.Euler(Vector2.zero);
        }
        else if (musica == GameManager.Music.heavy)
        {
            disco.sprite = discoHeavy;
            cintaClasicAni.enabled = false;
            cintaClasic.rotation = Quaternion.Euler(Vector2.zero);
            cintaHeavyAni.enabled = true;
            cintaElectricAni.enabled = false;            
            cintaElectric.rotation = Quaternion.Euler(Vector2.zero);        
        }
        else if(musica == GameManager.Music.electronic)
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
            if(i <= 0)
            {
                for (int j = 0; j < 10; j++)             
                {
                    pila[j].sprite = vacia[10];
                }
            }
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
    
    public void Perder()
    {
        loseScreen.gameObject.SetActive(true);
    }
    public void Ganar()
    {
        winScreen.gameObject.SetActive(true);
    }
    public void Desplegable()
    {
        if (GameIsPaused) //si no está pausado no queremos meter cuadro de texto
        {
            Resume();//esconder cuadro de texto
        }
        else//gameispaused=true , si esta pausado queremos cuadro de texto de pausa
        {
            Pause();
        }
    }
    //Cierra los menus sonidos y controles
    public void CerrarMenusSonidoControles()
    {
        menuControlesRect.gameObject.SetActive(false);
        menuSonidoRect.gameObject.SetActive(false);
    }
    //Activa el menú sonido
    public void cargarMenuSonido()
    {
        menuControlesRect.gameObject.SetActive(false);
        menuSonidoRect.gameObject.SetActive(true);
    }
    //Activa el menú controles
    public void cargarMenuControles()
    {
        menuSonidoRect.gameObject.SetActive(false);
        menuControlesRect.gameObject.SetActive(true);
    }
    public void Resume()//si esta parado que se esconda el cuadro de texto y vuelva a la normalidad , si saliendo = false , significa que tiene que esconderse el cuadro de texto
    {
        MenuPausa.gameObject.SetActive(false);
        menuControlesRect.gameObject.SetActive(false);
        menuSonidoRect.gameObject.SetActive(false);
        //animboton.SetBool("Saliendo", false);
        Time.timeScale = 1f;//lo se , es para que no se pare
        GameIsPaused = false;
    }
    void Pause()
    {
        MenuPausa.gameObject.SetActive(true);
        //animboton.SetBool("Saliendo", true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
