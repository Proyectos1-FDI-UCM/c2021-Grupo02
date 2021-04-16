using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollower : MonoBehaviour
{
    
        public GameObject personaje;//objeto que queremos que la camara siga , asociarlo a  GO Player
        private Vector3 posicion;//posición o vista de camara que sigue
        void Start()
        {
            posicion = transform.position - personaje.transform.position;
            //posicion inicial de la vista de la camara o seguimiento =  es la posición por defecto de la camara - la posición que tenga en ese momento el personaje
        }

        // Update is called once per frame
        void Update()
        {
            
        
            if (personaje != null)
                transform.position = personaje.transform.position + posicion;
        }

    }



