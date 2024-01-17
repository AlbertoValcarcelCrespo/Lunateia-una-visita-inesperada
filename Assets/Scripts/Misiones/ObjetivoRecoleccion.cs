using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjetivoRecoleccion
{
    public string itemId; // Referencia directa al objeto del item
    public int cantidadRequerida;
    public int cantidadActual;
    public bool completado;

    public ObjetivoRecoleccion(string itemId, int cantidadRequerida)
    {
        this.itemId = itemId;
        this.cantidadRequerida = cantidadRequerida;
        cantidadActual = 0;
        completado = false;
    }

    // Activa el objetivo.
    public void Activar()
    {
        cantidadActual = 0;
        completado = false;
    }

    // Llamado cuando un objeto es recolectado.
    public void RecolectarObjeto(Item recolectado)
    {
        if (recolectado.id == itemId && !completado)
        {
            cantidadActual++;
            if (cantidadActual >= cantidadRequerida)
            {
                completado = true;
                Debug.Log("Objetivo de recolección completado: " + recolectado.name);
            }
        }
    }
}