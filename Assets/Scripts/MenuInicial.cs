using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    public GameObject panelGameOver;

    public Salud salud;
    public NivelDeExperiencia nivelDeExperiencia;


    void Start()
    {

    }
    void Update()
    {

    }
    public void NuevaPartida()
    {
        Time.timeScale = 1;

        if (GameManager.instance != null)
        {
            GameManager.instance.gameOn();
        }
        SceneManager.LoadScene("Casa_Xerdan");
    }
    public void Salir()
    {
        Debug.Log("SALIR...");
        Application.Quit();
    }


    public void CargarPartida()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            SceneManager.LoadScene(data.scene);
            ConfigurarJuegoCargado(data);
            GameManager.instance.gameOn();
        }
        else
        {
            Debug.LogError("No se encontraron datos guardados.");
        }
    }

    public void ConfigurarJuegoCargado(PlayerData data)
    {
        // Encuentra al jugador en la escena
        PlayerController jugador = FindObjectOfType<PlayerController>();

        if (jugador != null)
        {

            jugador.ConfigurarJugador(data);
            Time.timeScale = 1;
            if (GameManager.instance != null)
            {
                GameManager.instance.gameOn();
            }
            DinoController.instance.gameObject.SetActive(true);
        }
    }



}
