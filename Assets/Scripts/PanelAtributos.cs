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


    public void Start()
    {
        instance = this;
    }



    public void ActualizarTextoAtributos(Atributos atributos, Salud salud, NivelDeExperiencia nivelDeExperiencia)
    {
        txtNivel.text = nivelDeExperiencia.nivel.ToString();
        txtExperiencia.text = nivelDeExperiencia.experiencia.ToString();
        txtSalud.text = salud.salud.ToString();
        txtAtaque.text = atributos.ataque.ToString();
        txtVelocidad.text = atributos.velocidad.ToString();


    }
}
