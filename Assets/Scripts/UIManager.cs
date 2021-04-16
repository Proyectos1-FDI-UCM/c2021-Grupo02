using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image pilasImage, disco;
    public Image pila0, pila1, pila2, pila3, pila4, pila5, pila6, pila7, pila8, pila9;
    public Sprite vacia0, vacia1, vacia2, vacia3, vacia4, vacia5, vacia6, vacia7, vacia8, vacia9;
    public Text numeroDiscos;
    public Animator cintaClasicAni, cintaHeavyAni, cintaElectricAni;
    public RectTransform PilasPanel, PanelDiscos, cintaClasic, cintaHeavy, cintaElectric;
    public Sprite discoClasic, discoHeavy, discoElectric;  
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
            if(vidas<= 0)
            {
                pila0.sprite = vacia9;
                pila1.sprite = vacia9;
                pila2.sprite = vacia9;
                pila3.sprite = vacia9;
                pila4.sprite = vacia9;
                pila5.sprite = vacia9;
                pila6.sprite = vacia9;
                pila7.sprite = vacia9;
                pila8.sprite = vacia9;
                pila9.sprite = vacia9;
            }
            else if(vidas > 0 && vidas <= 10) { 
                if (vidas % 10 == 1) pila0.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila0.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila0.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila0.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila0.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila0.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila0.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila0.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila0.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila0.sprite = vacia0;
                pila1.sprite = vacia9;
                pila2.sprite = vacia9;
                pila3.sprite = vacia9;
                pila4.sprite = vacia9;
                pila5.sprite = vacia9;
                pila6.sprite = vacia9;
                pila7.sprite = vacia9;
                pila8.sprite = vacia9;
                pila9.sprite = vacia9;
            }
            else if (vidas > 10 && vidas <= 20)
            {
                if (vidas != 0 && vidas % 10 == 1) pila1.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila1.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila1.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila1.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila1.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila1.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila1.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila1.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila1.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila1.sprite = vacia0;
                pila2.sprite = vacia9;
                pila3.sprite = vacia9;
                pila4.sprite = vacia9;
                pila5.sprite = vacia9;
                pila6.sprite = vacia9;
                pila7.sprite = vacia9;
                pila8.sprite = vacia9;
                pila9.sprite = vacia9;
            }
            else if (vidas > 20 && vidas <= 30)
            {
                if (vidas != 0 && vidas % 10 == 1) pila2.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila2.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila2.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila2.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila2.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila2.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila2.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila2.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila2.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila2.sprite = vacia0;
                pila3.sprite = vacia9;
                pila4.sprite = vacia9;
                pila5.sprite = vacia9;
                pila6.sprite = vacia9;
                pila7.sprite = vacia9;
                pila8.sprite = vacia9;
                pila9.sprite = vacia9;
            }
            else if (vidas > 30 && vidas <= 40)
            {
                if (vidas != 0 && vidas % 10 == 1) pila3.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila3.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila3.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila3.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila3.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila3.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila3.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila3.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila3.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila3.sprite = vacia0;
                pila4.sprite = vacia9;
                pila5.sprite = vacia9;
                pila6.sprite = vacia9;
                pila7.sprite = vacia9;
                pila8.sprite = vacia9;
                pila9.sprite = vacia9;
            }
            else if (vidas > 40 && vidas <= 50)
            {
                if (vidas != 0 && vidas % 10 == 1) pila4.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila4.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila4.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila4.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila4.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila4.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila4.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila4.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila4.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila4.sprite = vacia0;
                pila5.sprite = vacia9;
                pila6.sprite = vacia9;
                pila7.sprite = vacia9;
                pila8.sprite = vacia9;
                pila9.sprite = vacia9;
            }   
            else if (vidas > 50 && vidas <= 60)
            {
                if (vidas != 0 && vidas % 10 == 1) pila5.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila5.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila5.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila5.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila5.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila5.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila5.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila5.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila5.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila5.sprite = vacia0;
                pila6.sprite = vacia9;
                pila7.sprite = vacia9;
                pila8.sprite = vacia9;
                pila9.sprite = vacia9;
            }
            else if (vidas > 60 && vidas <= 70)
            {
                if (vidas != 0 && vidas % 10 == 1) pila6.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila6.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila6.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila6.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila6.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila6.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila6.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila6.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila6.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila6.sprite = vacia0;
                pila7.sprite = vacia9;
                pila8.sprite = vacia9;
                pila9.sprite = vacia9;
            }
            else if (vidas > 70 && vidas <= 80)
            {
                if (vidas != 0 && vidas % 10 == 1) pila7.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila7.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila7.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila7.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila7.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila7.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila7.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila7.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila7.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila7.sprite = vacia0;
                pila8.sprite = vacia9; 
                pila9.sprite = vacia9;
            }
            else if (vidas > 80 && vidas <= 90)
            {
                if (vidas != 0 && vidas % 10 == 1) pila8.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila8.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila8.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila8.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila8.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila8.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila8.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila8.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila8.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila8.sprite = vacia0;
                pila9.sprite = vacia9;
            }
            else if (vidas > 90 && vidas <= 100)
            {
                if (vidas != 0 && vidas % 10 == 1) pila9.sprite = vacia9;
                else if (vidas != 0 && vidas % 10 == 2) pila9.sprite = vacia8;
                else if (vidas != 0 && vidas % 10 == 3) pila9.sprite = vacia7;
                else if (vidas != 0 && vidas % 10 == 4) pila9.sprite = vacia6;
                else if (vidas != 0 && vidas % 10 == 5) pila9.sprite = vacia5;
                else if (vidas != 0 && vidas % 10 == 6) pila9.sprite = vacia4;
                else if (vidas != 0 && vidas % 10 == 7) pila9.sprite = vacia3;
                else if (vidas != 0 && vidas % 10 == 8) pila9.sprite = vacia2;
                else if (vidas != 0 && vidas % 10 == 9) pila9.sprite = vacia1;
                else if (vidas != 0 && vidas % 10 == 0) pila9.sprite = vacia0;
            }       
    }   
}
