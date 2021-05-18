using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalizadoDesaparecer : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        Invoke("Desaparcer", 1);
        player = GetComponentInParent<Damageable>().gameObject;
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }

    void Desaparcer()
    {
        Destroy(gameObject);
    }
}
