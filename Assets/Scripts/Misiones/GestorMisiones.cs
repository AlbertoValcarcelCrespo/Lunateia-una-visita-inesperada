using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GestorMisiones : MonoBehaviour
{
    public List<Mision> misiones;

    // M�todo para llamar cuando un objeto es recolectado.
    public void RecolectarItem(Item item)
    {
        foreach (var mision in misiones)
        {
            if (mision.estado == EstadoMision.Activa)
            {
                foreach (var objetivo in mision.objetivosRecoleccion)
                {
                    objetivo.RecolectarObjeto(item);
                }

                // Si todos los objetivos est�n completos, completa la misi�n.
                if ((mision.VerificarObjetivosCompletos()) && (mision.objetivos[0].GetObjetivoMision() == TipoObjetivoMision.Recoleccion))
                {
                    CompletarMision(mision);
                }
            }
        }
    }

    public void EnemigoEliminado(string enemigoId)
    {
        foreach (var mision in misiones)
        {
            if (mision.estado == EstadoMision.Activa && mision.objetivosEliminacion.Count >=1)
            {
                foreach (var objetivo in mision.objetivosEliminacion)
                {
                    objetivo.EnemigoEliminado(enemigoId);
                }

                if ((mision.VerificarObjetivosCompletosE())) 
                {
                    CompletarMision(mision);
                }
            }
        }
    }

    // M�todo para activar una misi�n
    public void ActivarMision(Mision misionParaActivar)
    {
        Mision mision = misiones.Find(m => m.id == misionParaActivar.id);

        mision.ActivarMision();
    }

    // M�todo para verificar y actualizar el estado de las misiones
    public void VerificarMisiones()
    {
        foreach (Mision mision in misiones)
        {
            if (mision.estado == EstadoMision.Activa && mision.EstaCompletada())
            {
                CompletarMision(mision);
            }
        }
    }

    // M�todo para completar una misi�n y otorgar recompensas
    private void CompletarMision(Mision mision)
    {
        mision.estado = EstadoMision.Completada;
        InteraccionNPC npc = FindObjectOfType<InteraccionNPC>();

        npc.mision.estado = EstadoMision.Completada;
        npc.misionParaActivar.estado = EstadoMision.Completada;
        OtorgarRecompensa(mision.recompensa);
    }

    private void OtorgarRecompensa(Recompensa recompensa)
    {
        PlayerController jugador = FindObjectOfType<PlayerController>(); // Encuentra el objeto del jugador

        if (jugador != null)
        {
            // Otorgar experiencia
            jugador.nivelDeExperiencia.experiencia += recompensa.experiencia;
            jugador.nivelDeExperiencia.ActualizarBarraExp();
            jugador.nivelDeExperiencia.ActualizarPanelDeAtributos();

            // Otorgar oro
            // jugador.GanarOro(recompensa.oro);

            // Otorgar �tems, si los hay en la recompensa
            //   foreach (var item in recompensa.items)
            //   {
            //       jugador.Inventario.AgregarObjeto(item, 1);
            //   }

        }
    }


    public void GuardarMisiones()
    {
        List<MisionData> misionesData = new List<MisionData>();

        foreach (Mision mision in misiones)
        {
            List<ObjetivoMisionData> objetivosData = mision.objetivos.Select(objetivo =>
                new ObjetivoMisionData { descripcion = objetivo.descripcion, completado = objetivo.completado }).ToList();

            misionesData.Add(new MisionData(mision.id, mision.estado, objetivosData));
        }

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/misiones.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, misionesData);
        stream.Close();
    }

    public void CargarMisiones()
    {
        string path = Application.persistentDataPath + "/misiones.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<MisionData> misionesData = formatter.Deserialize(stream) as List<MisionData>;
            stream.Close();

            foreach (MisionData misionData in misionesData)
            {
                Mision mision = EncontrarMisionPorId(misionData.idMision);

                if (mision != null)
                {
                    mision.estado = misionData.estado;
                    for (int i = 0; i < mision.objetivos.Count; i++)
                    {
                        mision.objetivos[i].completado = misionData.objetivos[i].completado;
                    }
                }
            }
        }
    }

    public Mision EncontrarMisionPorId(string id)
    {
          int numero = int.Parse(id);
       return misiones[numero-1];
    }



}


