using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public GameObject jugador;
    public string playerTag;
    public static GameManager instance { get; private set; }
    public GestorMisiones gestorMisiones;

    public GameObject gameOverUI;

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
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        gestorMisiones =  GetComponent<GestorMisiones>(); 
        jugador.transform.position = playerSpawnPoint.position;
    }


    void Update()
    {
        if (jugador == null)
        {
            jugador = GameObject.FindGameObjectWithTag("Player");
        }
    }


    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void gameOn()
    {
        gameOverUI.SetActive(false);
       
    }

}
