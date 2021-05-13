using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private UIManager UIManager;
    private UiEnemies UiEnemies;
    AudioManager audioManager;
    UiPolicia UiPolicia;
    //Empieza con 101 vidas porque le quita vidas solo con empezar
    int vidas = 101, discos = 20;
    int enemy = 0;
    bool paralisis = false, perderJugador = false, playerEnSala = false, recargaDiscos = true, classic = true, heavy = true, electric = true;
    public string[] scenesInOrder;
    bool cambio = true;

    //para poner por orden las escenas que hay
    /*int stage = 1;*///escena en la que te encuentras
    //Método para crear la instancia del GameManager

    public enum Music { classic,heavy,electronic}
    Music mus = Music.classic;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        AñadirDiscos();     
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "EscenaPruebas") vidas = 101;
        if (SceneManager.GetActiveScene().name == "MenuPpal")
        {
            audioManager.ChangeMusic("MusicaMenu");
        }
       else if (SceneManager.GetActiveScene().name == "EscenaFinal"&&cambio)
        {
            cambio = false;
            audioManager.ChangeMusic("MusicaClasica"); 
        }
        if (mus == Music.classic)
        {
            if (classic && recargaDiscos)
            {
                classic = false;
                heavy = true;
                electric = true;
                recargaDiscos = false;
                CancelInvoke();
                InvokeRepeating("AñadirDiscos", 0, 2);
                InvokeRepeating("ReducirVidasConstante", 0, 0.6f);
            }

        }
        else if (mus == Music.heavy)
        {
            if (heavy)
            {
                heavy = false;
                classic = true;
                electric = true;
                recargaDiscos = true;
                CancelInvoke();
                InvokeRepeating("ReducirVidasConstante", 0, 0.4f);
            }

        }
        else if (mus == Music.electronic)
        {
            if (electric)
            {
                electric = false;
                classic = true;
                heavy = true;
                recargaDiscos = true;
                CancelInvoke();
                InvokeRepeating("vidasElectric", 0, 0.6f);
            }
        }
        if (vidas >= 0) JugMuerto();
    }
    public void PonerFalsePerderJugador()
    {
        perderJugador = false;
        cambio = true;
        vidas = 101;
        enemy = 0;
    }
    public bool EntrarSala()
    {
        playerEnSala = true;
        return playerEnSala;
    }
    public bool SalirSala()
    {
        playerEnSala = false;
        return playerEnSala;
    }
    public bool EstadoSala()
    {
        return playerEnSala;
    }
    //Método para cada vez que matamos a un robot lo quite de la cuenta
    public void RemoveEnemy()
    {
        enemy--;
        print("enemy: " + enemy);
    }
    public bool Enemiesmuertos()
    {
        if (enemy <= 0) return true;
        else return false;
    }
    
    //Reduce 1 sola vida cuando golpean
    public void reducirVidas()
    {
        vidas = vidas - 10;
     
    }
    //Reduce dos vidas al recibir un golpe
    public void reducir2Vidas()
    {
        vidas = vidas - 20;
      
    }
    public void ReducirVidasConstante()
    {
        if(vidas >= 0)
        vidas--;
    }
    //Cambia el estado del booleano parálisis que es el que permitirá o no al jugador moverse
    public void CambiarEstadoParalisis()
    {
        paralisis = !paralisis;
    }
    //Actualiza como está dicho booleano llamado parálisis
    public bool EstadoParalisis()
    {
        return paralisis;
    }
    //Aumenta 1 vida cada x segundos
    public void vidasElectric()
    {
        if (vidas < 100) vidas = vidas + 1;
    }
    //Dice que está sonando música elétrica
    public void MusicaElectric()
    {
        print("Esta sonando musica electric");

        mus=Music.electronic;

        audioManager.ChangeMusic("MusicaElectronica");
    }
    //Reduce 1 vida cada x segundos
    public void MusicaClásica()
    {
        mus = Music.classic;

        audioManager.ChangeMusic("MusicaClasica");
    }
    //Reduce 1 vida más rapidamente que la música clásica 
    public void MusicaHeavy()
    {
        
        mus = Music.heavy;

        audioManager.ChangeMusic("MusicaHeavy");
    }
    //Actualiza el char de la música que esté sonando y lo devuelve 
    public Music Musica()
    {
        return mus;
    }
    public void CerrarJuego()
    {
        Application.Quit();
    }
    //Actualiza de si el jugador está vivo o muerto 
    public bool JugMuerto()
    {
        bool muerto = false;

        if (vidas <= 0)
        {
            muerto = true;
            Perder(muerto);
        }
        return muerto;
    }
    //Cuando el jugador pierde cambia el booleano para que los enemigos dejen de disparar
    public void Perder(bool perder)
    {
        if (perder == true)
        {
            perderJugador = true;
            UIManager.Perder();
        }
        else
        {
            UIManager.Ganar();
            print("YOU WIN");
        }

    }
    //Avisa de si el jugador está vivo o muerto, un simple booleano
    public bool EstadoJugador()
    {
        return perderJugador;
    }
    //Añade un robot a la lista enemyRobot al empezar la partida
    public void AddEnemy()
    {
        enemy++;
        print("enemy: " + enemy);
    }
    //Reduce el número de discos al disparar e impide que dispare cuando no le quedan
    public void AñadirDiscos()
    {
        Invoke("SumaDiscos", 0);
    }
    public void SumaDiscos()
    {
        if(discos < 20) discos++;
    
    }
    public bool NumeroDiscos()
    {
        if (discos > 0)
        {
            discos--;

            return true;
        }
        else
        {
            Debug.Log("No te quedan discos");
            return false;
        }
    }
    public static GameManager GetInstance()
    {
        return instance;
    }
    public void UIManagerUpdate(UIManager uim)
    {
        UIManager = uim;
        UIManager.VariarDiscos(discos, mus);
        UIManager.UpdateLives(vidas);
        
    }
    public void SoyElAudioManager(AudioManager aM)
    {
        audioManager = aM;
    }  

    //devuelve el audio manager
    public AudioManager GetAudioManagerInstance()
    {
        return audioManager;
    }

    //reproduce un sonido
    public void ReproducirSonido(string sonido)
    {
        audioManager.GetComponent<AudioManager>().Play(sonido);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
  
    }
    
}
