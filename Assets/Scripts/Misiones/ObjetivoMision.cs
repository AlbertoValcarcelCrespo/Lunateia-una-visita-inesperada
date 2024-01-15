using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjetivoMision
{
    public string descripcion;
    public bool completado;
    public TipoObjetivoMision tipoObjetivo;
    public int cantidadRequerida;
    public int cantidadActual;

    // Constructor para inicializar un nuevo objetivo
    public ObjetivoMision(TipoObjetivoMision tipo, int cantidadRequerida)
    {
        this.tipoObjetivo = tipo;
        this.cantidadRequerida = cantidadRequerida;
        cantidadActual = 0;
        completado = false;
    }

    // M�todo para progresar en el objetivo
    public void Progresar(int cantidad = 1)
    {
        if (!completado)
        {
            cantidadActual += cantidad;
            if (cantidadActual >= cantidadRequerida)
            {
                Completar();
            }
        }
    }

    // M�todo para completar el objetivo
    public void Completar()
    {
        completado = true;
        Debug.Log(descripcion + " completado.");
        // C�digo adicional para manejar la finalizaci�n del objetivo
    }


    public TipoObjetivoMision GetObjetivoMision()
    {
        return this.tipoObjetivo;
    }
}