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


    void Start()
    {
        miColisionador = GetComponent<BoxCollider2D>();
        player = GameManager.instance.jugador.GetComponent<PlayerController>();
    }

    //   private void OnTriggerEnter2D(Collider2D collision)
    //    {
    //       miGestorDeNiveles.CargarSiguienteNivel();
    //    }

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
        foreach (RaycastHit2D interactivo in player.Interactuar())
        {
            if (interactivo.collider.gameObject == gameObject)
            {
                Interaccion();
            }
        }
    }


    public virtual void Interaccion()
    {
        Debug.Log("Interactuo con "+ gameObject.name);
    }


}



