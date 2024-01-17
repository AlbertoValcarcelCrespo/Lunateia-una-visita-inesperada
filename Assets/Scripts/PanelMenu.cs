using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenu : MonoBehaviour
{
    public static PanelMenu instance { get; private set; }
    private CanvasGroup canvasGroup;
    private bool abierto;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            canvasGroup = GetComponent<CanvasGroup>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void AbrirCerrarInventario()
    {
        if (abierto)
        {
            CerrarPanel();
        }
        else
        {
            AbrirPanel();
        }
    }

    private void CerrarPanel()
    {
        abierto = false;

        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        Time.timeScale = 1;
    }

    private void AbrirPanel()
    {
        abierto = true;

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        Time.timeScale = 0;
    }
}
