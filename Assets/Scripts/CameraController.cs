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

    private CinemachineVirtualCamera cv;
    public GameObject jugador;

    public static CameraController instance;
    // Resto de las variables de la cámara

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        cv = GetComponent<CinemachineVirtualCamera>();
        Transform jugador = GameManager.instance.jugador.transform;//GameObject.FindGameObjectWithTag("Player").transform;
        cv.m_Follow = jugador;
    }

}
