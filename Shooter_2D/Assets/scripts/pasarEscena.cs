using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pasarEscena : MonoBehaviour
{
    AudioSource AS;
    public AudioClip SonidoClick;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    public void SiguienteEscena()
    {
        AS.PlayOneShot(SonidoClick);
        SceneManager.LoadScene("02");
    }

    public void GameOverSI()
    {
        AS.PlayOneShot(SonidoClick);
        SceneManager.LoadScene("01");
        spawn.puntos = 0;
        spawn.vidas = 5;
    }

    public void GameOverNO()
    {
        AS.PlayOneShot(SonidoClick);
        Application.Quit();
    }
}
