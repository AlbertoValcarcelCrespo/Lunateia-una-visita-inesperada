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

    // Método para progresar en el objetivo
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

    // Método para completar el objetivo
    public void Completar()
    {
        completado = true;
        Debug.Log(descripcion + " completado.");
        // Código adicional para manejar la finalización del objetivo
    }


    public TipoObjetivoMision GetObjetivoMision()
    {
        return this.tipoObjetivo;
    }
}