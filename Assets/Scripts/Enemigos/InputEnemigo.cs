using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemigo : MonoBehaviour
{

    public Transform jugador;
    public float vertical {  get { return direccionHaciaJugador.y; } }
    public float horizontal { get { return direccionHaciaJugador.x; } }
    public float distancia { get { return direccionHaciaJugador.magnitude; } }
    public Vector2 direccionHaciaJugador { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player")?.transform;

        // Intenta encontrar al jugador si no está asignado
        if (jugador == null)
        {
            jugador = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        // Si el jugador es encontrado, calcula la dirección inicial hacia él
        if (jugador != null)
        {
            direccionHaciaJugador = jugador.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador != null)
        {
            direccionHaciaJugador = jugador.position - transform.position;
        }
    }
}
