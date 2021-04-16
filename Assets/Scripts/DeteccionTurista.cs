using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionTurista : MonoBehaviour
{
    // Start is called before the first frame update
    public MusicEffect MusicEffect;//lo asociamos con el script MusicEffect para poder acceder a su variable pública fuerzaTuristaHeavy

   
    void OnCollisionEnter2D(Collision2D collision)
    {//si la colision se produce con un GO que posee el script MusicEffect (siendo el prefab    Turista el único) , la fuerzaTuristaHeavy se reduce a 0 , así accedemos a ella.
        if (collision.gameObject.tag == "turista")
        {
            MusicEffect.fuerzaTuristaHeavy = 0;
            Debug.Log("El turista ha sido detectado");
        }

    }

}
