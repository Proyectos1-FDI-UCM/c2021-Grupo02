using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class zoomcollider : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera  myVirtualCamera;
    // Start is called before the first frame update
   private void Start()
    {//para iniciarse en false por defecto y que solo entre en zonas concretas
        myVirtualCamera.gameObject.SetActive(false);
    }

    //Metodo que posee un Trigger que detecta a un GO con script ControlesPlayer y activa la camara virtual
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<ControlesPlayer>())
            myVirtualCamera.gameObject.SetActive(true);
    }

    //Metodo que posee un Trigger que detecta a un GO con script ControlesPlayer y desactiva la camara virtual
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<ControlesPlayer>())
        myVirtualCamera.gameObject.SetActive(false);
    }

}
