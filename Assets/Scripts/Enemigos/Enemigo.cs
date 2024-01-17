using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Atributos atributos;
    public string nombre;
    public int experiencia;
    public string id;

    public Atributos Atributos()
    {
        return atributos;
    }

    public void EntregarExperiencia()
    {
        GameManager.instance.jugador.GetComponent<NivelDeExperiencia>().experiencia += experiencia;
    }

    public void OnMuerte()
    {
        GameManager.instance.gestorMisiones.EnemigoEliminado(id);
    }
}
