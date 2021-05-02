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

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HOLA");
        myVirtualCamera.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        myVirtualCamera.gameObject.SetActive(false);
    }

}
