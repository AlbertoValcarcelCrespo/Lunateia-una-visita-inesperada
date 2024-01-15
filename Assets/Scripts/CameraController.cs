using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    /*
     public Transform jugador;
     private Transform mitransformada;

     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         float posX = jugador.position.x;
         float posY = jugador.position.y;
         MoverCamara(posX, posY);
     }

     void MoverCamara(float coordenadaX, float coordenadaY)
     {
         Vector3 nuevaPosicion = new Vector3(coordenadaX, coordenadaY, transform.position.z);
        // transform.position = nuevaPosicion;
         Camera.main.transform.position = nuevaPosicion;
     }
    */
    //   public Transform target; // El objetivo que la cámara debe seguir

    public CinemachineVirtualCamera cv;
    public GameObject jugador;
    public Transform jugadorT;
    public static CameraController instance;
    // Resto de las variables de la cámara




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
        //  EncontrarJugador();
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugadorT = jugador.transform;
        cv = GetComponentInChildren<CinemachineVirtualCamera>();
        // CinemachineVirtualCamera cc = ;
        //  cv.follow = jugador.transform;
        //    cv.m_Follow.gameObject = GameObject.FindGameObjectWithTag("Player");
        // cv = this;
        cv.Follow = jugadorT;// GameManager.instance.jugador.transform;//jugador.transform;//GameObject.FindGameObjectWithTag("Player").transform;
   //     Debug.Log("Datos Guardados" + cv);

      //  cv.m_Follow = GameManager.instance.jugador.transform;//jugador.transform;//GameObject.FindGameObjectWithTag("Player").transform;
       // ActualizarReferenciaJugador();
    }
    void Update()
    {
        //   {
        // Opcionalmente, puedes revisar periódicamente si la referencia del jugador necesita ser actualizada
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

