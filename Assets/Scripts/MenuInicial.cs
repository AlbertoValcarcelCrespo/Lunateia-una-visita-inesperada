using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public void NuevaPartida()
    {
        SceneManager.LoadScene("Casa_Xerdan");
    }
    public void Salir()
    {
        Debug.Log("SALIR...");
        Application.Quit();
    }
}
