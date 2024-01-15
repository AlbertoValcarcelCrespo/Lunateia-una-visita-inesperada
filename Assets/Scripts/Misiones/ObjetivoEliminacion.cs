using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjetivoEliminacion
{
    public string enemigoId; // Referencia directa al GameObject del enemigo
    public int cantidadRequerida;
    public int cantidadActual;
    public bool completado;

    public void Activar()
    {
        cantidadActual = 0;
        completado = false;
    }

    public void EnemigoEliminado(string enemigoEliminadoId)
    {
        if (enemigoEliminadoId == enemigoId && !completado)
        {
            cantidadActual++;
            if (cantidadActual >= cantidadRequerida)
            {
                completado = true;
                Debug.Log("Objetivo completado: Eliminar " + cantidadRequerida + " de " + enemigoEliminadoId + enemigoId);
            }
        }
    }
}