using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera cv;
    public GameObject jugador;
    public Transform jugadorT;
    public static CameraController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugadorT = jugador.transform;
        cv = GetComponentInChildren<CinemachineVirtualCamera>();
        cv.Follow = jugadorT;
    }
    void Update()
    {
        if (cv.Follow == null || cv.Follow.gameObject == null)
        {
            ActualizarReferenciaJugador();
        }
    }

    public void ActualizarReferenciaJugador()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            cv.m_Follow = jugador.transform;
            cv.Follow = jugador.transform;
        }
    }
}

