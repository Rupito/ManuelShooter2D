using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour
{
    public Vector2[] posiciones = new Vector2[30];
    public Vector2[] posRehen = new Vector2[27];

    AudioSource AS;
    public AudioClip SonidoDisparo;
    public AudioClip SonidoClickDisparo;
    public AudioClip SonidoRecargar;
    public AudioClip SonidoRehen;
    public AudioClip SonidoPunto;  

    public GameObject malo;
    public GameObject Rehen;
    public GameObject sangre;
    public static int pos;

    public TextMeshProUGUI PuntosTMP;
    public TextMeshProUGUI VidasTMP;
    public static int puntos;
    public static int vidas;

    public TextMeshProUGUI BalasTMP;
    public static int Balas;

    void Start()
    {
        AS = GetComponent<AudioSource>();

        puntos = 0;
        PuntosTMP.text = puntos.ToString();

        vidas = 5;
        VidasTMP.text = vidas.ToString();

        Balas = 5;
        BalasTMP.text = Balas.ToString();

        InvokeRepeating("GenerarPosiciones",0f,3f);
    }

    void Update()
    {
        PuntosTMP.text = puntos.ToString();
        VidasTMP.text = vidas.ToString();
        BalasTMP.text = Balas.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            if (Balas > 0)
            {
                Balas--;
                AS.PlayOneShot(SonidoClickDisparo);
            }           
        }
        if (Input.GetMouseButtonDown(1))
        {
            Balas = 5;
            AS.PlayOneShot(SonidoRecargar);
        }

        if ( vidas == 0 )
        {
            GameOver();
        }
    }

    public void GenerarPosiciones()
    {
        int la = Random.Range(0, 5);
        if (la < 3)
        {
            pos = Random.Range(0, 27);
            Instantiate(malo, posiciones[pos], Quaternion.identity);
            Instantiate(Rehen, posRehen[pos], Quaternion.identity);
        }
        else
        {
            pos = Random.Range(0, 30);
            Instantiate(malo, posiciones[pos], Quaternion.identity);

            pos = Random.Range(0, 27);
            Instantiate(Rehen, posRehen[pos], Quaternion.identity);
        }       
    }

    public void ResetearPosiciones()
    {
        CancelInvoke("GenerarPosiciones");
        InvokeRepeating("GenerarPosiciones", 0f, 3f);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("00");
    }

    //SONIDOS
    //============================================================================================================================
    public void Sangre()
    {
        Instantiate(sangre, new Vector3(0f, 0f, 0f), Quaternion.identity);
        AS.PlayOneShot(SonidoDisparo);
    }

    public void SonidoRehenGrita()
    {
        AS.PlayOneShot(SonidoRehen);
    }

    public void SonidoEnemigoMuerto()
    {
        AS.PlayOneShot(SonidoPunto);
    }
    //============================================================================================================================
}
