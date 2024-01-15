using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteraccionNPC : MonoBehaviour
{
    public Mision mision;
    public GameObject panelDialogo; // Panel de UI para mostrar el diálogo
    public TextMeshProUGUI textoDialogo; // Componente de texto para mostrar el diálogo
    public Button botonAceptarMision; // Botón para aceptar la misión
    public GameObject dialogueMark; // Agrega una referencia al marcador de diálogo

    public Mision misionParaActivar;

    private bool estaEnRango = false; // Para comprobar si el jugador está en rango



    void Start()
    {

        botonAceptarMision.onClick.AddListener(AceptarMision); // Asigna el método al botón
        panelDialogo.SetActive(false); // Asegura que el panel esté oculto inicialmente
    }

    void Update()
    {
        // Comprobar si el jugador está en rango y ha presionado la tecla de interacción
        if (estaEnRango && Input.GetButtonDown("Jump"))//Input.GetKeyDown(KeyCode.E)) // E es solo un ejemplo
        {
            Interactuar();
           // Debug.Log("Misión completada: " + GameManager.instance.gestorMisiones.EncontrarMisionPorId(mision.id).estado);
        }
        if (GameManager.instance.gestorMisiones.EncontrarMisionPorId(misionParaActivar.id).estado == EstadoMision.Completada)
        {
            mision.estado = EstadoMision.Completada;
            misionParaActivar.estado = EstadoMision.Completada;
        }
    }

    void Interactuar()
    {
        if (mision != null && !string.IsNullOrEmpty(mision.titulo) && mision.estado == EstadoMision.Disponible)
        {
            panelDialogo.SetActive(true);
           // textoDialogo.text = "¿Quieres aceptar la misión " + mision.titulo + "?";
            textoDialogo.text = "¿Quieres aceptar la misión " + mision.titulo + "?\n(" + "Objetivo" + "):  " + mision.descripcion;

            // El botón ahora maneja la lógica de aceptación
        }
        else if (mision.estado == EstadoMision.Activa && Input.GetKeyDown(KeyCode.E)) // E es solo un ejemplo
        {
            panelDialogo.SetActive(true);
            textoDialogo.text = "Ya has aceptado la mision " + mision.titulo;
            botonAceptarMision.gameObject.SetActive(false);
        }
        else if (mision.estado == EstadoMision.Completada && Input.GetKeyDown(KeyCode.E)) // E es solo un ejemplo
        {
            panelDialogo.SetActive(true);
            textoDialogo.text = "Ya has completado la mision " + mision.titulo;
            botonAceptarMision.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Misión no asignada o título de misión vacío");
        }
        if (mision.estado == EstadoMision.Completada)
        {
            Debug.Log("Misión completada: " + mision.titulo);
        }
    }




    public void AceptarMision()
    {
        Debug.Log("AceptarMision ha sido llamado.");
        Debug.Log("0000000" + misionParaActivar.titulo + misionParaActivar.id);

        // Activar la misión en el GestorMisiones
        //   mision.estado = EstadoMision.Activa;
        //    misionParaActivar.estado = EstadoMision.Activa;
        // GameManager.instance.gestorMisiones.ActivarMision(mision);
        // mision.estado = EstadoMision.Activa;

        //  gestorMisiones.ActivarMision(mision);

        //  if (mision.estado == EstadoMision.Disponible && misionParaActivar.objetivosEliminacion.Count >= 1)
        // {
        //   FindObjectOfType<GestorMisiones>().ActivarMision(mision);
        GameManager.instance.gestorMisiones.ActivarMision(misionParaActivar);
        mision.estado = EstadoMision.Activa;
        misionParaActivar.estado = EstadoMision.Activa;
       // }
        panelDialogo.SetActive(false); // Ocultar el diálogo

    }





    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estaEnRango = true;
            dialogueMark.SetActive(true);

            // Opcional: Mostrar indicador de que el jugador puede interactuar
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estaEnRango = false;
            panelDialogo.SetActive(false); // Ocultar el diálogo si el jugador se aleja
            dialogueMark.SetActive(false);

        }
    }


}