using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MisionData
{
    public string idMision;
    public EstadoMision estado;
    public List<ObjetivoMisionData> objetivos;

    public MisionData(string id, EstadoMision estadoMision, List<ObjetivoMisionData> objetivosMision)
    {
        idMision = id;
        estado = estadoMision;
        objetivos = objetivosMision;
    }
}

[Serializable]
public class ObjetivoMisionData
{
    public string descripcion;
    public bool completado;
}

