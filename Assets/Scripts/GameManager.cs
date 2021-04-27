using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private UIManager UIManager;
    AudioManager audioManager;
    //Empieza con 101 vidas porque le quita vidas solo con empezar
    int vidas = 101, discos = 20;
    char musica = 'c';
    int enemy = 0;
    bool paralisis = false, perderJugador = false, playerEnSala = false, recargaDiscos = false;
    //Método para crear la instancia del GameManager
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
        if (musica == 'c' && recargaDiscos) { recargaDiscos = false; AñadirDiscos(); }
        else if(musica =='e' || musica == 'h') { CancelInvoke();  recargaDiscos = true; }
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
        musica = 'e';
    }
    //Reduce 1 vida cada x segundos
    public void MusicaClásica()
    {
        musica = 'c';
    }
    //Reduce 1 vida más rapidamente que la música clásica 
    public void MusicaHeavy()
    {
        print("Esta sonando musica heavy");
        musica = 'h';
    }
    //Actualiza el char de la música que esté sonando y lo devuelve
    public char Musica()
    {
        if (musica == 'c') return 'c';
        else if (musica == 'e') return 'e';
        else if (musica == 'h') return 'h';
        else return ' ';
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
        }
        else print("YOU WIN");
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
        Invoke("SumaDiscos", 1);

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
        UIManager.VariarDiscos(discos, musica);
        UIManager.UpdateLives(vidas);
    }

    //guarda el audio manager 
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
        audioManager.Play(sonido);
    }
}
