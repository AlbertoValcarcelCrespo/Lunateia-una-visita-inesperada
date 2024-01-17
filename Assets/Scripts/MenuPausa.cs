using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 
using UnityEngine.UI; 


public class MenuPausa : MonoBehaviour
{
    public static MenuPausa instance;


    public GameObject panelPausa;
    public GameObject panelOpciones;
    public AudioSource audioSource;
    public Slider volumeSlider;

    private bool isMuted = false;


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


    void Start()
    {
        volumeSlider.value = audioSource.volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelPausa.activeSelf)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f; // Detiene el tiempo
    }

    public void Continuar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f; // Reanuda el tiempo
    }

    public void GuardarPartida()
    {
        SaveSystem.SavePlayer(PlayerController.instance);
        Inventario.instance.GuardarInventario();
        Debug.Log("Datos Guardados");
    }

    public void MostrarOpciones()
    {
        panelPausa.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void AjustarVolumen(float volumen)
    {
          audioSource.volume = volumen;
    }
    public void Mute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
    }


    public void Salir()
    {
        Application.Quit();
    }


    public void CerrarMenuOpciones()
    {
        panelOpciones.SetActive(false);
        Time.timeScale = 1f;
    }

}