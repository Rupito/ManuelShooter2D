using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rehen : MonoBehaviour
{
    spawn spawnScript;
    enemigo enemigoScript;

    void Start()
    {
        spawnScript = FindObjectOfType<spawn>();
        enemigoScript = FindObjectOfType<enemigo>();
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (spawn.Balas > 0)
        {
            spawn.puntos -= 5;
            spawn.vidas -= 1;
            Destroy(gameObject);
            enemigoScript.DestruirEnemigo();
            spawnScript.ResetearPosiciones();
            spawnScript.SonidoRehenGrita();
            spawnScript.Sangre();
        }       
    }

    public void DestruirRehen()
    {
        Destroy(gameObject);
    }
}
