using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelAtributos : MonoBehaviour
{
    public static PanelAtributos instance;

    public TextMeshProUGUI txtNivel;
    public TextMeshProUGUI txtExperiencia;
    public TextMeshProUGUI txtSalud;
    public TextMeshProUGUI txtAtaque;
    public TextMeshProUGUI txtVelocidad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Intenta obtener la referencia del jugador en Start
        ActualizarReferenciasDelJugador();
    }

    private void ActualizarReferenciasDelJugador()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            PlayerController p = jugador.GetComponent<PlayerController>();
            if (p != null)
            {
                // Si el jugador está presente y tiene un PlayerController, actualiza los atributos
                ActualizarTextoAtributos(p.atributosJugador, p.salud, p.nivelDeExperiencia);
            }
        }
    }

    public void ActualizarTextoAtributos(Atributos atributos, Salud salud, NivelDeExperiencia nivelDeExperiencia)
    {
        if (atributos != null && salud != null && nivelDeExperiencia != null)
        {
            txtNivel.text = nivelDeExperiencia.nivel.ToString();
            txtExperiencia.text = nivelDeExperiencia.experiencia.ToString();
            txtSalud.text = salud.salud.ToString();
            txtAtaque.text = atributos.ataque.ToString();
            txtVelocidad.text = atributos.velocidad.ToString();
        }
    }
}
