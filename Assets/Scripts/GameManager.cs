using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public GameObject jugador;
    public string playerTag;
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.transform.position = playerSpawnPoint.position;
    }


}
