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
    //    PlayerController jugador = FindObjectOfType<PlayerController>();
      //  if (jugador != null)// && jugador.salud.SaludActual <= 0)
      //  {
            //jugador.ReiniciarEstado();
    //        Destroy(jugador);

     //   }
    }
    void Update()
    {
     //   PlayerController jugador = FindObjectOfType<PlayerController>();
        //  if (jugador != null)// && jugador.salud.SaludActual <= 0)
        //  {
        //jugador.ReiniciarEstado();
     //   Destroy(jugador);

        //   }
    }
    public void NuevaPartida()
    {
        Time.timeScale = 1;

        if (GameManager.instance != null)
        {
            GameManager.instance.gameOn();
        }
        SceneManager.LoadScene("Casa_Xerdan");
      //  DinoController.instance.gameObject.SetActive(true);

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
            // El resto del código se ejecutará después de que la escena se cargue
        }
        else
        {
            Debug.LogError("No se encontraron datos guardados.");
        }
    }

    // Asegúrate de que este método se llame después de cargar la escena
    public void ConfigurarJuegoCargado(PlayerData data)
    {
        // Encuentra al jugador en la escena
        PlayerController jugador = FindObjectOfType<PlayerController>();

        // Configura los datos del jugador
        if (jugador != null)
        {

            jugador.ConfigurarJugador(data);
            Time.timeScale = 1;
            if (GameManager.instance != null)
            {
                GameManager.instance.gameOn();
            }
            DinoController.instance.gameObject.SetActive(true);
            // Configura la posición del jugador y otros datos
        }
    }



}
