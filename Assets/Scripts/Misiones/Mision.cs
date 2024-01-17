using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum EstadoMision
{
    Disponible,
    Activa,
    Completada
}

public enum TipoObjetivoMision
{
    Eliminacion,
    Exploracion,
    Recoleccion
}

[System.Serializable]
public class Mision
{
    public string id; // Identificador único para la misión

    public string titulo;
    public string descripcion;

    public List<ObjetivoMision> objetivos;
    public Recompensa recompensa;
    public EstadoMision estado;

    public List<ObjetivoRecoleccion> objetivosRecoleccion;
    public List<ObjetivoEliminacion> objetivosEliminacion;



    public bool EstaCompletada()
    {
        return objetivos.All(objetivo => objetivo.completado);
    }

    // Método para activar la misión
     public void ActivarMision()
      {

             if (objetivos[0].GetObjetivoMision() == TipoObjetivoMision.Recoleccion && objetivos.Count >=1)
          {
              foreach (var objetivo in objetivosRecoleccion)
              {
                  objetivo.Activar();
                  estado = EstadoMision.Activa;
              }
          }
          else 
          {
              foreach (var objetivo in objetivosEliminacion)
              {
                  objetivo.Activar();
                   estado = EstadoMision.Activa;
              }
          }
      }

    // Verifica si todos los objetivos de recolección están completos.
    public bool VerificarObjetivosCompletos()
    {
        foreach (var objetivo in objetivosRecoleccion)
        {
            if (!objetivo.completado)
                return false;
        }
        return true;
    }

    public bool VerificarObjetivosCompletosE()
    {
        foreach (var objetivo in objetivosEliminacion)
        {
            if (!objetivo.completado)
                return false;
        }
        return true;
    }

}




