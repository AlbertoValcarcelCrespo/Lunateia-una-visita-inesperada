using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Interactivo : MonoBehaviour//, IPointerDownHandler
{
    protected BoxCollider2D miColisionador;
    public GestorDeNiveles miGestorDeNiveles;
    public UnityEvent OnInteraccion;
    protected PlayerController player;

    void Awake()
    {
        miColisionador = GetComponent<BoxCollider2D>();
        
    }

    void Start()
    {
        // Intenta encontrar al jugador en Start en lugar de Awake.
        if (GameManager.instance != null && GameManager.instance.jugador != null)
        {
            player = GameManager.instance.jugador.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogWarning("El jugador no se encontró en la escena.");
        }    
}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnInteraccion.Invoke();
    }

    public void OnMouseDown()
    {      
        Debug.Log("Haciendo Click");
        Interactuar();
    }

    protected void Interactuar()
    {
        RaycastHit2D[] interactuables = player?.Interactuar();
        if (interactuables != null)
        {
            foreach (RaycastHit2D interactivo in interactuables)
            {
                if (interactivo.collider.gameObject == gameObject)
                {
                    Interaccion();
                }
            }
        }
    }



    public virtual void Interaccion()
    {
        Debug.Log("Interactuo con "+ gameObject.name);
    }


}



