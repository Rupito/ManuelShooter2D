using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemigo : MonoBehaviour
{
    spawn spawnScript;
    Rehen rehenScript;

    void Start()
    {
        Invoke("TiempoRespawn",3f);
        spawnScript = FindObjectOfType<spawn>();
        rehenScript = FindObjectOfType<Rehen>();
    }


    void Update()
    {

    }
    
    private void OnMouseDown()
    {
        if (spawn.Balas > 0)
        {
            spawn.puntos += 10;
            Destroy(gameObject);
            rehenScript.DestruirRehen();
            spawnScript.SonidoEnemigoMuerto();
            spawnScript.ResetearPosiciones();
        }
    }

    void TiempoRespawn()
    {
        spawn.vidas -= 1;
        Destroy(gameObject);
        rehenScript.DestruirRehen();
        spawnScript.Sangre();
    }

    public void DestruirEnemigo()
    {
        Destroy(gameObject);
    }
}
